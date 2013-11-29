using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LongListSelectorAdd.Model;

namespace LongListSelectorAdd.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IList<Person> _ungroupedPersons;
        private ObservableCollection<AlphaKeyGroup<Person>> _persons = new ObservableCollection<AlphaKeyGroup<Person>>();
        private Person _selectedPerson;

        private RelayCommand _addCommand;

        public ObservableCollection<AlphaKeyGroup<Person>> Persons
        {
            get
            {
                return _persons;
            }
            set
            {
                if (value == _persons)
                    return;

                _persons = value;
                RaisePropertyChanged(() => Persons);
            }
        }

        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                if (value == _selectedPerson)
                    return;

                _selectedPerson = value;
                RaisePropertyChanged(() => SelectedPerson);
            }
        }

        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new RelayCommand(AddNewItem));
            }
        }

        public MainViewModel()
        {
            _ungroupedPersons = new List<Person>
            {
                new Person {Name = "Azerty1", Age = 1},
                new Person {Name = "Azerty2", Age = 2},
                new Person {Name = "Bzerty1", Age = 1},
                new Person {Name = "Bzerty2", Age = 2},
                new Person {Name = "Czerty1", Age = 1},
                new Person {Name = "Czerty2", Age = 2},
                new Person {Name = "Dzerty1", Age = 1},
                new Person {Name = "Dzerty2", Age = 2},
                new Person {Name = "Ezerty1", Age = 1},
                new Person {Name = "Ezerty2", Age = 2},
                new Person {Name = "Fzerty1", Age = 1},
                new Person {Name = "Fzerty2", Age = 2},
                new Person {Name = "Gzerty1", Age = 1},
                new Person {Name = "Gzerty2", Age = 2},
                new Person {Name = "Hzerty1", Age = 1},
                new Person {Name = "Hzerty2", Age = 2},
                new Person {Name = "Izerty1", Age = 1},
                new Person {Name = "Izerty2", Age = 2},
                new Person {Name = "Jzerty1", Age = 1},
                new Person {Name = "Jzerty2", Age = 2}
            };

            GroupData();
        }

        private void GroupData()
        {
            Persons.Clear();
            foreach (var item in AlphaKeyGroup<Person>.CreateGroups(_ungroupedPersons, s => s.Name, true))
            {
                Persons.Add(item);
            }
        }

        private void AddNewItem()
        {
            Random rnd = new Random();

            Person person = new Person { Name = "NewPerson " + _ungroupedPersons.Count, Age = rnd.Next(1, 50) };
            _ungroupedPersons.Add(person);
            GroupData();
        }
    }
}