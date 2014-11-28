/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:wallabag"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;

namespace wallabag.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            var navigationService = this.CreateNavigationService();
            SimpleIoc.Default.Register<INavigationService>(() => navigationService);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ItemPageViewModel>();
        }

        private INavigationService CreateNavigationService()
        {
            var navigationService = new NavigationService();
            navigationService.Configure("ItemWP", System.Type.GetType("wallabag.WindowsPhone.Views.ItemPage"));
            // navigationService.Configure("key1", typeof(OtherPage1));
            // navigationService.Configure("key2", typeof(OtherPage2));

            return navigationService;
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }

        // -----------------------------------
        public MainViewModel Main { get { return ServiceLocator.Current.GetInstance<MainViewModel>(); } }
        public ItemPageViewModel ItemPage { get { return ServiceLocator.Current.GetInstance<ItemPageViewModel>(); } }
    }
}