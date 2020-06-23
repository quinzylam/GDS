using GDS.Core.Models;
using GDS.Core.Services;
using GDS.Mobile.Commands;
using GDS.Mobile.Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GDS.Mobile.ViewModels
{
    public class ReadViewModel : BaseViewModel
    {
        private readonly IVerseService<Verse> _verseService;
        private ObservableCollection<Verse> _verses;
        private string _reference;

        public string Reference { get => _reference; set => SetProperty(ref _reference, value); }

        public ObservableCollection<Verse> Verses { get => _verses; set => SetProperty(ref _verses, value); }

        public ReadViewModel(IVerseService<Verse> verseService)
        {
            _verseService = verseService;
        }

        public ReadViewModel()
        {
        }

        public ICommand LoadCommand => new AsyncCommand(LoadAsync, Watcher);
        public ICommand SelectCommand => new RelayCommand(Select);

        private void Select(object arg)
        {
            OnNavigate("Select");
        }

        private async Task LoadAsync(object arg)
        {
            Title = await SharedService.GetTitleAsync();
            Reference = await SharedService.GetReferenceAsync();
            var verses = await _verseService.GetAsync(SharedService.Version, SharedService.BookCode, SharedService.ChapterNo);
            if (verses.Any())
                Verses = new ObservableCollection<Verse>(verses);
        }
    }
}