using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace DL.Models
{
    public class BMI
    {
        [Display(Name = "Twój wzrost(cm)"),Range(100, 250, ErrorMessage = "Wzrost musi być z przedziału 100-250 cm")]
        public int Heigth { get; set; }
        [Display(Name = "Twója waga(kg)"), Range(30, 250, ErrorMessage = "Waga musi być z przedziału 30-250 kg")]
        public int Weight { get; set; }
        [Required, Display(Name = "Maksymalna ilość pompek"),Range(1, 999, ErrorMessage = "Wartość musi być większa od 0")]
        public int PushUps { get; set; }
        [Required, Display(Name = "Maksymalna ilość podciągnięć"), Range(1, 999, ErrorMessage = "Wartość musi być większa od 0")]
        public int PullUps { get; set; }
        [Required, Display(Name = "Maksymalna ilość dipów"), Range(1, 999, ErrorMessage = "Wartość musi być większa od 0")]
        public int Dips { get; set; }
        [Required, Display(Name = "Maksymalna ilość brzuszków"), Range(1, 999, ErrorMessage = "Wartość musi być większa od 0")]
        public int Abs { get; set; }

    }
}
