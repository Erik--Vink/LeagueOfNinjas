using GalaSoft.MvvmLight;
using LeagueOfNinjas.Model.Interfaces;
using LeagueOfNinjas.View.ViewModels.DomainViewModels;
using LeagueOfNinjas.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinjas.View.ViewModels
{
    public class ShopViewModel : ViewModelBase
    {
        public IDataAccessProvider DataAccessProvider { get; set; }
        public CollectionViewModel CollectionViewModel { get; set; }

        public ShopViewModel(IDataAccessProvider dap, CollectionViewModel cvm)
        {
            DataAccessProvider = dap;
            CollectionViewModel = cvm;

            CollectionViewModel.RefreshCollections();
        }

        //public ShopViewModel()
        //{

        //}

        #region MainWindow

        #region Collections

        // Alle Equips op basis van 'AllCategories' > Vernieuwen wanneer 'SelectedCategory' veranderd
        private ObservableCollection<EquipViewModel> _availableEquips;

        public ObservableCollection<EquipViewModel> AvailableEquips
        {
            get { return _availableEquips; }
            set
            {
                _availableEquips = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Properties

        private CategoryViewModel _selectedCategory;

        public CategoryViewModel SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                SelectedEquip = null;
                AvailableEquips = SetAvailableEquips();
                RaisePropertyChanged();
                RaisePropertyChanged(() => AvailableEquips);
            }
        }

        private EquipViewModel _selectedEquip;
        public EquipViewModel SelectedEquip
        {
            get { return _selectedEquip; }
            set
            {
                _selectedEquip = value;
                RaisePropertyChanged();
                RaisePropertyChanged(() => SelectedEquipDetails);
                RaisePropertyChanged(() => IsEquipDetailsSelected);
            }
        }

        public EquipViewModel SelectedEquipDetails
        {
            get
            {
                return (SelectedCategory != null)                
                    ? CollectionViewModel.AllEquips
                        .Where(src => src.CategoryName.Equals(SelectedCategory.CategoryName))
                            .SingleOrDefault(src => src.EquipName.Equals(SelectedEquip.EquipName))
                    : null;
            }
        }

        public bool IsEquipDetailsSelected
        {
            get { return SelectedEquipDetails != null; }
        }

        #endregion

        #endregion

        #region Methods

        public ObservableCollection<EquipViewModel> SetAvailableEquips()
        {
            return (SelectedCategory != null)
                ? new ObservableCollection<EquipViewModel>(
                    CollectionViewModel.AllEquips
                        .Where(src => src.ToEntity().CategoryName.Equals(SelectedCategory.CategoryName)))
                : new ObservableCollection<EquipViewModel>();
        }

        #endregion

    }
}
