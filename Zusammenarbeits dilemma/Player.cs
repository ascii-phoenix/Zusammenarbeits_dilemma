using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zusammenarbeits_dilemma
{
    public interface Player
    {
        public string Name { get; set; }
        public bool FirstMove();
        public bool NextMove(bool previousMove);
        public void ReceivedPoint(int ReceivedPointFromRound);
    }
}
