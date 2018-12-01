using System;
using MovieApp.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;

namespace MovieApp.iOS.Views
{
    public partial class DataDetailsViewController : MvxViewController<IDataDetailsViewModel>
    {
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

        private void SetupDescriptionLabel(UILabel descriptionLabel)
        {

        }

        private void SetupImageView(UIImageView descriptionImageView)
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

        private void BindDescriptionLabel(UILabel descriptionLabel, MvxFluentBindingDescriptionSet<DataDetailsViewController, IDataDetailsViewModel> set)
        {
            set.Bind(descriptionLabel).To(vm => vm.MovieItem.Description);
        }

        private void BindDescriptionImageView(UIImageView descriptionImageView, MvxFluentBindingDescriptionSet<DataDetailsViewController, IDataDetailsViewModel> set)
        {
            //throw new NotImplementedException();
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
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

