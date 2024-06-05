using InterfacesClassesExamples.Interfaces;

namespace InterfacesClassesExamples.Models;

public class Customer : IBase<Customer>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateOnly BirthDate { get; set; }

    public Customer GetById(int id)
    {
        // Implementation goes here
        return new Customer();
    }

    public void Insert(Customer entity)
    {
        // Implementation goes here
    }

    public void Update(Customer entity)
    {
        // Implementation goes here
    }

    public void Delete(int id)
    {
        // Implementation goes here
    }
}