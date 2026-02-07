
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
            case "IsAnagram": Solver.SolveIsAnagramProblem(); break;
            case "BusRoutes": Solver.SolveBusRoutesProblem(); break;
            case "RotateArray": Solver.SolveRotateArrayProblem(); break;
            case "EncodeDecode": Solver.SolveEncodeDecodeProblem(); break;
            case "TopKFrequent": Solver.SolveTopKFrequentProblem(); break;
            case "RemoveElement": Solver.SolveRemoveElementProblem(); break;
            case "GroupAnagrams": Solver.SolveGroupAnagramsProblem(); break;
            case "IsSubsequence": Solver.SolveIsSubsequenceProblem(); break;
            case "MajorityElement": Solver.SolveMajorityElementProblem(); break;
            case "NumberOfIslands": Solver.SolveNumberOfIslandsProblem(); break;
            case "MergeSortedArray": Solver.SolveMergeSortedArrayProblem(); break;
            case "RemoveDuplicates2": Solver.SolveRemoveDuplicates2Problem(); break;
            default:
                break;
        }

        return 0;
    }
}


