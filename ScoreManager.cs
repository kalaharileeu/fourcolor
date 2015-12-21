
namespace fourcolors
{
    /// <summary>
    /// The Scoremanager controls the score board and lives count, the player have 
    /// for example 3 lives
    /// </summary>
    class ScoreManager
    {
        int overflow;
        public int Score { get; set; }
        public int Lives { get; set; } = 3;

        private static ScoreManager instance;

        public static ScoreManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ScoreManager();
                }
                return instance;
            }
        }

        public void ResetValues()
        {
            Score = 0;
            Lives = 3;
        }

        public void Scoreincrement()
        {
            if (Score >= 999)
            {
                overflow++;
                Score = 0;
            }
            else
            {
                Score += 1;
            }
        }

        public void Scoredecrement()
        {
            if (Score <= 0)
            {
                if (overflow > 0)overflow -= 1;

            }
            else
            {  Score -= 1; }
        }
        //The blow functions control the live variable
        public void Livesdecrement()
        {
            if(Lives > 0)Lives -= 1;
        }

        public void Livesincrement()
        {
            if (Lives < 3) Lives += 1;
        }
    }
}
