using GDS.Mobile.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GDS.Mobile.Commands
{
    internal class AsyncCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public delegate void ExecuteEventHandler(object sender, ExecuteTaskEventArgs e);

        public event ExecuteEventHandler PreExecution;

        public event ExecuteEventHandler PostExecution;

        public event ExecuteEventHandler FailedExecution;

        private readonly Func<object, Task> _execute;
        private readonly Func<object, bool> _canExecute;
        private readonly TaskWatcher _watcher;

        public AsyncCommand(
            Func<object, Task> execute,
             TaskWatcher watcher = null,
            Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
            _watcher = watcher ?? new TaskWatcher();
        }

        public AsyncCommand(Func<Task> execute, TaskWatcher watcher = null, Func<bool> canExecute = null)
        {
            _execute = x => execute();
            _watcher = watcher ?? new TaskWatcher();
            if (canExecute != null)
                _canExecute = x => canExecute();
        }

        public bool CanExecute(object parameter = null)
        {
            return !_watcher.IsNotCompleted && (_canExecute?.Invoke(parameter) ?? true);
        }

        public async Task ExecuteAsync(object parameter = null)
        {
            PreExecution?.Invoke(this, new ExecuteTaskEventArgs { IsExecuting = true });
            await _execute(parameter);
            RaiseCanExecuteChanged();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        #region Explicit implementations

        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute(parameter);
        }

        private void PostExecute()
        {
            PostExecution?.Invoke(this, new ExecuteTaskEventArgs { IsExecuting = _watcher.IsNotCompleted, IsSuccess = _watcher.IsSuccessfullyCompleted, Exception = _watcher.Exception });
        }

        void ICommand.Execute(object parameter)
        {
            try
            {
                _watcher.ExecuteTask(ExecuteAsync(parameter), PostExecute);
            }
            catch (Exception ex)
            {
                FailedExecution?.Invoke(this, new ExecuteTaskEventArgs { IsExecuting = _watcher.IsNotCompleted, Exception = ex });
                throw ex;
            }
        }

        #endregion Explicit implementations
    }
}