using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MovieApp.API.Services;
using MovieApp.API.Services.Implementation;

namespace MovieApp.API
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
           Mvx.RegisterType<IDataService>(() => new DataService());
        }
    }
}
