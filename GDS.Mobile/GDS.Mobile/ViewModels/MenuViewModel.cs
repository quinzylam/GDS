using GDS.Core.Helpers;
using GDS.Mobile.Commands;
using GDS.Mobile.Models;
using GDS.Mobile.Models.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GDS.Mobile.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        private ObservableCollection<HomeMenuItem> menuItems;
        public ObservableCollection<HomeMenuItem> MenuItems { get => menuItems; set => SetProperty(ref menuItems, value); }

        public MenuViewModel() : base()
        {
            SetMenu(MenuItemType.Read);
        }

        public ICommand NavigateToCommand => new AsyncCommand(NavigateTo, Watcher);

        public void SetMenu(MenuItemType menu)
        {
            switch (menu)
            {
                default:
                    MenuItems = SetMainMenu();
                    break;
            }
        }

        private HomeMenuItem GetMenuItem(MenuItemType menuItem, bool hasSub = false)
        {
            return new HomeMenuItem { Id = menuItem, Title = EnumHelper.GetDescription(menuItem), HasSubMenu = hasSub };
        }

        private ObservableCollection<HomeMenuItem> SetMainMenu()
        {
            return new ObservableCollection<HomeMenuItem>
            {
                GetMenuItem(MenuItemType.Read),
                GetMenuItem(MenuItemType.Logout),
                GetMenuItem(MenuItemType.Exit),
            };
        }

        private async Task NavigateTo(object parameter)
        {
            var id = (MenuItemType)parameter;
            RootPage.PrevMenu = RootPage.CurrentMenu;
            RootPage.CurrentMenu = id;
            var item = MenuItems.FirstOrDefault(m => m.Id == id);
            if (item.HasSubMenu)
            {
                SetMenu(id);
                return;
            }

            await RootPage.NavigateFromMenu((int)id);
        }
    }
}