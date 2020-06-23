using AutoMapper;
using GDS.Core.Models;
using GDS.Core.Models.Enums;
using GDS.Core.Services;
using GDS.Mobile.Commands;
using GDS.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GDS.Mobile.ViewModels
{
    public class LibraryViewModel : BaseViewModel
    {
        private ObservableCollection<BibleModel> _bibles;
        private BibleModel _bible;
        private readonly IBibleService<Bible> _bibleService;
        private readonly IBibleBookService<BibleBook> _bibleBookService;
        private readonly IMapper _mapper;
        public BibleModel Bible { get => _bible; set => SetProperty(ref _bible, value); }

        public LibraryViewModel(IBibleService<Bible> bibleService, IBibleBookService<BibleBook> bibleBookService, IMapper mapper)
        {
            _bibleService = bibleService;
            _bibleBookService = bibleBookService;
            _mapper = mapper;
        }

        public ObservableCollection<BibleModel> Bibles { get => _bibles; set => SetProperty(ref _bibles, value); }
        public ICommand LoadCommand => new AsyncCommand(LoadAsync, Watcher);

        private async Task LoadAsync(object arg)
        {
            var bibles = await _bibleService.GetAsync(true);
            if (bibles.Any())
                Bibles = new ObservableCollection<BibleModel>(_mapper.Map<IEnumerable<BibleModel>>(bibles));
        }

        public ICommand DownloadCommand => new AsyncCommand(DownloadAsync, Watcher);

        private async Task DownloadAsync(object arg)
        {
            if (arg == null)
                return;
            var code = (BibleVersion)arg;
            var bible = await _bibleService.GetAsync(code);
            Bibles.FirstOrDefault(x => x.Code == code).IsDownloading = true;
            float i = 0f;

            foreach (var book in bible.BibleBooks)
            {
                if (await _bibleBookService.DownloadAsync(book.Version, book.BookCode ?? default))
                    i += 1;

                Bibles.FirstOrDefault(x => x.Code == code).Progress = (float)i / bible.NumOfBooks;
            }
            Bibles.FirstOrDefault(x => x.Code == code).IsDownloading = false;
        }
    }
}