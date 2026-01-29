using System.Text.Json;

namespace Problems.Solvers.Medium;

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
        var anagrams = new List<List<string>>();
        var groups = strs.GroupBy(x => x.Length);

        foreach(var grp in groups)
        {
            var first = grp.First();
            var groupElements = grp.ToList();
            var anagramGroup = groupElements.Where(x => IsAnagram(first, x)).ToList();
            var notAnagramGroup = groupElements.Except(anagramGroup).ToList();

            if (anagramGroup.Any())
                anagrams.Add(anagramGroup);

            //if (notAnagramGroup.Any())
            //    anagrams.Add(notAnagramGroup);
        }

        return anagrams;
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
            Console.WriteLine($"[{nameof(SolveIsAnagramsProblem)}] - Execution {i++}:");
            Console.WriteLine(JsonSerializer.Serialize(execResult));
            Console.WriteLine();
        }
    }
}
