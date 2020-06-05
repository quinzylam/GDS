using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Data.Mobile
{
    public interface IMobileContext
    {
        SQLite.SQLiteAsyncConnection Conn { get; set; }
        IConfigurationProvider MapConfig { get; }
    }
}