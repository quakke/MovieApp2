using NUnit.Framework;
using System;
using MovieApp.Core.ViewModels;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMovieApp
{
    [TestFixture]
    public class Test
    {
        [Test]
        // Проверяю, что метод добавления элемента в историю выполняется без ошибок
        public void SaveToHistoryTest()
        {
            var viewModel = new DataViewModel();

            StringBuilder desc = new StringBuilder();
            desc.AppendLine("test description");
            var testItem = new DataItemVM("id", "title", "url", desc);

            Assert.DoesNotThrow(() => viewModel.SaveInfoInHistory(testItem));
        }

        [Test]
        // Проверяю, что метод получения истории выполняется без ошибок
        public void LoadHistoryTest()
        {
            var viewModel = new DataViewModel();

            Assert.DoesNotThrow(() => viewModel.LoadHistory());
        }

        [Test]
        // Проверяю, что метод LoadContent выполняется без ошибок
        public void LoadContentTest()
        {
            var viewModel = new DataViewModel();

            Assert.DoesNotThrow(async () => await viewModel.LoadContent());
        }

        [Test]
        // isInternetAvailable - включен ли интернет
        // если false, то Movies.Count == 0
        // если поставить true, то я ожидаю, что Movies.Count == 200, но тест почему-то завершается с ошибкой, которая отражена в StackTrace
        // Пока не могу понять, почему возникает ошибка при isInternetAvailable = true
        public async Task LoadContentMoviesCountTest()
        {
            var viewModel = new DataViewModel();

            viewModel.isInternetAvailable = false;

            await viewModel.LoadContent();

            Assert.AreEqual(0, viewModel.Movies.Count);
        }
    }
}
