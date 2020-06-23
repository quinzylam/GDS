using GDS.Core.Logging;
using GDS.Core.Services;
using GDS.Mobile.Commands;
using GDS.Mobile.Core;
using GDS.Mobile.Events;
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
        private string _errorMsg;
        private string _info;
        private bool _isBusy = false;
        private string _status;
        private string _title = string.Empty;
        private bool _isDownloading;

        public BaseViewModel()
        {
            _sharedService = AppFactory.GetInstance<ISharedService>();
            Logger = AppFactory.GetInstance<ILogger>();
            Watcher = new TaskWatcher();
            Watcher.PropertyChanged += Watcher_PropertyChanged;
        }

        public string ErrorMsg
        {
            get => _errorMsg; set
            {
                SetProperty(ref _errorMsg, value);
            }
        }

        public bool HasError { get => !string.IsNullOrEmpty(ErrorMsg); }
        public bool HasInfo { get => !string.IsNullOrEmpty(Info); }
        public bool HasStatus { get => !string.IsNullOrEmpty(Status); }
        public bool IsDownloading { get => _isDownloading; set => SetProperty(ref _isDownloading, value); }
        public float Progress { get; set; }

        public string Info
        {
            get => _info; set
            {
                SetProperty(ref _info, value);
            }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        public string Status
        {
            get => _status; set
            {
                SetProperty(ref _status, value);
            }
        }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public TaskWatcher Watcher { get; }

        private readonly ISharedService _sharedService;

        public ILogger Logger { get; }

        public ISharedService SharedService => _sharedService;

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

        public delegate void OnNavigateEventHandler(object sender, NavigateEventArgs e);

        public event OnNavigateEventHandler Navigate;

        public delegate void OnBackEventHandler(object sender, EventArgs e);

        public event OnBackEventHandler Back;

        public void OnBack()
        {
            Back?.Invoke(this, new EventArgs());
        }

        public void OnNavigate(string focus)
        {
            Navigate?.Invoke(this, new NavigateEventArgs() { Focus = focus });
        }
    }
}