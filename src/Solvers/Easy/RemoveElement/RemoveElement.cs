using System.Text.Json;

namespace Problems.Solvers;

/// <summary>
/// Difficulty: Easy
/// </summary>
public static partial class Solver
{
	private static int RemoveElement(int[] nums, int val)
	{
		int i = 0;
		int j = nums.Length - 1;

		// remove todos os val do final ANTES
		while (j >= 0 && nums[j] == val)
			j--;

		while (i <= j)
		{
			if (nums[i] == val)
			{
				int aux = nums[i];
				nums[i] = nums[j];
				nums[j] = aux;

				j--;
				while (j >= 0 && nums[j] == val)
					j--;
			}
			else
			{
				i++;
			}
		}

		return j + 1;
	}


	// TODO: posso passar um arquivo teste
	public static void SolveRemoveElementProblem()
    {
		var exectionData = new List<(int[], int)>
        {
			([2,4,4,4,0], 4),
			([1,1,1,1,1], 1),
			([3,2,2,3], 3),
			([0,1,2,2,3,0,4,2], 2),
        };

        int i = 1;
        foreach(var (nums1, val) in exectionData)
        {
            var result = RemoveElement(nums1, val);
            Console.WriteLine($"[{nameof(SolveRemoveElementProblem)}] - Execution {i++}:");
			Console.WriteLine("Result: " + result);
            Console.WriteLine();
        }
    }
}
