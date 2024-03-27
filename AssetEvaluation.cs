using Investor;

public class AssetEvaluation
{
    public static Dictionary<string, int> EvaluateAssetClasses(EconomicCycleType economicCycle, List<DominantDriversType> dominantDrivers)
    {
        List<string> recommendedAssets = new List<string>();
        Dictionary<string, int> assetScores = new Dictionary<string, int>();

        switch (economicCycle)
        {
            case EconomicCycleType.Recovery:
            case EconomicCycleType.Expansion:
                assetScores["Stocks/ETFs"] = AssessStocksETFs(dominantDrivers);
                assetScores["Real Estate/REITs"] = AssessRealEstateREITs(dominantDrivers);
                assetScores["Metals"] = AssessMetals(dominantDrivers);
                break;
            case EconomicCycleType.Peak:
                assetScores["Bonds"] = AssessBonds(dominantDrivers);
                assetScores["Cash"] = AssessCash(dominantDrivers);
                break;
            case EconomicCycleType.Recession:
                assetScores["Bonds"] = AssessBonds(dominantDrivers);
                assetScores["Cash"] = AssessCash(dominantDrivers);
                assetScores["Metals"] = AssessMetals(dominantDrivers);
                break;
            case EconomicCycleType.Depression:
                assetScores["Bonds"] = AssessBonds(dominantDrivers);
                assetScores["Metals"] = AssessMetals(dominantDrivers);
                assetScores["Stocks/ETFs"] = AssessStocksETFs(dominantDrivers);
                break;
            case EconomicCycleType.Trough:
                assetScores["Stocks/ETFs"] = AssessStocksETFs(dominantDrivers);
                assetScores["Real Estate/REITs"] = AssessRealEstateREITs(dominantDrivers);
                break;
            default:
                // Handle unknown economic cycle phase
                break;
        }

        assetScores["Cryptocurrencies"] = AssessCryptocurrencies(dominantDrivers);

        return assetScores.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
    }

    private static int AssessStocksETFs(List<DominantDriversType> dominantDrivers)
    {
        int score = 0;

        if (dominantDrivers.Contains(DominantDriversType.ProductivityGrowth))
        {
            score += 5;
        }
        if (dominantDrivers.Contains(DominantDriversType.GlobalTradeStable))
        {
            score += 3;
        }
        if (dominantDrivers.Contains(DominantDriversType.MonetaryPolicyAccommodative))
        {
            score += 2;
        }
        if (dominantDrivers.Contains(DominantDriversType.DebtLevelLow))
        {
            score += 4;
        }
        if (dominantDrivers.Contains(DominantDriversType.ProductivityDecline))
        {
            score -= 5;
        }
        if (dominantDrivers.Contains(DominantDriversType.GlobalTradeUnstable))
        {
            score -= 3;
        }
        if (dominantDrivers.Contains(DominantDriversType.MonetaryPolicyTight))
        {
            score -= 2;
        }
        if (dominantDrivers.Contains(DominantDriversType.DebtLevelHigh))
        {
            score -= 4;
        }

        return score;
    }

    private static int AssessRealEstateREITs(List<DominantDriversType> dominantDrivers)
    {
        int score = 0;

        if (dominantDrivers.Contains(DominantDriversType.ProductivityGrowth))
        {
            score += 3;
        }
        if (dominantDrivers.Contains(DominantDriversType.GlobalTradeStable))
        {
            score += 3;
        }
        if (dominantDrivers.Contains(DominantDriversType.MonetaryPolicyAccommodative))
        {
            score += 5;
        }
        if (dominantDrivers.Contains(DominantDriversType.DebtLevelLow))
        {
            score += 2;
        }
        if (dominantDrivers.Contains(DominantDriversType.ProductivityDecline))
        {
            score -= 2;
        }
        if (dominantDrivers.Contains(DominantDriversType.GlobalTradeUnstable))
        {
            score -= 3;
        }
        if (dominantDrivers.Contains(DominantDriversType.MonetaryPolicyTight))
        {
            score -= 2;
        }
        if (dominantDrivers.Contains(DominantDriversType.DebtLevelHigh))
        {
            score -= 2;
        }

        return score;
    }

    private static int AssessMetals(List<DominantDriversType> dominantDrivers)
    {
        int score = 0;

        if (dominantDrivers.Contains(DominantDriversType.ProductivityGrowth))
        {
            score += 4;
        }
        if (dominantDrivers.Contains(DominantDriversType.GlobalTradeStable))
        {
            score += 2;
        }
        if (dominantDrivers.Contains(DominantDriversType.GlobalTradeUnstable))
        {
            score += 5;
        }
        if (dominantDrivers.Contains(DominantDriversType.MonetaryPolicyAccommodative))
        {
            score += 5;
        }
        if (dominantDrivers.Contains(DominantDriversType.MonetaryPolicyTight))
        {
            score -= 3;
        }
        if (dominantDrivers.Contains(DominantDriversType.DebtLevelHigh))
        {
            score += 4;
        }

        return score;
    }

    private static int AssessBonds(List<DominantDriversType> dominantDrivers)
    {
        int score = 0;

        if (dominantDrivers.Contains(DominantDriversType.ProductivityGrowth))
        {
            score += 4;
        }
        if (dominantDrivers.Contains(DominantDriversType.GlobalTradeStable))
        {
            score += 3;
        }
        if (dominantDrivers.Contains(DominantDriversType.MonetaryPolicyAccommodative))
        {
            score += 4;
        }
        if (dominantDrivers.Contains(DominantDriversType.DebtLevelLow))
        {
            score += 4;
        }
        if (dominantDrivers.Contains(DominantDriversType.ProductivityDecline))
        {
            score -= 4;
        }
        if (dominantDrivers.Contains(DominantDriversType.GlobalTradeUnstable))
        {
            score -= 3;
        }
        if (dominantDrivers.Contains(DominantDriversType.MonetaryPolicyTight))
        {
            score -= 4;
        }
        if (dominantDrivers.Contains(DominantDriversType.DebtLevelHigh))
        {
            score -= 4;
        }

        return score;
    }

    private static int AssessCash(List<DominantDriversType> dominantDrivers)
    {
        int score = 0;

        if (dominantDrivers.Contains(DominantDriversType.MonetaryPolicyTight))
        {
            score += 5;
        }
        if (dominantDrivers.Contains(DominantDriversType.DebtLevelHigh))
        {
            score += 2;
        }
        if (dominantDrivers.Contains(DominantDriversType.GlobalTradeUnstable))
        {
            score += 1;
        }
        if (dominantDrivers.Contains(DominantDriversType.ProductivityGrowth))
        {
            score -= 3;
        }

        return score;
    }

    private static int AssessCryptocurrencies(List<DominantDriversType> dominantDrivers)
    {
        int score = 0;

        if (dominantDrivers.Contains(DominantDriversType.ProductivityGrowth))
        {
            score += 3;
        }
        if (dominantDrivers.Contains(DominantDriversType.GlobalTradeStable))
        {
            score += 3;
        }
        if (dominantDrivers.Contains(DominantDriversType.GlobalTradeUnstable))
        {
            score += 3;
        }
        if (dominantDrivers.Contains(DominantDriversType.MonetaryPolicyAccommodative))
        {
            score += 5;
        }
        if (dominantDrivers.Contains(DominantDriversType.DebtLevelHigh))
        {
            score += 4;
        }
        if (dominantDrivers.Contains(DominantDriversType.MonetaryPolicyTight))
        {
            score -= 5;
        }

        return score;
    }
}
