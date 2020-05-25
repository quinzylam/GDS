using GDS.Bible.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;

namespace GDS.Bible.ViewModels
{
    public class BibleViewModel
    {
        public Translation Translation { get; set; }
        public ObservableCollection<Translation> Translations { get; set; }
        public Book Book { get; set; }
        public ObservableCollection<Book> Books { get; set; }
        public Chapter Chapter { get; set; }
        public ObservableCollection<Chapter> Chapters { get; set; }
        public Verse Verse { get; set; }
        public ObservableCollection<Verse> Verses { get; set; }

        public string Reference { get 
            { 
                return string.Concat(
                    BookName, 
                    ChapterNo != null?string.Concat(" ", ChapterNo):"", 
                    FromVerse!=null?string.Concat(":", FromVerse,ToVerse!=null?string.Concat("-", ToVerse):""):"", 
                    !string.IsNullOrEmpty(TranslationCode)?string.Concat(" ",TranslationCode):""
                    ); 
            } 
            set
            {
                string rem = value.Trim();
                if (!string.IsNullOrEmpty(rem))
                {
                    
                    if (rem.Contains(" "))
                    
                    {
                        var items = rem.Split(" ");
                        BookName = items[0];
                        if (items.Length > 2)
                        {
                            TranslationCode = items[2];
                        }
                        rem = items[1];
                        Regex regex = new Regex("[A-Z]");
                        if (!regex.IsMatch(rem))
                        {
                            if (rem.Contains(":"))
                            {
                                ChapterNo = int.Parse(rem.Split(":")[0].Trim());
                                rem = rem.Split(":")[1];
                                
                                if (rem.Contains("-"))
                                {
                                    FromVerse = int.Parse(rem.Split("-")[0].Trim());
                                    rem = rem.Split("-")[1];
                                    ToVerse = int.Parse(rem);
                                }
                                else
                                    FromVerse = int.Parse(rem);
                            }
                            else
                                ChapterNo = int.Parse(rem);

                            
                        }
                        else
                            translationCode = rem;
                        
                    }
                    else
                        translationCode = rem;
                }
                
            
            } 
        }

        public string BookName { get => Book?.ShortTitle??bookName; set => bookName = value; }
        public string TranslationCode { get => Translation?.Code.ToString()??translationCode; set => translationCode = value; }
        public int? ChapterNo { get => Chapter?.ChapterNo??chapterNo; set => chapterNo = value; }
        public int? FromVerse { get => Verse?.VerseNo??fromVerse; set => fromVerse = value; }
        public int? ToVerse { get; set; }

        private string bookName;
        private string translationCode;
        private int? chapterNo;
        private int? fromVerse;
    }
}
