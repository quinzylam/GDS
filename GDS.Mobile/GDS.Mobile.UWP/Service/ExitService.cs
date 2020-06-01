using GDS.Mobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Mobile.UWP.Service
{
    public class ExitService : IExitService
    {
        public void CloseApplication()
        {
            Windows.UI.Xaml.Application.Current.Exit();
        }
    }
}