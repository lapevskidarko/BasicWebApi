using BasicWebApi_Exam1.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;


namespace BasicWebApi_Exam1.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public string ContactName { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public Company Company { get; set; }
        public Country Country { get; set; }
        public int Id { get; set; }
    }
}
