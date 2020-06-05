using GDS.Core.Services;
using GDS.Mobile.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace GDS.Mobile.ViewModels
{
    public class ChapterSelectViewModel : BaseViewModel
    {
        private ObservableCollection<int> chapters;

        public ChapterSelectViewModel()
        {
        }

        public ObservableCollection<int> Chapters { get => chapters; set => SetProperty(ref chapters, value); }
        public ICommand LoadCommand => new RelayCommand(Load);
        public ICommand SelectCommand => new RelayCommand(Select);

        private void Select(object obj)
        {
            if (obj == null)
                return;

            SharedService.ChapterNo = (int)obj;
        }

        private void Load(object obj)
        {
            if (obj == null)
                return;
            var chapterNo = (int)obj;
            var chapters = new List<int>();
            for (int i = 1; i <= chapterNo; i++)
                chapters.Add(i);
            Chapters = new ObservableCollection<int>(chapters);
        }
    }
}