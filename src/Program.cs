
namespace Problems;

class Program
{
    static int Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Usage: problems <problemName>");
            return -1;
        }

        var problem =  args[0];

        switch (problem)
        {
            case "MaxProfit": Solver.SolveMaxProfitProblem(); break;
            case "IsAnagram": Solver.SolveIsAnagramsProblem(); break;
            case "EncodeDecode": Solver.SolveEncodeDecodeProblem(); break;
            case "TopKFrequent": Solver.SolveTopKFrequentProblem(); break;
            case "GroupAnagrams": Solver.SolveGroupAnagramsProblem(); break;
            case "ValidPalindrome": Solver.SolveValidPalindromeProblem(); break;
            case "ProductsArrayExceptSelf": Solver.SolveProductsArrayExceptSelfProblem(); break;
            default:
                break;
        }

        return 0;
    }
}


