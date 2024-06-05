namespace InterfacesClassesExamples.Interfaces;

public interface IBase<T>
{
    T GetById(int id);
    void Insert(T entity);
    void Update(T entity);
    void Delete(int id);
}