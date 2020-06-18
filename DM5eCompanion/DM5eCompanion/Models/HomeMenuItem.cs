using System;
using System.Collections.Generic;
using System.Text;

namespace DM5eCompanion.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        HP_Calculator
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
