using BasicWebApi_Exam1.Models;
using System.ComponentModel.DataAnnotations;

using System.Text.Json.Serialization;

namespace BasicWebApi_Exam1.Model
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public ICollection<Contact> Contacts { get; set; }
    }
}