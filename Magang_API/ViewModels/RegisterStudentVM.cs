﻿
using System.ComponentModel.DataAnnotations;

namespace Magang_API.ViewModels
{
    public class RegisterStudentVM
    {
        // NIK
        public string Id { get; set; }

        // First Name
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        // Last Name
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        // Birth Date
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        // Gender
        public int Gender { get; set; }

        // Email
        [EmailAddress]
        public string Email { get; set; }

        // Phone
        [Display(Name = "Phone Number"), Phone]
        public string PhoneNumber { get; set; }

        // Major
        public string Major { get; set; }

        // Degree
        public string Degree { get; set; }

        // GPA
        [Range(0, 4, ErrorMessage = "The {0} Tidak boleh kurang {1} dan lebih dari {2}")]
        public Decimal GPA { get; set; }

        [Display(Name = "Tanggal Mulai")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Tanggal Selesai")]
        public DateTime EndDate { get; set; }

        // University Name
        [Display(Name = "University Name")]
        public string UniversityName { get; set; }

        // Password
        [DataType(DataType.Password)]
        public string Password { get; set; }

        // Confirm Password
        [DataType(DataType.Password), Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}