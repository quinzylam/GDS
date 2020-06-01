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
        private readonly ISharedService _sharedService;
        private readonly IChapterService<Chapter> _chapterService;

        public ObservableCollection<Verse> Verses { get; set; }

        public ReadViewModel(ISharedService sharedService, IChapterService<Chapter> chapterService)
        {
            _sharedService = sharedService;
            _chapterService = chapterService;
        }

        public ICommand LoadCommand => new AsyncCommand(LoadAsync, Watcher);

        private async Task LoadAsync(object arg)
        {
            var chapter = await _chapterService.GetAsync(_sharedService.Version, _sharedService.BookCode);
            if (chapter.Verses.Any())
                Verses = new ObservableCollection<Verse>(chapter.Verses);
        }
    }
}