using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Core.Data
{
    public interface IMobileContext
    {
        SQLite.SQLiteConnection Conn { get; set; }
        IConfigurationProvider MapConfig { get; }
    }
}