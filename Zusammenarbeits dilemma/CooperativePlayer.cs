using System;
using System.Xml.Linq;
using Zusammenarbeits_dilemma;

namespace Zusammenarbeits_dilemma
{
    public class CooperativePlayer : Player
    {
        private string _name;
        public CooperativePlayer()
        {
            _name = "CooperativePlayer";
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }
        private int _points;
        Random random = new Random();

        public bool FirstMove()
        {
            return true;
        }

        public bool NextMove(bool previousMove)
        {
            if (random.Next(0, 5) == 0)
            {
                return false;
            }
            return true;
        }

        public void ReceivedPoint(int receivedPointFromRound)
        {
            _points=+receivedPointFromRound;
        }
    }

    public class TitForTatPlayer : Player
    {
        private string _name;
        private int _points;
        public TitForTatPlayer()
        {
            _name = "TitForTatPlayer";
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public bool FirstMove()
        {
            return true;
        }

        public bool NextMove(bool previousMove)
        {
            return previousMove;
        }

        public void ReceivedPoint(int receivedPointFromRound)
        {
            _points=+receivedPointFromRound;
        }
    }
    public class AlwaysDefectPlayer : Player
    {
        private string _name;
        private int _points;

        public AlwaysDefectPlayer()
        {
            _name = "AlwaysDefectPlayer";
        }

        public   string Name
        {
            get => _name;
            set => _name = value;
        }

        public   bool FirstMove()
        {
            return false;
        }

        public   bool NextMove(bool previousMove)
        {
            return false;
        }

        public   void ReceivedPoint(int receivedPointFromRound)
        {
            _points += receivedPointFromRound;
        }
    }

    public class RandomPlayer : Player
    {
        private string _name;
        private int _points;
        private Random _random;

        public RandomPlayer()
        {
            _name = "RandomPlayer";
            _random = new Random();
        }

        public  string Name
        {
            get => _name;
            set => _name = value;
        }

        public  bool FirstMove()
        {
            return _random.Next(0, 2) == 1;
        }

        public  bool NextMove(bool previousMove)
        {
            return _random.Next(0, 2) == 1;
        }

        public  void ReceivedPoint(int receivedPointFromRound)
        {
            _points += receivedPointFromRound;
        }
    }

    public class GrudgerPlayer : Player
    {
        private string _name;
        private int _points;
        private bool _hasBeenCheated;

        public GrudgerPlayer()
        {
            _name = "GrudgerPlayer";
            _hasBeenCheated = false;
        }

        public  string Name
        {
            get => _name;
            set => _name = value;
        }

        public  bool FirstMove()
        {
            return true;
        }

        public  bool NextMove(bool previousMove)
        {
            if (!_hasBeenCheated && !previousMove)
            {
                _hasBeenCheated = true;
            }

            return !_hasBeenCheated;
        }

        public  void ReceivedPoint(int receivedPointFromRound)
        {
            _points += receivedPointFromRound;
        }
    }

    public class GenerousTitForTatPlayer : Player
    {
        private string _name;
        private int _points;
        private Random _random;

        public GenerousTitForTatPlayer()
        {
            _name = "GenerousTitForTatPlayer";
            _random = new Random();
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public bool FirstMove()
        {
            return true;
        }

        public bool NextMove(bool previousMove)
        {
            if (!previousMove && _random.Next(0, 4) == 0) // 25% chance to forgive
            {
                return true;
            }

            return previousMove;
        }

        public void ReceivedPoint(int receivedPointFromRound)
        {
            _points += receivedPointFromRound;
        }
    }
}
public class AdaptivePlayer : Player
{
    private string _name;
    private int _points;
    private int _opponentDefections;
    private int _roundsPlayed;

    public AdaptivePlayer()
    {
        _name = "AdaptivePlayer";
        _opponentDefections = 0;
        _roundsPlayed = 0;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public bool FirstMove()
    {
        return true;
    }

    public bool NextMove(bool previousMove)
    {
        _roundsPlayed++;
        if (!previousMove)
        {
            _opponentDefections++;
        }

        if (_opponentDefections > _roundsPlayed / 2)
        {
            return false; // Defect if opponent defects more than 50% of the time.
        }

        return true; // Otherwise, cooperate.
    }

    public void ReceivedPoint(int receivedPointFromRound)
    {
        _points += receivedPointFromRound;
    }
}
public class MirrorPlayer : Player
{
    private string _name;
    private int _points;
    private bool? _lastMove;
    private bool? _secondLastMove;

    public MirrorPlayer()
    {
        _name = "MirrorPlayer";
        _lastMove = null;
        _secondLastMove = null;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public bool FirstMove()
    {
        return true;
    }

    public bool NextMove(bool previousMove)
    {
        _secondLastMove = _lastMove;
        _lastMove = previousMove;

        if (_secondLastMove.HasValue && _secondLastMove == false && _lastMove == false)
        {
            return false; // Defect if opponent defected twice in a row.
        }

        return true; // Otherwise, cooperate.
    }

    public void ReceivedPoint(int receivedPointFromRound)
    {
        _points += receivedPointFromRound;
    }
}
public class RandomForgiverPlayer : Player
{
    private string _name;
    private int _points;
    private int _roundCount;
    private Random _random;

    public RandomForgiverPlayer()
    {
        _name = "RandomForgiverPlayer";
        _random = new Random();
        _roundCount = 0;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public bool FirstMove()
    {
        return true;
    }

    public bool NextMove(bool previousMove)
    {
        _roundCount++;
        if (_roundCount % 5 == 0)
        {
            return true; // Forgive every 5th round.
        }

        return _random.Next(0, 2) == 1; // Randomly cooperate or defect.
    }

    public void ReceivedPoint(int receivedPointFromRound)
    {
        _points += receivedPointFromRound;
    }
}
public class ExploitativePlayer : Player
{
    private string _name;
    private int _points;
    private int _roundCount;

    public ExploitativePlayer()
    {
        _name = "ExploitativePlayer";
        _roundCount = 0;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public bool FirstMove()
    {
        return true;
    }

    public bool NextMove(bool previousMove)
    {
        _roundCount++;
        return _roundCount % 3 != 0; // Defect every third round.
    }

    public void ReceivedPoint(int receivedPointFromRound)
    {
        _points += receivedPointFromRound;
    }
}
public class Abbas : Player
{
    private string _name = "Abbas";
    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public bool FirstMove()
    {
        throw new NotImplementedException();
    }

    public bool NextMove(bool previousMove)
    {
        throw new NotImplementedException();
    }

    public void ReceivedPoint(int ReceivedPointFromRound)
    {
        throw new NotImplementedException();
    }
}
