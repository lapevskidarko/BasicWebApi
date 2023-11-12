using BasicWebApi_Exam1.Models;
using System.ComponentModel.DataAnnotations;



namespace BasicWebApi_Exam1.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public ICollection<Contact> Contacts { get; set; }
    }
}