using System;
using System.Collections.Generic;
using System.Text;

namespace WorkLogic_HR.Infrastucture.Repository.IRepository;

public interface IRepository<T> where T : class
{
    public List<T> GetAll();
    public T? GetById(int id);
    public void Create(T entity);
    public void Update(T entity);
    public bool Delete(int id);
    public void Save();

}
