using Assignment9_API_2.Models;

namespace Assignment9_API_2.Services;

public class PersonService : IPersonService
{
    private static List<Person> _people = new List<Person>
        {
            new Person
            {
                LastName = "Phuong",
                FirstName = "Nguyen Nam",
                Gender = "Male",
                DOB = new DateTime(2001, 1, 22),

                BirthPlace = "Phu Tho",

            },
            new Person
            {
                LastName = "Nam",
                FirstName = "Nguyen Thanh",
                Gender = "Male",
                DOB = new DateTime(2001, 1, 20),

                BirthPlace = "Ha Noi",

            },
            new Person
            {
                LastName = "Son",
                FirstName = "Do Hong",
                Gender = "Male",
                DOB = new DateTime(2000, 11, 6),

                BirthPlace = "Ha Noi",

            },
            new Person
            {
                LastName = "Huy",
                FirstName = "Nguyen Duc",
                Gender = "Male",
                DOB = new DateTime(1996, 1, 26),

                BirthPlace = "Ha Noi",

            },
            new Person
            {
                LastName = "Hoang",
                FirstName = "Phuong Viet",
                Gender = "Male",
                DOB = new DateTime(1999, 2, 5),

                BirthPlace = "Ha Noi",

            },
            new Person
            {
                LastName = "Long",
                FirstName = "Lai Quoc",
                Gender = "Male",
                DOB = new DateTime(1997, 5, 30),

                BirthPlace = "Bac Giang",

            },
            new Person
            {
                LastName = "Thanh",
                FirstName = "Tran Chi",
                Gender = "Male",
                DOB = new DateTime(2000, 9, 18),

                BirthPlace = "Ha Noi",

            },
            new Person
            {
                LastName = "Person",
                FirstName = "Old",
                Gender = "Male",
                DOB = new DateTime(1996, 1, 14),

                BirthPlace = "Ha Noi",

            }
        };

    public List<Person> GetAll()
    {
        return _people;
    }
    public Person GetOne(int index)
    {
        if (index <= 0 || index > _people.Count) throw new IndexOutOfRangeException();
        return _people[index - 1];
    }
    public Person Create(Person person)
    {
        _people.Add(person);
        return person;
    }
    public Person Update(int index, Person person)
    {
        if (index <= 0 || index > _people.Count) throw new IndexOutOfRangeException();
        _people[index - 1] = person;
        return person;
    }
    public void Delete(int index)
    {
        if (index <= 0 || index > _people.Count) throw new IndexOutOfRangeException();
        _people.RemoveAt(index - 1);

    }

}