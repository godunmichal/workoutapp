using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace DL.Models
{
    public class EmailFormModel
    {
        [Required, Display(Name = "Twoje imię")]
        public string FromName { get; set; }
        [Required, Display(Name = "Twój email"), EmailAddress]
        public string FromEmail { get; set; }
        [Required, Display(Name = "Wiadomość")]
        public string Message { get; set; }
        public HttpPostedFileBase Upload { get; set; }

    }
}