using DL.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace DL.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        [Display(Name = "Imię")]
        public string Name { get; set; }
        [Display(Name = "Nazwisko")]
        public string Surname { get; set; }
        [Display(Name = "Miejscowość")]
        public string City { get; set; }
        [Required, Display(Name = "Email"), EmailAddress]
        public string Email { get; set; }
        public bool Newsletter { get; set; }
        [Display(Name = "Numer użytkownika")]
        public string OwnerId { get; set; }
        [Display(Name = "Link do zdjęcia")]
        public string PhotoUrl { get; set; }

    }
}
