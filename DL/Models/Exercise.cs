using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.Constants;
namespace DL.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string VideoUrl { get; set; }
        public string Text { get; set; }
        public Difficulty Difficulty { get; set; }
    }
}
