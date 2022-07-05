using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CemeteryManagementSystem.Models
{
    public class ApplyModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        [DisplayName("Last Name")]
        public string applicantLastName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        [DisplayName("First Name")]
        public string applicantFirstName { get; set; }

        [StringLength(20, MinimumLength = 2)]
        [DisplayName("Middle Name")]
        public string applicantMiddleName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date of Birth")]
        public DateTime applicantBirthDate { get; set; }

        public SelectList applicantGender { get; set; }
        [Required]
        [DisplayName("Gender")]
        public string selectedApplicantGender { get; set; }

        [Required]
        [StringLength(13, MinimumLength = 10)]
        [DisplayName("Contact Number")]
        public string contact { get; set; }

        public SelectList paymentMethod { get; set; }
        [Required]
        [DisplayName("Payment Method")]
        public string selectedPaymentMethod { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        [DisplayName("Last Name")]
        public string deadLastName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        [DisplayName("First Name")]
        public string deadFirstName { get; set; }

        [StringLength(20, MinimumLength = 2)]
        [DisplayName("Middle Name")]
        public string deadMiddleName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date of Birth")]
        public DateTime deadBirthDate { get; set; }

        public SelectList deadGender { get; set; }
        [Required]
        [DisplayName("Gender")]
        public string selectedDeadGender { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date of Death")]
        public DateTime deathDate { get; set; }
        
        public ApplyModel(int Id, string applicantLastName, string applicantFirstName, string applicantMiddleName, DateTime applicantBirthDate, SelectList applicantGender, string contact, SelectList paymentMethod, string deadLastName, string deadFirstName, string deadMiddleName, DateTime deadBirthDate, SelectList deadGender, DateTime deathDate)
        {
            this.Id = Id;

            this.applicantLastName = applicantLastName;
            this.applicantFirstName = applicantFirstName;
            this.applicantMiddleName = applicantMiddleName;
            this.applicantBirthDate = applicantBirthDate;
            this.selectedApplicantGender = applicantGender.ToString();
            this.contact = contact;
            this.selectedPaymentMethod = paymentMethod.ToString();

            this.deadLastName = deadLastName;
            this.deadFirstName = deadFirstName;
            this.deadMiddleName = deadMiddleName;
            this.deadBirthDate = deadBirthDate;
            this.selectedDeadGender = deadGender.ToString();
            this.deathDate = deathDate;
        }

        public ApplyModel()
        {
            Id = -1;
        }
    }
}