using System;
using MvvmCross.Core.ViewModels;

namespace MovieApp.Core.ViewModels
{
    public interface IDataDetailsViewModel : IMvxViewModel<IMvxBundle>, IMvxNotifyPropertyChanged
    {
        DataItemVM MovieItem { get; }
    }
}
