using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace DL.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required, Display(Name = "Treść")]
        public string Text { get; set; }
        public DateTime? Date { get; set; }
        public Post Post { get; set; }
        public int PostId { get; set; }
        public UserProfile UserProfile { get; set; }
        public int UserProfileId { get; set; }
    }
}
