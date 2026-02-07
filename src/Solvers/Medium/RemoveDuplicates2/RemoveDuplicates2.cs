using System.Text.Json;

namespace Problems.Solvers;

/// <summary>
/// Difficulty: Easy
/// </summary>
public static partial class Solver
{
	private static int RemoveDuplicates2(int[] nums)
	{
		if (nums.Length <= 2)
			return nums.Length;

		int j = 2;

		for (int i = 2; i < nums.Length; i++)
		{
			if (nums[i] != nums[j - 2])
			{
				nums[j] = nums[i];
				j++;
			}
		}

		return j;
	}


	// TODO: posso passar um arquivo teste
	public static void SolveRemoveDuplicates2Problem()
    {
		var exectionData = new List<int[]>
        {
			//([1,1,1,2,2,3]),
			([0,0,1,1,1,1,2,3,3]),
        };

        int i = 1;
        foreach(var nums1 in exectionData)
        {
            var result = RemoveDuplicates2(nums1);
            Console.WriteLine($"[{nameof(SolveRemoveDuplicates2Problem)}] - Execution {i++}:");
			Console.WriteLine("Result: " + result);
            Console.WriteLine();
        }
    }
}
