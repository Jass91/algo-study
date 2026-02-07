using System.Text.Json;

namespace Problems.Solvers;

/// <summary>
/// Difficulty: Medium
/// https://neetcode.io/problems/anagram-groups/question
/// Given an array of strings strs, group all anagrams together into sublists. You may return the output in any order.
/// An anagram is a string that contains the exact same characters as another string, but the order of the characters can be different.
/// 
/// Constraints:
/// 1 <= strs.length <= 1000.
/// 0 <= strs[i].length <= 100
/// strs[i] is made up of lowercase English letters.
/// 
/// Recommended Time & Space Complexity
/// You should aim for a solution with O(m * n) time and O(m) space, 
/// where m is the number of strings and n is the length of the longest string.
/// </summary>
public static partial class Solver
{
    // Space: O(m)
    // Time: O(m * n)
    private static List<List<string>> GroupAnagrams(string[] strs)
    {
		// Dicion rio onde a chave   uma representa  o da contagem de letras
		var res = new Dictionary<string, List<string>>();

		foreach (var s in strs)
		{
			// 1. Criar array de contagem para as 26 letras (a-z)
			//var count = s.Select(c => c - 'a');
			int[] count = new int[26];
			foreach (char c in s)
			{
				count[c - 'a']++;
			}

			// 2. Gerar uma chave  nica baseada nas frequ ncias
			// Exemplo: "eat" vira "1#1#0#0#1#..." (a=1, b=0, c=0, d=0, e=1...)
			string key = string.Join("#", count);

			// 3. Agrupar no dicion rio
			if (!res.ContainsKey(key))
			{
				res[key] = new List<string>();
			}
			res[key].Add(s);
		}

		// Retorna os valores agrupados como uma lista de listas
		return res.Values.ToList();
	}

    // TODO: posso passar um arquivo teste
    public static void SolveGroupAnagramsProblem()
    {
        var exectionData = new List<string[]>
        {
            // Output: [["hat"], ["act", "cat"], ["stop", "pots", "tops"]]
            // (["act", "pots", "tops", "cat", "stop", "hat"]),

            // Output: [["ape"],["and"],["cat"]]
            (["ape","and","cat"])
        };

        int i = 1;
        foreach(var data in exectionData)
        {
            var execResult = GroupAnagrams(data);
            Console.WriteLine($"[{nameof(SolveGroupAnagramsProblem)}] - Execution {i++}:");
            Console.WriteLine(JsonSerializer.Serialize(execResult));
            Console.WriteLine();
        }
    }
}
