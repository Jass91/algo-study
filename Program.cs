
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
            case "IsAnagram": Solver.SolveIsAnagramsProblem(); break;
            case "GroupAnagrams": Solver.SolveGroupAnagramsProblem(); break;
            default:
                break;
        }

        return 0;
    }
}


