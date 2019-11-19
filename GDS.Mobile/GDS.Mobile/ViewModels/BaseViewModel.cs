using System;

using Xamarin.Forms;

using GDS.Mobile.Models;
using GDS.Core.Data;
using GDS.Mobile.Factories;
using GDS.Mobile.Views;
using GDS.Mobile.Commands;
using GDS.Core.Services;
using GDS.Resources;

namespace GDS.Mobile.ViewModels
{
    public class BaseViewModel : BaseModel
    {
        private string errorMsg = string.Empty;
        private bool isBusy = false;
        private bool hasError = false;
        private bool hasStatus = false;
        private string statusMsg = string.Empty;
        private string title = string.Empty;

        public BaseViewModel()
        {
            Watcher = new TaskWatcher();
            Watcher.PropertyChanged += Watcher_PropertyChanged;
            PropertyChanged += BaseViewModel_PropertyChanged;
        }

        private void BaseViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IsSynchronizing))
                if (IsSynchronizing)
                    Start(GDSResource.BusyStatus);
                else
                    Stop();
            if (e.PropertyName == nameof(StatusMsg))
                HasStatus = !string.IsNullOrEmpty(StatusMsg);
            if (e.PropertyName == nameof(ErrorMsg))
                HasError = !string.IsNullOrEmpty(ErrorMsg);
        }

        private string originalStatus;
        private bool isSynchronizing = false;

        private void Watcher_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
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
                        HandleError(Watcher.ErrorMessage, Watcher.Exception);
                    break;
            }
        }

        private void Start(string status = null)
        {
            originalStatus = StatusMsg;
            ErrorMsg = string.Empty;
            StatusMsg = status ?? GDSResource.BusyStatus;
            IsBusy = true;
        }

        private void Stop()
        {
            IsBusy = false;
            StatusMsg = (originalStatus == GDSResource.BusyStatus || originalStatus == GDSResource.SyncStatus) ? string.Empty : originalStatus;
        }

        public bool IsSynchronizing { get => isSynchronizing; set => SetProperty(ref isSynchronizing, value); }

        #region Properties

        public bool CanContinue { get => !IsBusy && string.IsNullOrEmpty(errorMsg); }
        public bool HasStatus { get => hasStatus; set => SetProperty(ref hasStatus, value); }
        public bool HasError { get => hasError; set => SetProperty(ref hasError, value); }

        public string ErrorMsg
        {
            get => errorMsg; set
            {
                SetProperty(ref errorMsg, value);
            }
        }

        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        public string StatusMsg
        {
            get => statusMsg; set
            {
                SetProperty(ref statusMsg, value);
            }
        }

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public TaskWatcher Watcher { get; }

        #endregion Properties

        #region Commands

        internal bool HandleError(string message, Exception ex = null)
        {
            ErrorMsg = string.Concat(message, " ", ex?.Message).Trim();
            //if (ex != null)
            //    Logger.Error(message, ex);
            return false;
        }

        #endregion Commands
    }
}