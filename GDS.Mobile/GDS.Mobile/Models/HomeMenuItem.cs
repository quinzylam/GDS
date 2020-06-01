using GDS.Mobile.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Mobile.Models
{
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }

        public bool HasSubMenu { get; set; }
    }
}