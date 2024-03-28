using Investor;

//https://tradingeconomics.com/united-states/forecast
var gdpGrowth = new Vector(3.3, Trend.Falling);
var interestRate = new Vector(5.5, Trend.Rising);
var inflationRate = new Vector(2.5, Trend.Rising);
var isQE = false;
var debtToGdp = 131.5;
var globalTrade = GlobalTrade.Unstable;
var productivityGrowth = 1.42; //https://www.ceicdata.com/en/indicator/united-states/labour-productivity-growth

var monetaryPolicy = new MonetaryPolicy(interestRate, isQE);
var economicCycle = new EconomicCycle(gdpGrowth, inflationRate, monetaryPolicy);
var drivers = new DominantDrivers(productivityGrowth, debtToGdp, globalTrade, monetaryPolicy.Type);

Console.WriteLine($"Economic cycle: {economicCycle.Type}");
Console.WriteLine($"Dominant drivers:");
foreach (var driver in drivers.Drivers)
{
    Console.WriteLine($"- {driver}");
}

var recommendedAssets = AssetEvaluation.EvaluateAssetClasses(economicCycle.Type, drivers.Drivers);
Console.WriteLine($"Recommendations:");
foreach (var asset in recommendedAssets)
{
    Console.WriteLine($"- {asset}");
}