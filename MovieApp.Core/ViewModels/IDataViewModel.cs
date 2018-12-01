using System;
using MvvmCross.Core.ViewModels;
using MovieApp.API.Models;
using System.Collections.Generic;

namespace MovieApp.Core.ViewModels
{
    public interface IDataViewModel : IMvxViewModel<IMvxBundle>, IMvxNotifyPropertyChanged
    {
        IMvxCommand SelectionChangedCommand { get; }

        List<DataItemVM> Movies { get; }
    }
}
