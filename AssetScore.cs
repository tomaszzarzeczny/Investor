
namespace Investor
{
    public record AssetScore
    {
        public int Score { get; set; }
        public double Confidence { get; set; }

        public AssetScore(int score, double confidence)
        {
            Score = score;
            Confidence = confidence;
        }
    }
}
