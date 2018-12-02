using System;
using MovieApp.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using UIKit;
//using FFImageLoading.MvvmCross.Sample.Core;
using FFImageLoading.Cross;
using System.Linq.Expressions;
using CoreGraphics;

namespace MovieApp.iOS.Views
{
    public partial class DataDetailsViewController : MvxViewController<IDataDetailsViewModel>
    {
        private MvxCachedImageView _imageControl;

        public DataDetailsViewController() : base("DataDetailsViewController", null)
        {

        }

        #region Initialize

        protected void InitializeControls()
        {
            Title = "Описание";
            
            SetupImageView(DescriptionImageView);

            SetupDescriptionLabel(DescriptionLabel);
        }

        private void SetupImageView(UIImageView descriptionImageView)
        {
            // TODO: исправить этот костыль
            // надо создать свой контрол и его добавить в xib
            // иначе при изменении размера все уедет
            // И вообще у меня тут картинка внутри картинки и это ужасно, надо исправить
            // Но пока нет времени
            _imageControl = new MvxCachedImageView(new CGRect(0, 0, 200, 300));

            _imageControl.BackgroundColor = UIColor.Red;
        }

        private void SetupDescriptionLabel(UILabel descriptionLabel)
        {

        }

        #endregion

        #region Binding

        protected void BindControls()
        {
            var set = this.CreateBindingSet<DataDetailsViewController, IDataDetailsViewModel>();

            BindDescriptionImageView(DescriptionImageView, set);

            BindDescriptionLabel(DescriptionLabel, set);

            set.Apply();
        }

        private void BindDescriptionImageView(UIImageView descriptionImageView, MvxFluentBindingDescriptionSet<DataDetailsViewController, IDataDetailsViewModel> set)
        {
            set.Bind(_imageControl).For(v => v.ImagePath).To(vm => vm.MovieItem.PosterPath);

            descriptionImageView.AddSubview(_imageControl);
        }

        private void BindDescriptionLabel(UILabel descriptionLabel, MvxFluentBindingDescriptionSet<DataDetailsViewController, IDataDetailsViewModel> set)
        {
            set.Bind(descriptionLabel).To(vm => vm.MovieItem.Description);
        }

        #endregion

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            InitializeControls();

            BindControls();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }
    }
}

