using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using LongListSelectorAdd.Model;

namespace LongListSelectorAdd.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private List<Person> _list = new List<Person>(); 

        public string PersonsPropertyName = "Persons";
        private ObservableCollection<AlphaKeyGroup<Person>> _persons = new ObservableCollection<AlphaKeyGroup<Person>>();

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
                RaisePropertyChanged(PersonsPropertyName);
            }
        }

        public RelayCommand AddCommand { get; private set; }

        public MainViewModel()
        {
            _list.Add(new Person() { Name = "Azerty1", Age = 1 });
            _list.Add(new Person() { Name = "Azerty2", Age = 2 });
            _list.Add(new Person() { Name = "Bzerty1", Age = 1 });
            _list.Add(new Person() { Name = "Bzerty2", Age = 2 });
            _list.Add(new Person() { Name = "Czerty1", Age = 1 });
            _list.Add(new Person() { Name = "Czerty2", Age = 2 });
            _list.Add(new Person() { Name = "Dzerty1", Age = 1 });
            _list.Add(new Person() { Name = "Dzerty2", Age = 2 });
            _list.Add(new Person() { Name = "Ezerty1", Age = 1 });
            _list.Add(new Person() { Name = "Ezerty2", Age = 2 });
            _list.Add(new Person() { Name = "Fzerty1", Age = 1 });
            _list.Add(new Person() { Name = "Fzerty2", Age = 2 });
            _list.Add(new Person() { Name = "Gzerty1", Age = 1 });
            _list.Add(new Person() { Name = "Gzerty2", Age = 2 });
            _list.Add(new Person() { Name = "Hzerty1", Age = 1 });
            _list.Add(new Person() { Name = "Hzerty2", Age = 2 });
            _list.Add(new Person() { Name = "Izerty1", Age = 1 });
            _list.Add(new Person() { Name = "Izerty2", Age = 2 });
            _list.Add(new Person() { Name = "Jzerty1", Age = 1 });
            _list.Add(new Person() { Name = "Jzerty2", Age = 2 });

            Messenger.Default.Register<NotificationMessage>(this, msg =>
            {
                if (msg.Notification.Equals("ViewLoaded"))
                    LoadData();
            });
        }

        private void LoadData()
        {
            this.Persons.Clear();
            foreach (var item in AlphaKeyGroup<Person>.CreateGroups(_list, (Person s) => { return s.Name; }, true))
            {
                this.Persons.Add(item);
            }
            if (this.Persons.Any())
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage("ListReposition"));
        }

        private void AddOneBruce()
        {
            
        }
    }
}