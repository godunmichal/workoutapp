using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.ViewModels
{
    public class BlogViewModel
    {
        public IEnumerable<PostViewModel> Posts { get; set; }
        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}

