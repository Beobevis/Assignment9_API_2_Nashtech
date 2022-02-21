using Microsoft.AspNetCore.Mvc;
using Assignment9_API_2.Services;
using Person = Assignment9_API_2.Models.Person;
using Assignment9_API_2.Models;
using Assignment9_API_2.Common;
namespace Assignment9_API_2.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly ILogger<PersonController> _logger;
    private readonly IPersonService _personServices;

    public PersonController(ILogger<PersonController> logger, IPersonService personService)
    {
        _logger = logger;
        _personServices = personService;
    }

    [HttpGet]
    public List<Person> Get()
    {
        return _personServices.GetAll();
    }

    [HttpGet("{index:int}")]

    public IActionResult GetOne(int index)
    {
        try
        {
            var person = _personServices.GetOne(index);
            return new JsonResult(person);
        }
        catch (IndexOutOfRangeException ex)
        {
            //return NotFound(ex);
            _logger.LogError(ex, ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost]
    public Person Add(PersonCreateModel model)
    {
        var person = new Person
        {

            FirstName = model.FirstName,
            LastName = model.LastName,
            Gender = model.Gender,
            DOB = model.DOB,
            BirthPlace = model.BirthPlace
        };
        return _personServices.Create(person);
    }
    [HttpPut("{index:int}")]
    public IActionResult Edit(int index, PersonCreateModel model)
    {
        try
        {
            var person = _personServices.GetOne(index);
            person.FirstName = model.FirstName;
            person.LastName = model.LastName;
            person.Gender = model.Gender;
            person.DOB = model.DOB;
            person.BirthPlace = model.BirthPlace;

            _personServices.Update(index, person);
            return new JsonResult(person);
        }
        catch (IndexOutOfRangeException ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    [HttpDelete("{index:int}")]
    public IActionResult Remove(int index)
    {
        try
        {
            _personServices.Delete(index);
            return Ok();
        }
        catch (IndexOutOfRangeException ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }

    }
    [HttpGet("filter-by-name")]
    public List<Person> FilterByName(string keyname)
    {
        var people = _personServices.GetAll();
        var result = from person in people
                     where (person.FirstName != null && person.FirstName.Contains(keyname, StringComparison.CurrentCulture) || person.LastName != null && person.LastName.Contains(keyname, StringComparison.CurrentCulture))
                     select person;
        return result.ToList();
    }
    [HttpGet("filter-by-gender")]
    public List<Person> FilterByGender(string keyname)
    {
        var people = _personServices.GetAll();
        var result = from person in people
                     where (person.Gender != null && person.Gender.Contains(keyname, StringComparison.CurrentCultureIgnoreCase))
                     select person;
        return result.ToList();
    }
    [HttpGet("filter-by-birthplace")]
    public List<Person> FilterByBirthPlace(string keyname)
    {
        var people = _personServices.GetAll();
        var result = from person in people
                     where (person.BirthPlace != null && person.BirthPlace.Contains(keyname, StringComparison.CurrentCultureIgnoreCase))
                     select person;
        return result.ToList();
    }

    [HttpGet("filters")]

    public List<Person> Filters(string name, string gender, string birthplace)
    {
        var people = _personServices.GetAll();
        Func<Person, bool> predicate = x => true;
        if (!string.IsNullOrEmpty(name)){
            Func<Person,bool> filterbyName = x =>(x.FirstName != null && x.FirstName.Contains(name, StringComparison.CurrentCulture) || x.LastName != null && x.LastName.Contains(name, StringComparison.CurrentCulture)||x.FullName !=null && x.FullName.Contains(name,StringComparison.CurrentCulture));
            predicate = predicate.And(filterbyName);
        }
        if (!string.IsNullOrEmpty(gender)){
            Func<Person,bool> filterbyGender = x =>(x.Gender != null && x.Gender.Contains(gender, StringComparison.CurrentCultureIgnoreCase) );
            predicate = predicate.And(filterbyGender);
        }
        if (!string.IsNullOrEmpty(birthplace)){
            Func<Person,bool> filterbyBirthplace = x =>(x.BirthPlace != null && x.BirthPlace.Contains(birthplace, StringComparison.CurrentCultureIgnoreCase) );
            predicate = predicate.And(filterbyBirthplace);
        }
            var result = people.Where(predicate);
            return result.ToList();
    }

}
