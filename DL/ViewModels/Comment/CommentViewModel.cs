using DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public UserProfile UserProfile { get; set; }
        public int UserProfileId { get; set; }
        public Post Post { get; set; }
        public int PostId { get; set; }
        public DateTime Date { get; set; }

    }
}
