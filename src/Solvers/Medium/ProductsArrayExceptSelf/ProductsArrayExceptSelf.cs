using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Problems.Solvers.Medium;

public static partial class Solver
{
    private static int[] ProductExceptSelf(int[] nums)
    {
        int n = nums.Length;
        int[] res = new int[n];

        // Passo 1: Preencher com os produtos à esquerda (prefixos)
        // res[i] conterá o produto de todos os números antes do índice i
        res[0] = 1; // Não tem nada à esquerda do primeiro
        for (int i = 1; i < n; i++)
        {
            res[i] = res[i - 1] * nums[i - 1];
        }

        // Agora o array 'res' está assim: [1, 1, 2, 6] 
        // (Note que o 6 é 1*2*3, ou seja, tudo à esquerda do 4)

        // Passo 2: Multiplicar pelos produtos à direita (sufixos)
        int sufixo = 1; // Acumulador para o que vem da direita
        for (int i = n - 1; i >= 0; i--)
        {
            // Multiplicamos o que já temos (esquerda) pelo que vem da direita
            res[i] = res[i] * sufixo;

            // Atualizamos o sufixo para o próximo elemento à esquerda
            sufixo *= nums[i];
        }

        return res;
    }

    public static void SolveProductsArrayExceptSelfProblem()
	{
		var exectionData = new List<int[]>
		{
            // Output: [2,3]
            ([1,2,2,3,3,3]),
			([4,1,-1,2,-1,2,3])
		};

		int i = 1;
		foreach (var nums in exectionData)
		{
			var input = JsonSerializer.Serialize(new { nums });

			var execResult = ProductExceptSelf(nums);
			var output = JsonSerializer.Serialize(execResult);

			Console.WriteLine($"[{nameof(SolveProductsArrayExceptSelfProblem)}] - Execution {i++}:");
			Console.WriteLine($"Input: {input}");
			Console.WriteLine($"Output: {output}");
			Console.WriteLine();
		}
	}
}

