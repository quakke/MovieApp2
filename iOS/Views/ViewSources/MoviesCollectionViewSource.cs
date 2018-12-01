using System;
using CoreGraphics;
using Foundation;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace MovieApp.iOS.Views.ViewSources
{
    public class MoviesCollectionViewSource : MvxCollectionViewSource
    {
        public MoviesCollectionViewSource(UICollectionView movies, NSString key)
            : base(movies, key)
        {

        }
    }
}
