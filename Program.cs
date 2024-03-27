using Investor;

//https://tradingeconomics.com/united-states/forecast
var gdpGrowthRateNum = 3.3;
var gdpGrowthRateCh = "falling";
var interestRateNum = 5.5;
var interestRateCh = "rising";
var inflationRateCh = "rising";
var isQE = false;
var debtToGdp = 131.5;
var productivityGrowth = 1.42; //https://www.ceicdata.com/en/indicator/united-states/labour-productivity-growth
var globalTrade = GlobalTrade.Unstable;

var monetaryPolicy = new MonetaryPolicy(interestRateNum, interestRateCh, isQE);
var economicCycle = new EconomicCycle(gdpGrowthRateNum, gdpGrowthRateCh, inflationRateCh, monetaryPolicy);
var drivers = new DominantDrivers(productivityGrowth, debtToGdp, globalTrade, monetaryPolicy.type);

Console.WriteLine($"Economic cycle: {economicCycle.type}");
Console.WriteLine($"Monetary policy: {monetaryPolicy.type}");
Console.WriteLine($"Dominant drivers:");

foreach (var driver in drivers.dominantDrivers)
{
    Console.WriteLine( driver.ToString() );
}

var recommendedAssets = AssetEvaluation.EvaluateAssetClasses(economicCycle.type, drivers.dominantDrivers);

Console.WriteLine($"Recommendations:");
foreach (var asset in recommendedAssets)
{
    Console.WriteLine( asset.ToString() );
}