using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Problems.Solvers;

public static partial class Solver
{
    private static IList<int> InorderTraversal(string mode, TreeNode root)
    {
        return mode != "rec" ?
            InorderTraversalRec(root, new List<int>()) :
            InorderTraversalDFS(root, new List<int>());
    }

    private static IList<int> InorderTraversalRec(TreeNode node, List<int> result)
    {
        if (node is null)
            return new List<int>();

        // tudo a esquerda primeiro
        if (node.left != null)
            InorderTraversalRec(node.left, result);

        // depois a raiz
        result.Add(node.val);

        // tudo a direita depois
        if (node.right != null)
            InorderTraversalRec(node.right, result);

        return result;
    }

    private static IList<int> InorderTraversalDFS(TreeNode root, List<int> result)
    {
        if (root is null)
            return new List<int>();

        var current = root;
        var stack = new Stack<TreeNode>();

        while (current != null || stack.Count > 0)
        {
            // Vai o mais à esquerda possível
            while (current != null)
            {
                stack.Push(current);
                current = current.left;
            }

            // Agora não tem mais esquerda
            // vamos "visitar" (ou seja, guardar o id encontrado)
            current = stack.Pop();
            result.Add(current.val);   // visita

            // Vai para a direita
            current = current.right;
        }

        return result;
    }

    public static void SolveInorderTraversalProblem()
	{
		var exectionData = new List<(string, TreeNode)>
		{
            ("rec", BuildTree([1,null,2,3])),
            ("ite", BuildTree([1,null,2,3])),
            ("rec", BuildTree([1,2,3,4,5,null,8,null,null,6,7,9])),
            ("itet", BuildTree([1,2,3,4,5,null,8,null,null,6,7,9]))
        };

		int i = 1;
		foreach (var (mode, node) in exectionData)
		{
			var input = JsonSerializer.Serialize(new { mode, node });
			
			var result = InorderTraversal(mode, node);

			Console.WriteLine($"[{nameof(SolveInorderTraversalProblem)}] - Execution {i++}:");
			Console.WriteLine($"Input: {input}");
			Console.WriteLine($"Output: {JsonSerializer.Serialize(result)}");
			Console.WriteLine();
		}
	}
}

