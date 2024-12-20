namespace Zusammenarbeits_dilemma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player[] players = new Player[]
            {
                new CooperativePlayer(),
                new TitForTatPlayer(),
                new RandomPlayer(),
                new GrudgerPlayer(),
                new GenerousTitForTatPlayer(),
                new AdaptivePlayer(),
                new MirrorPlayer(),
                new ExploitativePlayer(),
                new RandomForgiverPlayer()
            };

            for (int i = 0; i < players.Length-1; i++)
            {
                for (int j = i + 1; j < players.Length; j++)
                {
                    if (i < j)
                    {
                        Game game = new Game(players[i], players[j]);
                        game.RunGame();
                    }
                    
                }
            }
            
        }
    }
}
