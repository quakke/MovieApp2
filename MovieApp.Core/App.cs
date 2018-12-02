using System;
using MovieApp.Core.ViewModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using MvvmCross.Plugins.Messenger;
using MovieApp.API.Services.Implementation;
using MovieApp.API.Services;

namespace MovieApp.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.RegisterSingleton<IDataService>(() => new DataService());

            RegisterAppStart<DataViewModel>();
        }
    }
}
