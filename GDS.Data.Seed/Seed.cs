using GDS.Core.Helpers;
using GDS.Core.Models;
using GDS.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GDS.Data.Seed
{
    public static class Seed
    {
        private static List<Book> books;
        private static List<Bible> bibles;

        public static List<Bible> Bibles
        {
            get
            {
                if (bibles == null)
                    SeedBibles();
                return bibles;
            }

            set => bibles = value;
        }

        public static List<Book> Books
        {
            get
            {
                if (books == null)
                    SeedBooks();
                return books;
            }
            set => books = value;
        }

        public static void SeedBooks()
        {
            if (books == null)
                books = new List<Book>();

            var section = Section.OldTestiment;
            AddBook(BookList.Genesis, "Gen", section);
            AddBook(BookList.Exodus, "Exod", section);
            AddBook(BookList.Leviticus, "Lev", section);
            AddBook(BookList.Numbers, "Num", section);
            AddBook(BookList.Deuteronomy, "Deut", section);
            AddBook(BookList.Joshua, "Josh", section);
            AddBook(BookList.Judges, "Judg", section);
            AddBook(BookList.Ruth, "Ruth", section);
            AddBook(BookList.ISamuel, "1 Sam", section);
            AddBook(BookList.IISamuel, "2 Sam", section);
            AddBook(BookList.IKings, "1 Kings", section);
            AddBook(BookList.IIKings, "2 Kings", section);
            AddBook(BookList.IChronicles, "1 Chron", section);
            AddBook(BookList.IIChronicles, "2 Chron", section);
            AddBook(BookList.Ezra, "Ezra", section);
            AddBook(BookList.Nehemiah, "Neh", section);
            AddBook(BookList.Esther, "Est", section);
            AddBook(BookList.Job, "Job", section);
            AddBook(BookList.Psalms, "Ps", section);
            AddBook(BookList.Proverbs, "Prov", section);
            AddBook(BookList.Ecclesiastes, "Eccles", section);
            AddBook(BookList.Songs, "Song", section);
            AddBook(BookList.Isaiah, "Isa", section);
            AddBook(BookList.Jeremiah, "Jer", section);
            AddBook(BookList.Lamentations, "Lam", section);
            AddBook(BookList.Ezekiel, "Ezek", section);
            AddBook(BookList.Daniel, "Dan", section);
            AddBook(BookList.Hosea, "Hos", section);
            AddBook(BookList.Joel, "Joel", section);
            AddBook(BookList.Amos, "Amos", section);
            AddBook(BookList.Obadiah, "Obad", section);
            AddBook(BookList.Jonah, "Jonah", section);
            AddBook(BookList.Micah, "Mic", section);
            AddBook(BookList.Nahum, "Nah", section);
            AddBook(BookList.Habakkuk, "Hab", section);
            AddBook(BookList.Zephaniah, "Zeph", section);
            AddBook(BookList.Haggai, "Hag", section);
            AddBook(BookList.Zechariah, "Zech", section);
            AddBook(BookList.Malachi, "Mal", section);

            section = Section.NewTestiment;
            AddBook(BookList.Matthew, "Matt", section);
            AddBook(BookList.Mark, "Mark", section);
            AddBook(BookList.Luke, "Luke", section);
            AddBook(BookList.John, "John", section);
            AddBook(BookList.Acts, "Acts", section);
            AddBook(BookList.Romans, "Rom", section);
            AddBook(BookList.ICorinthians, "1 Cor", section);
            AddBook(BookList.IICorinthians, "2 Cor", section);
            AddBook(BookList.Galatians, "Gal", section);
            AddBook(BookList.Ephesians, "Eph", section);
            AddBook(BookList.Philippians, "Phil", section);
            AddBook(BookList.Colossians, "Col", section);
            AddBook(BookList.IThessalonians, "1 Thess", section);
            AddBook(BookList.IIThessalonians, "2 Thess", section);
            AddBook(BookList.ITimothy, "1 Tim", section);
            AddBook(BookList.IITimothy, "2 Tim", section);
            AddBook(BookList.Titus, "Titus", section);
            AddBook(BookList.Philemon, "Philem", section);
            AddBook(BookList.Hebrews, "Heb", section);
            AddBook(BookList.James, "James", section);
            AddBook(BookList.IPeter, "1 Pet", section);
            AddBook(BookList.IIPeter, "2 Pet", section);
            AddBook(BookList.IJohn, "1 John", section);
            AddBook(BookList.IIJohn, "2 John", section);
            AddBook(BookList.IIIJohn, "3 John", section);
            AddBook(BookList.Jude, "Jude", section);
            AddBook(BookList.Revelation, "Rev", section);

            section = Section.Apochropha;
            AddBook(BookList.Tobit, "Tob", section);
            AddBook(BookList.Judith, "Jth", section);
            AddBook(BookList.AdditionsToEster, "Add Esth", section);
            AddBook(BookList.Wisdom, "Wisd", section);
            AddBook(BookList.Sirach, "Sir", section);
            AddBook(BookList.Ecclesiasticus, "Ecclus", section);
            AddBook(BookList.IBaruk, "Bar", section);
            AddBook(BookList.LetterOfJeremiah, "Ep Jer", section);
            AddBook(BookList.PrayerOfAzariah, "Azariah", section);
            AddBook(BookList.Susanna, "Sus", section);
            AddBook(BookList.Bel, "Bel", section);
            AddBook(BookList.IMaccabees, "1 Macc", section);
            AddBook(BookList.IIMaccabees, "2 Macc", section);
            AddBook(BookList.IIIIMaccabees, "3 Macc", section);
            AddBook(BookList.IIIIMaccabees, "4 Macc", section);
            AddBook(BookList.IEsdras, "1 Esd", section, "3 Ezra");
            AddBook(BookList.IIEsdras, "2 Esd", section, "4 Ezra");
            AddBook(BookList.PrayerOfManasseh, "Pr of Man", section);
            AddBook(BookList.AdditionalPsalm, "Add Psalm", section);

            section = Section.Extended;
            AddBook(BookList.Jubilees, "Jubi", section);
            AddBook(BookList.Enoch, "Enoc", section);
            AddBook(BookList.Jasher, "Jash", section);

            section = Section.Ethopian;
            AddBook(BookList.Josephus, "Josephus", section);
            AddBook(BookList.ReproofOfTegats, "Rep of Teg", section);
            AddBook(BookList.OrderOfZion, "Ord Zion", section);
            AddBook(BookList.Abtils, "Abtils", section);
            AddBook(BookList.Gitzew, "Gitzew", section);
            AddBook(BookList.ICovenant, "1 Cov", section);
            AddBook(BookList.IICovenant, "2 Cov", section);
            AddBook(BookList.Didascalia, "Dida", section);

            section = Section.LostBooks;
            AddBook(BookList.GospelOfMary, "Mar", section);
            AddBook(BookList.Protevangelion, "Prot", section);
            AddBook(BookList.IInfancyOfJesus, "1 Jes", section);
            AddBook(BookList.IIInfancyOfJesus, "2 Jes", section);
            AddBook(BookList.Abgarus, "Abag", section);
            AddBook(BookList.Nicodemus, "Nico", section);
            AddBook(BookList.ApostlesCreed, "Ap Creed", section);
            AddBook(BookList.Laodiceans, "Laod", section);
            AddBook(BookList.Seneca, "Sen", section);
            AddBook(BookList.ActsOfPaul, "Act Paul", section);
            AddBook(BookList.IClement, "1 Clem", section);
            AddBook(BookList.IIClement, "2 Clem", section);
            AddBook(BookList.Barnabas, "Barnabas", section);
            AddBook(BookList.IgnatiusToEphesians, "Ig Eph", section);
            AddBook(BookList.IgnatiusToMagnesians, "Ig Mag", section);
            AddBook(BookList.IgnatiusToTraliians, "Ig Tral", section);
            AddBook(BookList.IgnatiusToRomans, "Ig Rom", section);
            AddBook(BookList.IgnatiusToPhiladelphia, "Ig Phila", section);
            AddBook(BookList.IgnatiusToSmyrna, "Ig Smyr", section);
            AddBook(BookList.IgnatiusToPolycarp, "Ig Poly", section);
            AddBook(BookList.PolycarpToPhilippians, "Poly Phil", section);
            AddBook(BookList.Hermas, "Hermas", section);
            AddBook(BookList.Commandments, "Comm", section);
            AddBook(BookList.Similitudes, "Simil", section);
            AddBook(BookList.HerodAndPilate, "Her Pil", section);
            AddBook(BookList.Peter, "Peter", section);
            AddBook(BookList.IAdam, "1 Ada Eve", section);
            AddBook(BookList.IIAdam, "2 Ada Eve", section);
            AddBook(BookList.IIEnoch, "2 Enoc", section);
            AddBook(BookList.PsalmsOfSolomon, "Ps Sol", section);
            AddBook(BookList.Ode, "Ode", section);
            AddBook(BookList.Aristeas, "Aris", section);
            AddBook(BookList.Ahikar, "Ahik", section);
            AddBook(BookList.Patriarchs, "Tes Pat", section);
            AddBook(BookList.Reuben, "Tes Reu", section);
            AddBook(BookList.Simeon, "Tes Sim", section);
            AddBook(BookList.Levi, "Tes Lev", section);
            AddBook(BookList.Judah, "Tes Jud", section);
            AddBook(BookList.Issachar, "Tes Iss", section);
            AddBook(BookList.Zebulan, "Tes Zeb", section);
            AddBook(BookList.Dan, "Tes Dan", section);
            AddBook(BookList.Naphtali, "Tes Nap", section);
            AddBook(BookList.Gad, "Tes Gad", section);
            AddBook(BookList.Asher, "Tes Ash", section);
            AddBook(BookList.Joseph, "Tes Jos", section);
            AddBook(BookList.Benjamin, "Tes Ben", section);

            section = Section.Pseudepigrapha;
            AddBook(BookList.Abraham, "Abra", section);
            AddBook(BookList.Moses, "Mose", section);
            AddBook(BookList.MartyrdomIsaiah, "Mar Isa", section);
            AddBook(BookList.JosephAndAseneth, "Jos Ase", section);
            AddBook(BookList.AdamAndEve, "Ada Eve", section);
            AddBook(BookList.Prophets, "Proph", section);
            AddBook(BookList.Jacob, "Lad Jac", section);
            AddBook(BookList.JannesAndJambres, "Jan Jam", section);
            AddBook(BookList.Babylon, "Bab", section);
            AddBook(BookList.Rechabites, "Rech", section);
            AddBook(BookList.EldadAndModad, "Eld Mod", section);
            AddBook(BookList.JosephTheCarpenter, "Jos Car", section);
            AddBook(BookList.PrayerOfJoseph, "Pr Jos", section);
            AddBook(BookList.PrayerOfJacob, "Pr Jac", section);
            AddBook(BookList.VisionOfEzra, "Vis Ezra", section, "2 Ezra");
        }

        private static void AddBook(BookList book, string shortTitle, Section section, string ntitle = null)
        {
            if (!books.Any(x => x.Code == book))
                books.Add(new Book { Id = Guid.NewGuid(), BookNo = (int)book, Title = EnumHelper.GetDescription(book), ShortTitle = shortTitle, Section = section, NTitle = ntitle });

            var bk = books.FirstOrDefault(x => x.Code == book);

            if (!bk.Title.Equals(book.GetDescription()))
                bk.Title = book.GetDescription();

            if (!bk.ShortTitle.Equals(shortTitle))
                bk.ShortTitle = shortTitle;

            if (!bk.Section.Equals(section))
                bk.Section = section;

            if (!bk.NTitle.Equals(ntitle))
                bk.NTitle = ntitle;
        }

        public static void SeedBibles()
        {
            if (bibles == null)
                bibles = new List<Bible>();
            AddBible(BibleVersion.KJVAE, 84);
        }

        private static void AddBible(BibleVersion version, int numOfBooks)
        {
            if (!bibles.Any(x => x.Code == version))
                bibles.Add(new Bible { Id = Guid.NewGuid(), Code = version, Title = version.GetDescription() });

            var result = bibles.FirstOrDefault(x => x.Code == version);

            if (!result.Title.Equals(version.GetDescription()))
                result.Title = version.GetDescription();

            if (result.NumOfBooks != numOfBooks)
                result.NumOfBooks = numOfBooks;
        }
    }
}