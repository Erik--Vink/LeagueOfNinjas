using GalaSoft.MvvmLight;
using LeagueOfNinjas.Model.Interfaces;
using LeagueOfNinjas.Model.Models;
using LeagueOfNinjas.View.ViewModels.DomainViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinjas.ViewModels
{
    public class CollectionViewModel : ViewModelBase
    {
        public IDataAccessProvider DataAccessProvider { get; private set; }

        public CollectionViewModel(IDataAccessProvider dap)
        {
            DataAccessProvider = dap;
            RefreshCollections();
        }

        public void RefreshCollections()
        {
            AllCategories = new ObservableCollection<CategoryViewModel>(DataAccessProvider.GetAll<Category>().Select(src => new CategoryViewModel(src)));
            AllEquips = new ObservableCollection<EquipViewModel>(DataAccessProvider.GetAll<Equip>().Select(src => new EquipViewModel(src)));   
        }

        private ObservableCollection<CategoryViewModel> _allCategories;
        public ObservableCollection<CategoryViewModel> AllCategories
        {
            get { return _allCategories; }
            set
            {
                _allCategories = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<EquipViewModel> _allEquips;
        public ObservableCollection<EquipViewModel> AllEquips
        {
            get { return _allEquips; }
            set
            {
                _allEquips = value;
                RaisePropertyChanged();
            }
        }
    }
}
