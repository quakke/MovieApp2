using System;

using Foundation;
using UIKit;

namespace MovieApp.iOS.Views.Cells
{
    public partial class DataCollectionViewCell : UICollectionViewCell
    {
        public static readonly NSString Key = new NSString("DataCollectionViewCell");
        public static readonly UINib Nib;

        static DataCollectionViewCell()
        {
            Nib = UINib.FromName("DataCollectionViewCell", NSBundle.MainBundle);
        }

        protected DataCollectionViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
    }
}
