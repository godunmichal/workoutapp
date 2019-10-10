using DL.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace DL.Models
{
    public class Post
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string VideoUrl { get; set; }
        [Required, Display(Name = "Treść")]
        public string Text { get; set; }
        [Required, Display(Name = "Tytuł")]
        public string Title { get; set; }
        public IEnumerable<PostComments> Comments { get; set; }
    }
    public class PostComments
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public string CommentText { get; set; }
        public DateTime? CommentDate { get; set; }
    }

}
