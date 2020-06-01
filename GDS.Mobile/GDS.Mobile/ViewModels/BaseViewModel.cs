using GDS.Core.Logging;
using GDS.Mobile.Commands;
using GDS.Mobile.Factories;
using GDS.Mobile.Models;
using GDS.Mobile.Views;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace GDS.Mobile.ViewModels
{
    public class BaseViewModel : BaseModel
    {
        private string errorMsg;
        private string info;
        private bool isBusy = false;
        private string status;
        private string title = string.Empty;

        public BaseViewModel()
        {
            Logger = AppFactory.GetInstance<ILogger>();
            Watcher = new TaskWatcher();
            Watcher.PropertyChanged += Watcher_PropertyChanged;
        }

        public string ErrorMsg
        {
            get => errorMsg; set
            {
                SetProperty(ref errorMsg, value);
            }
        }

        public bool HasError { get => !string.IsNullOrEmpty(ErrorMsg); }
        public bool HasInfo { get => !string.IsNullOrEmpty(Info); }
        public bool HasStatus { get => !string.IsNullOrEmpty(Status); }

        public string Info
        {
            get => info; set
            {
                SetProperty(ref info, value);
            }
        }

        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        public string Status
        {
            get => status; set
            {
                SetProperty(ref status, value);
            }
        }

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public TaskWatcher Watcher { get; }
        public ILogger Logger { get; }

        internal bool HandleError(string message = null, Exception ex = null)
        {
            if (message == null && ex == null)
                throw new ArgumentException("Please pass at least one argument");
            ErrorMsg = string.Concat(message, (ex?.Message != null && message != ex?.Message) ? string.Concat(" ", ex?.Message) : "");
            if (ex != null)
                Logger.Error(message, ex);

            return false;
        }

        private void Start(string status = null)
        {
            ErrorMsg = string.Empty;
            Status = status ?? Constants.IS_BUSY_STATUS;
            IsBusy = true;
        }

        private void Stop()
        {
            IsBusy = false;
            Status = string.Empty;
        }

        private void Watcher_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(Watcher.Started):
                    if (Watcher.Started)
                        Start();
                    else
                        Stop();
                    break;

                case nameof(Watcher.IsCompleted):
                    if (!Watcher.IsSuccessfullyCompleted)
                        HandleError(Watcher.ErrorMessage, Watcher.InnerException);
                    break;
            }
        }
    }
}