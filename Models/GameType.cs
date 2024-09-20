using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace A2.Models
{
    public class GameType
    {
        public int GameTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}