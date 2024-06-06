using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Domain.Entities
{
    public class Game
    {
        public string gameId { get; set; }
        public required string title { get; set; }
        public required string description { get; set; }
        public required string genre { get; set; }

        public ICollection<Review> Reviews { get; set; }

    }
}
