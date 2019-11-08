using System;
using System.IO;

namespace GDS.Data.Mobile.Reader
{
    public static class ReaderGlobal
    {
        private const string BIBLES = "Bibles";

        public static string BiblePath { get => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalizedResources), BIBLES, BibleName); }
        public static string BibleName { get; set; } = "KJV.SQLite3";
    }
}