using Person = Assignment9_API_2.Models.Person;

namespace Assignment9_API_2.Services;

public interface IPersonService{
  
    List<Person> GetAll();
    Person GetOne(int index);
    Person Create(Person person);
   
    Person Update(int index, Person person);
    
    void Delete(int index);
}