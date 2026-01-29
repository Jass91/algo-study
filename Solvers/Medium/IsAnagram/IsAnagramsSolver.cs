using System.Text.Json;

namespace Problems.Solvers.Medium;

/// <summary>
/// Difficulty: Easy
/// </summary>
public static partial class Solver
{
    // Space: O(1)
    // Time: O(n + m)
    private static bool IsAnagram(string s, string t)
    {
        var length = s.Length;

        // caso base
        if (length != t.Length)
            return false;

        // eu poderia usar um vetor de 26 posicoes O(1)
        // mas o objeto pareceu mais simples e terá no pior caso, 26 chaves O(1)
        var letterCounter = new Dictionary<char, int>();

        for (var i = 0; i < length; i++)
        {
            var c1 = s[i];
            var c2 = t[i];

            if (!letterCounter.ContainsKey(c1))
                letterCounter[c1] = 0;

            if (!letterCounter.ContainsKey(c2))
                letterCounter[c2] = 0;

            // contando
            letterCounter[c1]++;
            letterCounter[c2]--;
        }

        foreach (var c in s)
        {
            var freq = letterCounter[c];
            if (freq != 0)
                return false;
        }

        return true;
    }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             

    // TODO: posso passar um arquivo teste
    public static void SolveIsAnagramsProblem()
    {
        var exectionData = new List<string[]>
        {
            // Output: true
            (["cat","tac"])
        };

        int i = 1;
        foreach(var data in exectionData)
        {
            var execResult = IsAnagram(data[0], data[1]);
            Console.WriteLine($"[{nameof(SolveIsAnagramsProblem)}] - Execution {i++}:");
            Console.WriteLine(execResult);
            Console.WriteLine();
        }
    }
}