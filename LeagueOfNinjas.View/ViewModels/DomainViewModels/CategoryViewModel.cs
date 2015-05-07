using GalaSoft.MvvmLight;
using LeagueOfNinjas.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinjas.View.ViewModels.DomainViewModels
{
    public class CategoryViewModel : ViewModelBase
    {

        public CategoryViewModel() { _category = new Category(); }

        public CategoryViewModel(Category category) { _category = category ?? new Category(); }

        private readonly Category _category;

        public string CategoryName
        {
            get { return _category.CategoryName; }
            set
            {
                _category.CategoryName = value;
                RaisePropertyChanged();
                //RaisePropertyChanged(() => HasValues);//What does this override do?
            }
        }
        //TODO: WHy is this implemented?
        //public bool HasValues { get { return !CategoryName.IsNullOrEmpty(); } }

        public Category ToEntity() { return new Category { CategoryName = CategoryName }; }
    }
}
