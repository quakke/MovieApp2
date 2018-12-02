using System;
using CoreGraphics;
using FFImageLoading.Cross;
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

        private MvxCachedImageView _imageControl;

        static DataCollectionViewCell()
        {

        }

        #region Initialize

        protected void InitializeControls()
        {
            SetupIcon(IconImageView);

            SetupDescription(DescriptionLabel);
        }

        private void SetupIcon(UIImageView iconImageView)
        {
            // TODO: исправить этот костыль
            // надо создать свой контрол и его добавить в xib
            // иначе при изменении размера все уедет
            // И вообще у меня тут картинка внутри картинки и это ужасно, надо исправить
            // Но пока нет времени
            _imageControl = new MvxCachedImageView(new CGRect(0, 0, 23, 40));

            _imageControl.BackgroundColor = UIColor.Red;
        }

        protected void SetupDescription(UILabel description)
        {

        }

        #endregion

        #region Binding

        protected void BindControls()
        {
            var set = this.CreateBindingSet<DataCollectionViewCell, IDataItemVM>();

            BindingDescriptionLabel(DescriptionLabel, set);

            BindingIconImage(IconImageView, set);

            set.Apply();
        }

        private void BindingDescriptionLabel(UILabel descriptionLabel, MvxFluentBindingDescriptionSet<DataCollectionViewCell, IDataItemVM> set)
        {
            set.Bind(descriptionLabel).To(vm => vm.Title);
        }

        private void BindingIconImage(UIImageView iconImageView, MvxFluentBindingDescriptionSet<DataCollectionViewCell, IDataItemVM> set)
        {
            set.Bind(_imageControl).For(v => v.ImagePath).To(vm => vm.PosterPath);

            iconImageView.AddSubview(_imageControl);
        }

        #endregion

        protected DataCollectionViewCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() => {
                InitializeControls();

                BindControls();
            });
        }
    }
}
