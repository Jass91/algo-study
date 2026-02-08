using System.Text.Json;

namespace Problems.Solvers;

public static partial class Solver
{
    private static int[] SortedSquares(int[] nums)
    {
        var i = 0;
        var j = nums.Length - 1;
        var r = nums.Length - 1;
        var result = new int[nums.Length];

        // como o vetor eh ordenado e a raiz quadrada sempre produz numemros positivos
        // eu posso comparar os extremos e ir preenchendo o vetor resultado de tras para frente
        while (r >= 0)
        {
            var leftSqr = nums[i] * nums[i];
            var rightSqr = nums[j] * nums[j];

            if (leftSqr < rightSqr)
            {
                j--;
                result[r] = rightSqr;
            }
            else
            {
                i++;
                result[r] = leftSqr;
            }

            r--;
        }

        return result;
    }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             

    // TODO: posso passar um arquivo teste
    public static void SolveSortedSquaresProblem()
    {
        var exectionData = new List<int[]>
        {
            //([-4,-1,0,3,10]),
            ([-7,-3,2,3,11])
        };

        int i = 1;
        foreach(var nums in exectionData)
        {
            var execResult = SortedSquares(nums);
            Console.WriteLine($"[{nameof(SolveSortedSquaresProblem)}] - Execution {i++}:");
            Console.WriteLine(JsonSerializer.Serialize(execResult));
            Console.WriteLine();
        }
    }
}
