using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Solvers.Medium;

/// <summary>
/// Difficulty: Easy
/// </summary>
public static partial class Solver
{
    /// <summary>
    /// A palindrome is a string that reads the same forward and backward. It is also case-insensitive and ignores all non-alphanumeric characters.
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    private static bool ValidPalindrome(string s)
    {
        var n = s.Length;

        var i = 0;
        var j = n - 1;
        while (i < j)
        {
            while (i < j && !char.IsLetterOrDigit(s[i])) i++;
            while (i < j && !char.IsLetterOrDigit(s[j])) j--;

            var a = char.ToLowerInvariant(s[i]);
            var b = char.ToLowerInvariant(s[j]);

            if (a != b)
                return false;

            i++;
            j--;
        }

        return true;
    }

    public static void SolveValidPalindromeProblem()
    {
        var exectionData = new List<string>
        {
            "tab a cat", // Output: false
            "Was it a car or a cat I saw?", // Output: true
        };

        int i = 1;
        foreach (var s in exectionData)
        {
            var execResult = ValidPalindrome(s);
            Console.WriteLine($"[{nameof(SolveValidPalindromeProblem)}] - Execution {i++}:");
            Console.WriteLine(execResult);
            Console.WriteLine();
        }
    }
}