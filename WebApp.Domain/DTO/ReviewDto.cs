using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Domain.DTO
{
    public class ReviewDto
    {
        [Required]
        public string content { get; set; }

        [Required]
        public double rating { get; set; }

        [Required]
        public string gameId { get; set; }
        [Required]

        public string reviewId { get; set; }
    }
}
