using System;
using MovieApp.Core.ViewModels;
using MovieApp.iOS.Views.Cells;
using MovieApp.iOS.Views.ViewSources;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using UIKit;

namespace MovieApp.iOS.Views
{
    public partial class DataViewController : MvxViewController<IDataViewModel>
    {
        public DataViewController() : base("DataViewController", null)
        {

        }

        #region Initialize

        protected void InitializeControls()
        {
            Title = "Hello world";

            SetupCollectionView(MoviesCollectionView);
        }

        private void SetupCollectionView(UICollectionView moviesCollectionView)
        {
            // Я понимаю, что проще было использовать TableView
            // Но я сначала сделала CollectionView, а потом быстрее было сделать 1 столбец у CollectionView, чем переделать на TableView
            // В реальных задачах я себе такого, конечно, не позволяю :)
            var flowLayout = (moviesCollectionView.CollectionViewLayout as UICollectionViewFlowLayout);

            flowLayout.MinimumInteritemSpacing = 8;
            flowLayout.MinimumLineSpacing = 2;
            flowLayout.SectionInset = new UIEdgeInsets(2, 8, 2, 8);

            var width = ((float)UIScreen.MainScreen.Bounds.Width - flowLayout.SectionInset.Left - flowLayout.SectionInset.Right - (flowLayout.MinimumInteritemSpacing));
            var height = 60.0f;

            flowLayout.ItemSize = new CoreGraphics.CGSize(width, height);

            moviesCollectionView.RegisterNibForCell(DataCollectionViewCell.Nib, DataCollectionViewCell.Key);
        }

        #endregion

        #region Binding

        protected void BindControls()
        {
            var set = this.CreateBindingSet<DataViewController, IDataViewModel>();

            BindCollectionView(MoviesCollectionView, set);

            set.Apply();
        }

        private void BindCollectionView(UICollectionView moviesCollectionView, MvxFluentBindingDescriptionSet<DataViewController, IDataViewModel> set)
        {
            var dataSource = new MvvmCross.Binding.iOS.Views.MvxCollectionViewSource(moviesCollectionView, DataCollectionViewCell.Key);

            moviesCollectionView.Source = dataSource;

            set.Bind(dataSource).To(vm => vm.Movies);

            set.Bind(dataSource).For(ds => ds.SelectionChangedCommand).To(vm => vm.SelectionChangedCommand);

            //set.Bind(dataSource).For(dS => dS.SelectedIndex).To(vm => vm.CurrentPage);

            moviesCollectionView.ReloadData();
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

