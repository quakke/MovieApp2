using System;
using MvvmCross.Core.ViewModels;

namespace MovieApp.Core.ViewModels
{
    public class StartViewModel : MvxViewModel
    {
        public void ShowDataView()
        {
            ShowViewModel<DataViewModel>();
        }
    }
}