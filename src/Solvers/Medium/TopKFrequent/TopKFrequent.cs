using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Problems.Solvers;

public static partial class Solver
{
	private static int[] TopKFrequent(int[] nums, int k)
	{
		var counter = new Dictionary<int, int>();

		// loop de contagem de frequencia (otimizada)
		foreach (var n in nums)
			counter[n] = counter.GetValueOrDefault(n) + 1;

		// vamos usar a frequencia dos itens para agrupar nos buckets
		// um numero x, só pode aparecer no maximo n vezes no vetor, sendo n o numero de elementos, ex:
		// n = 3
		// nums = [1,1,1]
		// logo a frequencia f é: 0 <= f <= n
		// portanto, podemos ter (nums.Length + 1) buckets [o +1 eh por isso f <= n]
		var buckets = new List<int>[nums.Length + 1];

		foreach (var (n, freq) in counter)
		{
			buckets[freq] ??= new List<int>();
			buckets[freq].Add(n);
		}

		// 3. Coleta eficiente
		int index = 0;
		var result = new int[k];
		for (int i = buckets.Length - 1; i >= 0 && index < k; i--)
		{
			if (buckets[i] == null) continue;

			// Pega apenas o que falta para completar k
			foreach (var num in buckets[i].Take(k - index))
			{
				result[index++] = num;
			}
		}

		return result;
	}

	public static void SolveTopKFrequentProblem()
	{
		var exectionData = new List<(int, int[])>
		{
            // Output: [2,3]
            (2, [1,2,2,3,3,3]),
            (2, [4,1,-1,2,-1,2,3])
		};

		int i = 1;
		foreach (var (k, nums) in exectionData)
		{
			var input = JsonSerializer.Serialize(new { k, nums });
			
			var execResult = TopKFrequent(nums, k);
			var output = JsonSerializer.Serialize(execResult);

			Console.WriteLine($"[{nameof(TopKFrequent)}] - Execution {i++}:");
			Console.WriteLine($"Input: {input}");
			Console.WriteLine($"Output: {output}");
			Console.WriteLine();
		}
	}
}