using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CemeteryManagementSystem.Models
{
    public class ApplyModel
    {
        //name age? gender birthdate deathdate contactpersonname contactnumber paymentmethod

        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        [DisplayName("Last Name")]
        public string lastName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        [DisplayName("First Name")]
        public string firstName { get; set; }

        [StringLength(20, MinimumLength = 2)]
        [DisplayName("Middle Name")]
        public string middleName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date of Birth")]
        public DateTime birthDay { get; set; }
        //public string birthDay { get; set; }

        [Required]
        [StringLength(6, MinimumLength = 4)]
        [DisplayName("Gender")]
        public string gender { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date of Death")]
        public DateTime deathDay { get; set; }
        //public string deathDay { get; set; }

        [Required]
        [StringLength(13)]
        [DisplayName("Contact Number")]
        public string contact { get; set; }

        public ApplyModel(int Id, string lastName, string firstName, string middleName, DateTime birthDay, string gender, DateTime deathDay, string contact)
        //public ApplyModel(int Id, string lastName, string firstName, string middleName, string birthDay, string gender, string deathDay, string contact)
        {
            this.Id = Id;
            this.lastName = lastName;
            this.firstName = firstName;
            this.middleName = middleName;
            //this.birthDay = Convert.ToDateTime(birthDay);
            this.birthDay = birthDay;
            this.gender = gender;
            //this.deathDay = Convert.ToDateTime(deathDay);
            this.deathDay = deathDay;
            this.contact = contact;
        }

        public ApplyModel()
        {
        }
    }
}