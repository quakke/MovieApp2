// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MovieApp.iOS.Views.Cells
{
	[Register ("DataCollectionViewCell")]
	partial class DataCollectionViewCell
	{
		[Outlet]
		UIKit.UILabel DescriptionLabel { get; set; }

		[Outlet]
		UIKit.UIImageView IconImageView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (IconImageView != null) {
				IconImageView.Dispose ();
				IconImageView = null;
			}

			if (DescriptionLabel != null) {
				DescriptionLabel.Dispose ();
				DescriptionLabel = null;
			}
		}
	}
}
