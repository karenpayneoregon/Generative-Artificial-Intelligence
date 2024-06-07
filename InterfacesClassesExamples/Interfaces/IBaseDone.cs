namespace InterfacesClassesExamples.Interfaces;

public interface IBaseDone<T>
{
    T GetById(int id);
    void Insert(T entity);
    void Update(T entity);
    void Delete(int id);
}