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
		// O Coração do Problema:
		// Para qualquer índice i, o produto de todos os outros elementos é composto por duas partes:
		// O produto de tudo o que vem antes de i (à esquerda).
		// O produto de tudo o que vem depois de i (à direita).

		throw new NotImplementedException();
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

