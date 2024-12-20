using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Zusammenarbeits_dilemma
{
    public class Eloi : Player
    {
        private string _name;
        public Eloi()
        {
            _name = "Eloi";
            _points = 0;
            _roundsPlayed = 0;
            Entropy = 0;
            Agrassivemeter=0;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }
        private float _points;
        private int _roundsPlayed;
        private List<bool> yourMoves = new();
        private List<bool> opponentMoves = new();
        private float Entropy;
        private float Agrassivemeter;

        public bool FirstMove()
        {
            _roundsPlayed++;
            yourMoves.Add(true);
            return false;
        }

        public bool NextMove(bool previousMove)
        {
            opponentMoves.Add(previousMove);
            if (IsOpponentCooperative())
            {
                _roundsPlayed++;
                yourMoves.Add(true);
                return true;
            }
            if (_roundsPlayed > 10)
            {
                if (CalculateEntropy(opponentMoves) > 0.5)
                {
                    _roundsPlayed++;
                    yourMoves.Add(false);
                    return false;
                }
            }
            if (IsPlayerAgressive(previousMove))
            {
                _roundsPlayed++;
                yourMoves.Add(false);
                return false;
            }
            return true;
        }

        public void ReceivedPoint(int ReceivedPointFromRound)
        {
            _points += ReceivedPointFromRound;
        }
        private float AveragePointsPerRound()
        {
            return _points / _roundsPlayed;
        }
        private bool IsOpponentCooperative()
        {
            return opponentMoves.Count(x => x == true) > opponentMoves.Count(x => x == false);
        }
        private bool IsPlayerAgressive(bool previousMove)
        {
            Agrassivemeter += previousMove ? 0 : 1;
            Agrassivemeter /= 2;
            return (Agrassivemeter <= 0.25 || Agrassivemeter >= 0.75);
        }
        private static double CalculateEntropy(List<bool> data)
        {
            int n = data.Count;
            double pTrue = 0, pFalse = 0;

            foreach (var b in data)
            {
                if (b) pTrue++;
                else pFalse++;
            }

            pTrue /= n;
            pFalse /= n;

            double entropy = 0;
            if (pTrue > 0) entropy -= pTrue * Math.Log2(pTrue);
            if (pFalse > 0) entropy -= pFalse * Math.Log2(pFalse);

            return entropy;
        }
    }
}

