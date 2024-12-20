using Zusammenarbeits_dilemma;

public class Abbas : Player
{
    private string _name = "Abbas";
    private int _points;
    private int _roundCount;
    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public bool FirstMove()
    {
        return false;
    }

    public bool NextMove(bool previousMove)
    {
        _roundCount++;
        Random random = new Random();
        random.Next(1,3);

        if (random.Next(1, 10) < 7)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void ReceivedPoint(int ReceivedPointFromRound)
    {
        _points += ReceivedPointFromRound;

    }
}