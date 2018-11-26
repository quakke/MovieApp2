using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MovieApp.API.Services.Fake;
using MovieApp.API.Services;
using MovieApp.API.Services.Implementation;

namespace MovieApp.API
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            #if DEBUG
                Mvx.RegisterType<IDataService>(() => new FakeDataService());
            #else
               Mvx.RegisterType<IDataService>(() => new DataService());
            #endif
        }
    }
}
