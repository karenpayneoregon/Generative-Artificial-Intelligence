using System;
using System.ComponentModel;

namespace InterfacesClassesExamples
{
    public interface IBase<T>
    {
        void Create(T item);
        T Read(int id);
        void Update(T item);
        void Delete(int id);
    }

    public class Customer : IBase<Customer>, INotifyPropertyChanged
    {
        private int id;
        private string firstName;
        private string lastName;
        private string email;
        private DateOnly birthDate;

        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    OnPropertyChanged(nameof(LastName));
                }
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        public DateOnly BirthDate
        {
            get { return birthDate; }
            set
            {
                if (birthDate != value)
                {
                    birthDate = value;
                    OnPropertyChanged(nameof(BirthDate));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Create(Customer item)
        {
            // Implementation for creating a customer
        }

        public Customer Read(int id)
        {
            // Implementation for reading a customer
            return null;
        }

        public void Update(Customer item)
        {
            // Implementation for updating a customer
        }

        public void Delete(int id)
        {
            // Implementation for deleting a customer
        }
    }

    internal partial class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
