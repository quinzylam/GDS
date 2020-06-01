using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GDS.Mobile.Services;

namespace GDS.Mobile.Droid.Services
{
    public class ExitService : IExitService
    {
        public void CloseApplication()
        {
            var activity = (Activity)Android.App.Application.Context;
            activity.FinishAffinity();
        }
    }
}