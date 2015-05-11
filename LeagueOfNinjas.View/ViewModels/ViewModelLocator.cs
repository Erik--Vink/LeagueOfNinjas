/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:LeagueOfNinjas"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using LeagueOfNinjas.Model.DataAccess;
using LeagueOfNinjas.Model.Interfaces;
using LeagueOfNinjas.View.ViewModels;
using LeagueOfNinjas.ViewModels;
using Microsoft.Practices.ServiceLocation;

namespace LeagueOfNinjas.View.ViewModels
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
            var dsl = DataServiceLocator.Instance;
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            //if (viewmodelbase.isindesignmodestatic)
            //{
            //    // create design time view services and models
            //    simpleioc.default.register<idataservice, designdataservice>();
            //}
            //else
            //{
            //    // create run time view services and models
            //    simpleioc.default.register<idataservice, dataservice>();
            //}

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<IDataAccessProvider>(() => dsl.DataAccessProvider);
            SimpleIoc.Default.Register<CollectionViewModel>();
            SimpleIoc.Default.Register<ShopViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public ShopViewModel Shop
        {
            get { return ServiceLocator.Current.GetInstance<ShopViewModel>(); }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}