using System.Text.Json;

namespace Problems.Solvers;

/// <summary>
/// Difficulty: Easy
/// </summary>
public static partial class Solver
{
	private static void Merge(int[] nums1, int m, int[] nums2, int n)
	{
		// Três ponteiros:
		int p1 = m - 1;      // Último elemento "real" de nums1
		int p2 = n - 1;      // Último elemento de nums2
		int p = m + n - 1;   // Última posição total de nums1

		// Enquanto houver elementos para comparar em ambos
		while (p1 >= 0 && p2 >= 0)
		{
			if (nums1[p1] > nums2[p2])
			{
				nums1[p] = nums1[p1];
				p1--;
			}
			else
			{
				nums1[p] = nums2[p2];
				p2--;
			}
			p--;
		}

		// Se ainda sobrarem elementos no nums2 (caso o nums1 tenha acabado primeiro)
		// Não precisamos nos preocupar se o nums1 sobrar, pois eles já estão no lugar certo.
		while (p2 >= 0)
		{
			nums1[p] = nums2[p2];
			p2--;
			p--;
		}
	}

	// TODO: posso passar um arquivo teste
	public static void SolveMergeSortedArrayProblem()
    {
		var exectionData = new List<(int[], int, int[], int)>
        {
			([1,2,3,0,0,0], 3, [2,5,6], 3),
            ([0, 0], 0, [1,2], 2),
            ([10, 20, 20, 40, 0, 0], 4, [1,2], 2)
        };

        int i = 1;
        foreach(var (nums1, m, nums2, n) in exectionData)
        {
            Merge(nums1, m, nums2, n);
            Console.WriteLine($"[{nameof(SolveMergeSortedArrayProblem)}] - Execution {i++}:");
			Console.WriteLine("nums1: " + JsonSerializer.Serialize(nums1));
            Console.WriteLine();
        }
    }
}
