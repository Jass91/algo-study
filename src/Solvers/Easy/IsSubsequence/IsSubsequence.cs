using System.Text.Json;

namespace Problems.Solvers;

/// <summary>
/// Difficulty: Easy
/// </summary>
public static partial class Solver
{
	private static bool IsSubsequence(string s, string t)
	{
		var j = 0;
		for (var i = 0; i < t.Length; i++)
		{
			if (j >= s.Length)
				break;

			if (s[j] == t[i])
				j++;
			
		}

		return j >= s.Length;
	}

	// TODO: posso passar um arquivo teste
	public static void SolveIsSubsequenceProblem()
	{
		var exectionData = new List<(string, string)>
		{
			("abc","ahbgdc"),
			("axc","ahbgdc"),
		};

		int i = 1;
		foreach (var (s, t) in exectionData)
		{
			var result = IsSubsequence(s, t);
			Console.WriteLine($"[{nameof(SolveIsSubsequenceProblem)}] - Execution {i++}:");
			Console.WriteLine("Output: " + result);
			Console.WriteLine();
		}
	}
}