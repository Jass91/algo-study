using System.Text.Json;

namespace Problems.Solvers;

public static partial class Solver
{
    private static int[] FinalPrices(int[] prices)
    {
        var n = prices.Length;
        var answer = (int[])prices.Clone(); // Começa com os preços cheios
        var stack = new Stack<int>();  // Guarda índices

        for (int i = 0; i < n; i++)
        {
            // Enquanto o preço atual (prices[i]) puder dar desconto para o topo da pilha
            while (stack.Count > 0 && prices[stack.Peek()] >= prices[i])
            {
                var discount = prices[i];
                int itemIndex = stack.Pop();
                var currentPrice = prices[itemIndex];

                answer[itemIndex] = currentPrice - discount;
            }

            // Coloca o índice atual na pilha para procurar desconto para ele depois
            stack.Push(i);
        }

        return answer;
    }

    // TODO: posso passar um arquivo teste
    public static void SolveFinalPricesProblem()
    {
        var exectionData = new List<int[]>
        {
            ([8, 4, 6, 2, 3])
        };

        int i = 1;
        foreach(var prices in exectionData)
        {
            var execResult = FinalPrices(prices);
            Console.WriteLine($"[{nameof(SolveFinalPricesProblem)}] - Execution {i++}:");
            Console.WriteLine(JsonSerializer.Serialize(execResult));
            for (var j = 0; j < prices.Length; j++)
                Console.WriteLine($"Item {j}: Preço original = {prices[j]}, Preço final = {execResult[j]}");
            
            Console.WriteLine();
        }
    }
}
