using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WorldEditor
{
    internal static class MenuHelper
    {
        public static void AddMenuItem( Menu menu, string menuPath, string menuName, string menuText, EventHandler handler )
        {
            var menuItem = FindMenuItem(menu, menuPath);
            if (menuItem == null)
                return;

        }

        public static MenuItem? FindMenuItem(Menu menu, string menuPath)
        {
            IEnumerable<MenuItem>? itemsSource = menu.ItemsSource as IEnumerable<MenuItem>;
            if (itemsSource == null)
                return null;
            string[] menuPathArray = menuPath.Split('/');
            IEnumerable<MenuItem>? menuItems = itemsSource;
            MenuItem? menuItemTemp = null;
            foreach (var menuPathNode in menuPathArray)
            {
                if ( menuItemTemp != null )
                {
                    menuItems = menuItemTemp.ItemsSource as IEnumerable<MenuItem>;
                    if (menuItems == null)
                        return null;
                    menuItemTemp = null;
                }

                foreach (var item in menuItems)
                {
                    if (item.Name == menuPathNode)
                    {
                        menuItemTemp = item;
                        break;
                    }
                }
                if (menuItemTemp == null)
                    return null;

            }
            return menuItemTemp;
        }
    }
}
