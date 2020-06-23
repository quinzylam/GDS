using GDS.Core.Models;
using GDS.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDS.Mobile.Models
{
    public class BibleModel : BaseModel
    {
        private BibleVersion _code;
        private bool _isDownloading;
        private float _progress;

        public BibleVersion Code { get => _code; set => SetProperty(ref _code, value); }
        public string Title { get; set; }
        public int NumOfBooks { get; set; }
        public virtual ICollection<BibleBook> BibleBooks { get; set; }
        public float Progress { get => _progress; set => SetProperty(ref _progress, value); }
        public bool IsDownloading { get => _isDownloading; set => SetProperty(ref _isDownloading, value); }
    }
}