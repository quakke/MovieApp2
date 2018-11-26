using System;
using MovieApp.Core.ViewModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using UIKit;

namespace MovieApp.iOS.Views
{
    public partial class DataViewController : MvxViewController<DataViewModel>
    {
        public DataViewController() : base("DataViewController", null)
        {
            Title = "Hello world";
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

