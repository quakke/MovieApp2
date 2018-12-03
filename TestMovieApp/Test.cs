using NUnit.Framework;
using System;
using MovieApp.Core.ViewModels;
using System.Linq;
using System.Text;

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
    }
}
