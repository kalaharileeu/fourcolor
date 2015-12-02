
namespace fourcolors
{
    class ScoreManager
    {
        int score;
        int overflow;

        private static ScoreManager instance;

        public static ScoreManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new ScoreManager();
                return instance;
            }
        }

        public int Score
        {
            get
            {
                if (score > 100)
                {
                    overflow++;
                    Score = 100;
                }
                return score;
            }


            set { score = value; }
        }

        public void Scoreincrement()
        {
            if (score >= 999)
            {
                overflow++;
                Score = 0;
            }
            else
            {
                score += 1;
            }
        }

        public void Scoredecrement()
        {
            if (score <= 0)
            {
                if (overflow > 0)
                    overflow -= 1;
            }
            else
            {
                score -= 1;
            }
        }
    }
}
