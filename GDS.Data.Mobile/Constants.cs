using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GDS.Data.Mobile
{
    public static class Constants
    {
        public static string DBPath { get => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData); }
        public const string DB_EXT = ".sqlite";
    }
}