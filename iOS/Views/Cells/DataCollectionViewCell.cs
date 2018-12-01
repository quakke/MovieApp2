using System;

using Foundation;
using MovieApp.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace MovieApp.iOS.Views.Cells
{
    public partial class DataCollectionViewCell : MvxCollectionViewCell
    {
        public static readonly NSString Key = new NSString("DataCollectionViewCell");
        public static readonly UINib Nib = UINib.FromName("DataCollectionViewCell", NSBundle.MainBundle);

        public override bool Selected
        {
            get
            {
                return base.Selected;
            }
            set
            {
                base.Selected = value;

                if (DescriptionLabel != null)
                    DescriptionLabel.Highlighted = value;
            }
        }

        protected void InitializeControls()
        {
            SetupIcon(IconImageView);

            SetupDescription(DescriptionLabel);
        }

        private void SetupIcon(UIImageView iconImageView)
        {

        }

        protected void SetupDescription(UILabel description)
        {

        }

        protected void BindControls()
        {
            var set = this.CreateBindingSet<DataCollectionViewCell, IDataItemVM>();

            set.Bind(DescriptionLabel).To(vm => vm.Title);

            set.Apply();
        }

        static DataCollectionViewCell()
        {
            //Nib = UINib.FromName("DataCollectionViewCell", NSBundle.MainBundle);
        }

        protected DataCollectionViewCell(IntPtr handle) : base(handle)
        {
            this.BackgroundColor = UIColor.Blue;

            this.DelayBind(() => {
                InitializeControls();

                BindControls();
            });
        }

    }
}
