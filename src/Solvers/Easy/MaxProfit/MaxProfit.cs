using System.Text.Json;

namespace Problems.Solvers.Medium;

/// <summary>
/// Difficulty: Easy
/// </summary>
public static partial class Solver
{
    private static int MaxProfit(int[] prices)
    {
        // profit = sell - buy
        // queremos maximizar o lucro (profit)
        // logo, precisamos minimizar o preco de compra (buy)
        // se i eh o preco de venda (sell),
        // precisamos encontrar o menor preco de compra (buy) antes do i
        var profit = 0;
        var minPrice = int.MaxValue;
        for (var i = 1; i < prices.Length; i++)
        {
            var sellPrice = prices[i];
            var buyPrice = prices[i - 1];

            if (sellPrice - buyPrice <= 0)
                continue;
            
            minPrice = Math.Min(minPrice, buyPrice);
            profit = Math.Max(profit, sellPrice - minPrice);
        }

        return profit;
    }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             

    // TODO: posso passar um arquivo teste
    public static void SolveMaxProfitProblem()
    {
        var exectionData = new List<int[]>
        {
            ([10,8,7,5,2]),   // Output: 0
            ([10,1,5,6,7,1]), // Output: 6
        };

        int i = 1;
        foreach(var prices in exectionData)
        {
            var execResult = MaxProfit(prices);
            Console.WriteLine($"[{nameof(SolveMaxProfitProblem)}] - Execution {i++}:");
            Console.WriteLine(execResult);
            Console.WriteLine();
        }
    }
}