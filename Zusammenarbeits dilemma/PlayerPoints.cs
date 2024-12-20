using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zusammenarbeits_dilemma
{
    public class PlayerPoints
    {
        public Player Player { get; init; }
        public int Points { get; set; }

        public PlayerPoints(Player player)
        {
            this.Player = player;
            this.Points = 0;
        }
    }
}
