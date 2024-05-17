using Investor;

//The below values come from https://tradingeconomics.com/united-states/forecast
var gdpGrowth = new Vector(3.0, Trend.Falling);
var interestRate = new Vector(5.5, Trend.Falling);
var inflationRate = new Vector(3.4, Trend.Falling);
var unemploymentRate = new Vector(3.9, Trend.Stable);
var isQE = false;
var debtToGdp = 122.3;
var globalTrade = GlobalTrade.Unstable;
//The below values come from https://www.ceicdata.com/en/indicator/united-states/labour-productivity-growth
var productivityGrowth = new Vector(2.5, Trend.Rising); 

var monetaryPolicy = new MonetaryPolicy(interestRate, isQE);
var economicCycle = new EconomicCycle(gdpGrowth, inflationRate, monetaryPolicy);
var dominantDrivers = new DominantDrivers(productivityGrowth, debtToGdp, globalTrade, monetaryPolicy, unemploymentRate);
var assets = AssetEvaluation.EvaluateAssetClasses(economicCycle.Type, dominantDrivers.Drivers);

Console.WriteLine($"Economic cycle: {economicCycle.Type}");
Console.WriteLine($"Dominant drivers:");
foreach (var driver in dominantDrivers.Drivers)
{
    Console.WriteLine($"- {driver}");
}

Console.WriteLine($"Possibilities:");
foreach (var asset in assets)
{
    Console.WriteLine($"- {asset.Key}, Score: {asset.Value.Score}, Confidence: {asset.Value.Confidence:P0}");
}