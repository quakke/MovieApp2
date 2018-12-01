// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MovieApp.iOS.Views
{
	[Register ("DataDetailsViewController")]
	partial class DataDetailsViewController
	{
		[Outlet]
		UIKit.UIImageView DescriptionImageView { get; set; }

		[Outlet]
		UIKit.UILabel DescriptionLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (DescriptionImageView != null) {
				DescriptionImageView.Dispose ();
				DescriptionImageView = null;
			}

			if (DescriptionLabel != null) {
				DescriptionLabel.Dispose ();
				DescriptionLabel = null;
			}
		}
	}
}
