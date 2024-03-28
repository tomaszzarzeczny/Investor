namespace Investor
{
    internal class Vector
    {
        public double Value { get; set; }
        public Trend Trend { get; set; }
        public Vector(double value, Trend trend) 
        { 
            Value = value;
            Trend = trend;
        }
    }
}
