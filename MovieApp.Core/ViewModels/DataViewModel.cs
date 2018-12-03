using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApp.API.Models;
using MovieApp.API.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform.Logging;
using System.Text;
using MovieApp.Core.Services;
using System.Collections.ObjectModel;
using System.Linq;
using MovieApp.Core.ViewModels;

namespace MovieApp.Core.ViewModels
{
    public class DataViewModel : MvxViewModel<IMvxBundle>, IDataViewModel
    {
        #region Fields

        private int countOfPages = 10;

        public bool isInternetAvailable = false;

        #endregion

        #region Commands

        private IMvxCommand _selectionChangedCommand;
        public IMvxCommand SelectionChangedCommand
        {
            get
            {
                return _selectionChangedCommand ?? (_selectionChangedCommand = new MvxCommand<DataItemVM>(OnMovieSelected));
            }
        }

        #endregion

        #region Properties

        private bool _loading;
        public virtual bool Loading
        {
            get
            {
                return _loading;
            }
            set
            {
                _loading = value;
                InvokeOnMainThread(() => RaisePropertyChanged(() => Loading));
            }
        }

        private List<DataItemVM> _movies;
        public List<DataItemVM> Movies
        {
            get
            {
                return _movies;
            }
            private set
            {
                SetProperty(ref _movies, value);
            }
        }

        #endregion

        #region Services

        protected new IHistoryDataService HistoryService => Mvx.Resolve<IHistoryDataService>();

        protected new IDataService DataService => Mvx.Resolve<IDataService>();

        #endregion

        #region Constructor

        public DataViewModel()
        {

        }

        #endregion

        #region Private

        //загрузка фильмов
        public async Task LoadContent()
        {
            Loading = false;

            try
            {
                // Если интернет есть, то делаем вот так
                if (isInternetAvailable)
                {
                    // TODO: конечно, по-хорошему, подгружать данные тогда, когда сроллим страницу. Но пока оставлю так
                    // переделаю, если останется время
                    List<MovieResponseItem> param = new List<MovieResponseItem>();
                    for (var i = 1; i <= countOfPages; i++)
                    {
                        var dataSource = await DataService.GetMovies(i);
                        param.AddRange(dataSource);
                    }

                    Movies = new List<DataItemVM>();

                    InvokeOnMainThread(() =>
                    {
                        foreach (var item in param)
                        {
                            StringBuilder desc = new StringBuilder();

                            desc.AppendLine("Название:").AppendLine(!String.IsNullOrWhiteSpace(item.title) ? item.title : "");
                            desc.AppendLine("Средняя оценка:").AppendLine(!String.IsNullOrWhiteSpace(item.vote_average) ? item.vote_average : "");
                            desc.AppendLine("Количество голосов:").AppendLine(!String.IsNullOrWhiteSpace(item.vote_count) ? item.vote_count : "");
                            desc.AppendLine("Популярность:").AppendLine(!String.IsNullOrWhiteSpace(item.popularity) ? item.popularity : "");
                            desc.AppendLine("Язык оригинала:").AppendLine(!String.IsNullOrWhiteSpace(item.original_language) ? item.original_language : "");
                            desc.AppendLine("Оригинальное название:").AppendLine(!String.IsNullOrWhiteSpace(item.original_title) ? item.original_title : "");
                            desc.AppendLine("Описание:").AppendLine(!String.IsNullOrWhiteSpace(item.overview) ? item.overview : "");
                            desc.AppendLine("Дата релиза:").AppendLine(!String.IsNullOrWhiteSpace(item.release_date) ? DateTime.Parse(item.release_date).ToString() : "");

                            var dataItem = new DataItemVM(
                                item.id,
                                item.title,
                                "https://image.tmdb.org/t/p/w200" + item.poster_path,
                                desc
                            );

                            Movies.Add(dataItem);

                            SaveInfoInHistory(dataItem);
                        }
                    });
                }
                else
                {
                    // Если интернета нет, то делаем вот так
                    var history = await LoadHistory();

                    Movies = new List<DataItemVM>();

                    InvokeOnMainThread(() =>
                    {
                        foreach (var item in history.ToList())
                        {
                            Movies.Add(new DataItemVM(item.Id, item.Title, item.PosterPath, item.Description));
                        }
                    });
                }
            }
            catch(Exception ex)
            {
                MvxTrace.Error(() => ex.StackTrace);
            }
            finally
            {
                Loading = true;
            }
        }

        private void OnMovieSelected(DataItemVM item)
        {
            ShowViewModel<DataDetailsViewModel, DataItemVM>(item);
        }

        #endregion

        #region History

        public Task SaveInfoInHistory(DataItemVM item)
        {
            return Task.Run(() =>
            {
                try
                {
                    HistoryService.InsertOrUpdate(item);
                }
                catch (Exception ex)
                {
                    MvxTrace.Trace(ex.StackTrace);
                }
            });
        }

        public Task ClearHistory()
        {
            return Task.Run(() =>
            {
                try
                {
                    HistoryService.DeleteAll();
                }
                catch (Exception ex)
                {
                    MvxTrace.Trace(ex.StackTrace);
                }
            });
        }

        public Task<ObservableCollection<IDataItemVM>> LoadHistory()
        {
            return Task.Run(() =>
            {
                ObservableCollection<IDataItemVM> dataSource = null;

                try
                {
                    var history = HistoryService.LoadAll().Reverse();

                    dataSource = new ObservableCollection<IDataItemVM>(history.ToList());
                }
                catch(Exception ex)
                {
                    MvxTrace.Trace(ex.StackTrace);
                }

                return dataSource;
            });
        }

        #endregion

        #region Protected

        #region Init

        public override void Prepare(IMvxBundle parameter)
        {
            //base.Prepare(parameter);

        }

        #endregion

        #endregion

        #region Public

        public async Task Initialize()
        {
            await LoadContent();

            return;
        }

        #endregion
    }
}
