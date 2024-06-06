using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Domain.DTO
{
    public class GameDto
    {
        [Required]
        public required string title { get; set; }
        [Required]
        public string gameId { get; set; }
        [Required]
        public required string description { get; set; }
        [Required]
        public required string genre { get; set; }
        [Required]
        public ICollection<ReviewDto> Reviews { get; set; }

    }
}
