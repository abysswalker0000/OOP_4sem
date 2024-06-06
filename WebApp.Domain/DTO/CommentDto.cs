using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Domain.DTO
{
    public class CommentDto
    {
        [Required]
        public string commentId { get; set; }

        [Required]
        public string commRating { get; set; }

        [Required]
        public string nickname { get; set; }

        [Required]
        public string content { get; set; }

        [Required]
        public DateTime datePostedComment { get; set; }
    }
}
