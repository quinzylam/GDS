using GDS.API.Client;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GDS.UI.ViewModels
{
    public class BibleViewModel
    {
        private readonly BibleClient _client;
        private ICollection<Book> _books;

        public BibleViewModel()
        {
            _client = new BibleClient("https://localhost:44399/", new System.Net.Http.HttpClient());
            _books = _client.GetBooksAsync().Result;
        }

        public int BookNo { get; set; }
        public string Translation { get; set; }

        public List<SelectListItem> Books { get => _books.Select(b => new SelectListItem { Text = b.LongName, Value = b.BookNumber.ToString() }).ToList(); }

        public async Task<Book> GetBook(int bookNo)
        {
            return await _client.GetBookAsync(bookNo);
        }
    }
}