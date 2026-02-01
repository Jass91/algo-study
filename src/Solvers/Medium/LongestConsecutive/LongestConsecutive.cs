using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Problems.Solvers.Medium;

public static partial class Solver
{
    private static int LongestConsecutive(int[] nums)
    {
        if (nums.Length < 2) return nums.Length;

        // amarzena o tamanho da maior sequência encontrada
        var longestStreak = 0;

        // 1. Criar um Set com todos os números para busca O(1)
        var set = new HashSet<int>(nums);

        foreach (int num in set)
        {
            // 2. Verificamos se 'num' é o início de uma sequência
            // Se o set contém (num - 1), então 'num' NAO é o começo!
            if (set.Contains(num - 1))
                continue;

            int currentNum = num;
            int currentStreak = 1;

            // 3. Contamos quantos números consecutivos existem a partir daqui
            while (set.Contains(currentNum + 1))
            {
                currentNum += 1;
                currentStreak += 1;
            }

            // 4. Atualizamos o recorde global
            longestStreak = Math.Max(longestStreak, currentStreak);
        }

        return longestStreak;
    }

    public static void SolveLongestConsecutiveProblem()
    {
        var exectionData = new List<int[]>
        {
            ([0,-1]), // 2
            ([0,0]),  // 1
            ([2,20,4,10,3,4,5]), // 4
            ([0,3,2,5,4,6,1,1])  // 7
        };

        int i = 1;
        foreach (var nums in exectionData)
        {
            var input = JsonSerializer.Serialize(new { nums });

            var execResult = LongestConsecutive(nums);
            var output = JsonSerializer.Serialize(execResult);

            Console.WriteLine($"[{nameof(SolveLongestConsecutiveProblem)}] - Execution {i++}:");
            Console.WriteLine($"Input: {input}");
            Console.WriteLine($"Output: {output}");
            Console.WriteLine();
        }
    }
}

