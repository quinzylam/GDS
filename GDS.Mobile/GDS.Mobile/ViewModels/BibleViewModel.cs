using GDS.Core.Data;
using GDS.Core.Models.Bibles;
using System.Collections.ObjectModel;

namespace GDS.Mobile.ViewModels
{
    public class BibleViewModel : BaseViewModel
    {
        private ObservableCollection<Verse> chapter;
        private Book book;

        public BibleViewModel()
        {
        }

        public Book Book { get => book; set => SetProperty(ref book, value); }
        public ObservableCollection<Verse> Chapter { get => chapter; set => SetProperty(ref chapter, value); }
    }
}