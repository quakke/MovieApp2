﻿using System;
using MovieApp.Core.ViewModels;
using MvvmCross.iOS.Views;
using UIKit;

namespace MovieApp.iOS.Views
{
    public partial class DataDetailsViewController : MvxViewController<IDataDetailsViewModel>
    {
        public DataDetailsViewController() : base("DataDetailsViewController", null)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

