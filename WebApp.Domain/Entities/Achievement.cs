using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Domain.Entities
{
    public enum DifficultyLevel
    {
        Easy,
        Medium,
        Hard
    }
    public class Achievement
    {
        public int achievementId { get; set; }
        public int gameId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DifficultyLevel difficultyLevel { get; set; }

    }
}
