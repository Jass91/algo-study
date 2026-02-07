using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Solvers;

/// <summary>
/// Difficulty: Easy
/// </summary>
public static partial class Solver
{
	private static int MajorityElement(int[] nums)
	{
		int found = 0;
		var freq = nums.Length / 2;
		var countMap = new Dictionary<int, int>();
		foreach (var n in nums)
		{
			if (!countMap.ContainsKey(n))
				countMap[n] = 0;

			countMap[n]++;

			if (countMap[n] > freq)
			{
				found = n;
				break;
			}
		}

		return found;
	}

	// TODO: posso passar um arquivo teste
	public static void SolveMajorityElementProblem()
	{
		var exectionData = new List<int[]>
		{
            ([3,2,3]),
            ([2,2,1,1,1,2,2])
		};

		int i = 1;
		foreach (var nums in exectionData)
		{
			var execResult = MajorityElement(nums);
			Console.WriteLine($"[{nameof(SolveMajorityElementProblem)}] - Execution {i++}:");
			Console.WriteLine(execResult);
			Console.WriteLine();
		}
	}
}

