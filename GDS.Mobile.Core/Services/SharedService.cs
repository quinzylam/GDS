using GDS.Core.Models;
using GDS.Core.Models.Enums;
using GDS.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Mobile.Core.Services
{
    public class SharedService : ISharedService
    {
        public Bible Bible { get; set; }
        public BibleVersion Version { get => Bible?.Code ?? BibleVersion.KJVAE; }
        public Book Book { get; set; }
        public BookList BookCode { get => Book?.Code ?? BookList.Genesis; }
        public Chapter Chapter { get; set; }
        public int ChapterNo { get; set; } = 1;
        public Verse Verse { get; set; }
        public int Position { get => Verse?.Position ?? 1; }
    }
}