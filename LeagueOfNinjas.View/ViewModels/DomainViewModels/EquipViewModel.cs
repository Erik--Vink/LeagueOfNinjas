using GalaSoft.MvvmLight;
using LeagueOfNinjas.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinjas.View.ViewModels.DomainViewModels
{
    public class EquipViewModel : ViewModelBase
    {

        public EquipViewModel() { _equip = new Equip(); }

        public EquipViewModel(Equip equip) { _equip = equip ?? new Equip(); }

        private readonly Equip _equip;

        public string EquipName
        {
            get { return _equip.EquipName; }
            set
            {
                _equip.EquipName = value;
                RaisePropertyChanged();              
            }
        }
        public double Price
        {
            get { return _equip.Price; }
            set
            {
                _equip.Price = value;
                RaisePropertyChanged();
            }
        }
        public int Strength
        {
            get { return _equip.Strength; }
            set
            {
                _equip.Strength = value;
                RaisePropertyChanged();
            }
        }
        public int Intelligence
        {
            get { return _equip.Intelligence; }
            set
            {
                _equip.Intelligence = value;
                RaisePropertyChanged();
            }
        }
        public int Agillity
        {
            get { return _equip.Agillity; }
            set
            {
                _equip.Agillity = value;
                RaisePropertyChanged();
            }
        }
        public string CategoryName
        {
            get { return _equip.CategoryName; }
            set
            {
                _equip.CategoryName = value;
                RaisePropertyChanged();
            }
        }

        //TODO: WHy is this implemented?
        //public bool HasValues { get { return !CategoryName.IsNullOrEmpty(); } }

        public Equip ToEntity() { return new Equip { EquipName = EquipName, Price = Price, Strength = Strength, Intelligence = Intelligence, Agillity = Agillity, CategoryName = CategoryName }; }
    }
}
