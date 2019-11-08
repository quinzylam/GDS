using GDS.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Mobile.Commands
{
    public class TaskWatcher : BaseModel
    {
        public Task Task { get; private set; }
        private bool isStarted;
        public bool Started { get => isStarted; set => SetProperty(ref isStarted, value); }
        private Action _onComplete;

        public void ExecuteTask(Task task, Action onComplete = null)
        {
            _onComplete = onComplete;
            Task = task;
            if (!task.IsCompleted)
                TaskCompletion = WatchTaskAsync(task);
        }

        public TaskWatcher()
        { }

        public Task TaskCompletion { get; private set; }

        private async Task WatchTaskAsync(Task task)
        {
            try
            {
                Started = true;
                await task;
            }
            finally
            {
                Started = false;
                OnPropertyChanged(nameof(Status));
                OnPropertyChanged(nameof(IsCompleted));
                OnPropertyChanged(nameof(IsNotCompleted));
                if (task.IsCanceled)
                {
                    OnPropertyChanged(nameof(IsCanceled));
                }
                else if (task.IsFaulted)
                {
                    OnPropertyChanged(nameof(IsFaulted));
                    OnPropertyChanged(nameof(Exception));
                    OnPropertyChanged(nameof(InnerException));
                    OnPropertyChanged(nameof(ErrorMessage));
                }
                else
                {
                    OnPropertyChanged(nameof(IsSuccessfullyCompleted));
                }
                _onComplete?.Invoke();
            }
        }

        public TaskStatus Status { get { return Task?.Status ?? TaskStatus.Created; } }
        public bool IsCompleted { get { return Task?.IsCompleted ?? true; } }
        public bool IsNotCompleted { get { return !Task?.IsCompleted ?? default; } }

        public bool IsSuccessfullyCompleted
        {
            get
            {
                return Task.Status ==
                    TaskStatus.RanToCompletion;
            }
        }

        public bool IsCanceled { get { return Task?.IsCanceled ?? default; } }
        public bool IsFaulted { get { return Task?.IsFaulted ?? default; } }
        public AggregateException Exception { get { return Task.Exception; } }

        public Exception InnerException
        {
            get
            {
                return Exception?.InnerException;
            }
        }

        public string ErrorMessage
        {
            get
            {
                return InnerException?.Message ?? Exception.Message;
            }
        }
    }
}