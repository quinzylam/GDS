using GDS.Core.Models;
using GDS.Core.Models.Enums;
using GDS.Core.Services;
using GDS.Mobile.Commands;
using GDS.Mobile.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GDS.Mobile.ViewModels
{
    public class BookSelectViewModel : BaseViewModel
    {
        private ObservableCollection<Book> books;
        private IEnumerable<ObservableGroupCollection<string, Book>> sections;

        public ObservableCollection<Book> Books { get => books; set => SetProperty(ref books, value); }
        public IEnumerable<ObservableGroupCollection<string, Book>> Sections { get => sections; set => SetProperty(ref sections, value); }

        public BookSelectViewModel()
        {
        }

        public ICommand LoadCommand => new AsyncCommand(LoadAsync, Watcher);
        public ICommand SelectCommand => new RelayCommand(Select);

        private void Select(object obj)
        {
            if (obj == null)
                return;
            var book = (Book)obj;
            SharedService.Book = book;
            if (book.BibleBooks.Any())
                SharedService.Chapter = book.BibleBooks.FirstOrDefault(x => x.Version == SharedService.Version);
        }

        private async Task LoadAsync(object arg)
        {
            var books = await SharedService.GetCurrentBooks();
            if (books.Any())
            {
                Books = new ObservableCollection<Book>(books);
                Sections = Books.OrderBy(x => x.Section).ThenBy(x => x.Code).GroupBy(g => g.Section.ToString()).Select(s => new ObservableGroupCollection<string, Book>(s)).ToList();
            }
        }
    }
}