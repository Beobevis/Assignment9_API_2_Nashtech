using System.ComponentModel.DataAnnotations;
namespace Assignment9_API_2.Models;

public class PersonCreateModel
{
    [Required, MaxLength(50)]
    public string? FirstName { get; set; }
    [Required, MaxLength(50)]
    public string? LastName { get; set; }

    public string? Gender { get; set; }

    public DateTime? DOB { get; set; }

    [Required]
    public string? BirthPlace { get; set; }
}

public class Person : PersonCreateModel
{
    public int Age{
        get{
            return DateTime.Now.Year - (DOB?.Year ?? 0);
        }
    }

    public string FullName
    {
        get
        {
            return $"{FirstName} {LastName}";
        }
    }
    public class PersonEditModel : PersonCreateModel
    {
        public int index { get; set; }
    }


}
