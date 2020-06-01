using GDS.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Core.Services
{
    public interface IVerseService<T>
    {
        IEnumerable<T> Get(BibleVersion bible, BookList book);
    }
}