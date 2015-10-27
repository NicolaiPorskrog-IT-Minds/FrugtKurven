using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XLabs.Forms.Mvvm;
using XLabs.Forms.Services;
using XLabs.Ioc;
using XLabs.Platform.Services;

namespace FrugtKurven
{
    public class App : Application
    {
        public App()
        {
            //Register pages before initializing the first page
            RegisterPages();
            // The root page of your application
            MainPage = GetMainPage();
        }

        /// <summary>
        /// Get the main page
        /// </summary>
        /// <returns></returns>
        private static Page GetMainPage()
        {
            // Create the main page
            var mainNavigationPage = new NavigationPage((ContentPage)
                ViewFactory.CreatePage<FruitsViewModel, FruitsPage>());

            // Resolve the navigation
            Resolver.Resolve<IDependencyContainer>()
                .Register<INavigationService>(t => new NavigationService(mainNavigationPage.Navigation));

            return mainNavigationPage;
        }

        private void RegisterPages()
        {
            ViewFactory.Register<FruitsPage, FruitsViewModel>();
            ViewFactory.Register<AddFruitPage, AddFruitViewModel>();
            ViewFactory.Register<ViewFruitPage, ViewFruitViewModel>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
