using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Problems.Solvers;

public static partial class Solver
{
    private static IList<int> PostorderTraversal(string mode, TreeNode root)
    {
        return mode != "rec" ?
            PostorderTraversalDFS(root, new List<int>()) :
            PostorderTraversalDFSRec(root, new List<int>());
    }

    private static IList<int> PostorderTraversalDFSRec(TreeNode node, List<int> result)
    {
        if (node is null)
            return new List<int>();

        // tudo a esquerda primeiro
        if (node.left != null)
            PostorderTraversalDFSRec(node.left, result);

        // tudo a direita depois
        if (node.right != null)
            PostorderTraversalDFSRec(node.right, result);

        // depois a raiz
        result.Add(node.val);

        return result;
    }

    private static  IList<int> PostorderTraversalDFS(TreeNode root, List<int> result)
    {
        var current = root;
        TreeNode prev = null;
        var stack = new Stack<TreeNode>();

        while (current != null || stack.Count > 0)
        {
            // vai o mais à esquerda possível
            while (current != null)
            {
                stack.Push(current);
                current = current.left;
            }

            // aqui tenho o no mais a esquerda possivel
            var peek = stack.Peek();

            // se tem direita e ainda não visitamos
            if (peek.right != null && prev != peek.right)
            {
                current = peek.right;
            }
            else
            {
                result.Add(peek.val);
                prev = stack.Pop();
            }
        }

        return result;
    }
    
    public static void SolvePostorderTraversalProblem()
	{
		var exectionData = new List<(string, TreeNode)>
		{
            ("rec", BuildTree([1,2,3,4,5,null,8,null,null,6,7,9])),
            ("ite", BuildTree([1,2,3,4,5,null,8,null,null,6,7,9])),
        };

		int i = 1;
		foreach (var (mode, node) in exectionData)
		{
			var input = JsonSerializer.Serialize(new { mode, node });
			
			var result = PostorderTraversal(mode, node);

			Console.WriteLine($"[{nameof(SolvePostorderTraversalProblem)}] - Execution {i++}:");
			Console.WriteLine($"Input: {input}");
			Console.WriteLine($"Output: {JsonSerializer.Serialize(result)}");
			Console.WriteLine();
		}
	}
}

