using System.ComponentModel;

/*
 * Create a public crud interface named IBase with a constraint on T
 *
 * Create a public class named Customer which implements IBase with the following properties, Id, FirstName, LastName, Email and BirthDate as DateOnly and implement INotifyPropertyChanged for each property
 */

namespace InterfacesClassesExamplesLibrary.Interfaces
{
    public class Customer : IBase<Customer>, INotifyPropertyChanged
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _email;
        private DateOnly _birthDate;

        public int Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged(nameof(LastName));
                }
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        public DateOnly BirthDate
        {
            get { return _birthDate; }
            set
            {
                if (_birthDate != value)
                {
                    _birthDate = value;
                    OnPropertyChanged(nameof(BirthDate));
                }
            }
        }

        public Customer GetById(int id)
        {
            // Implementation of GetById method
        }

        public void Insert(Customer entity)
        {
            // Implementation of Insert method
        }

        public void Update(Customer entity)
        {
            // Implementation of Update method
        }

        public void Delete(Customer entity)
        {
            // Implementation of Delete method
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public interface IBase<T>
    {
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }



}
