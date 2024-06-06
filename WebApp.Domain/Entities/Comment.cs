using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Domain.Entities
{
    public class Comment
    {
        public string commentId { get; set; }
        public required string commRating { get; set; }
        public required string nickname { get; set; }
        public required string content { get; set; }
        public required DateTime datePostedComment { get; set; }

    }
}
