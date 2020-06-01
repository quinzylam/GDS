using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace GDS.Mobile.Commands
{
    internal class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(
            Action<object> execute,
            Func<object, bool> canExecute = null
            )
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public RelayCommand(
            Action execute,
            Func<bool> canExecute = null
            )
        {
            _execute = x => execute();
            if (canExecute != null)
                _canExecute = x => canExecute();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        #region Explicit implementations

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
                _execute(parameter);
            RaiseCanExecuteChanged();
        }

        private bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute(parameter);
        }

        #endregion Explicit implementations
    }
}