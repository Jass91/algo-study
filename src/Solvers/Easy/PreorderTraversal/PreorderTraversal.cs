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
	 private class TreeNode
     {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
     }
 
    private static TreeNode BuildTree(int?[] arr)
    {
        if (arr == null || arr.Length == 0 || arr[0] == null)
            return null;

        TreeNode root = new TreeNode(arr[0].Value);
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        int i = 1;

        while (queue.Count > 0 && i < arr.Length)
        {
            TreeNode current = queue.Dequeue();

            // Filho esquerdo
            if (i < arr.Length && arr[i] != null)
            {
                current.left = new TreeNode(arr[i].Value);
                queue.Enqueue(current.left);
            }
            i++;

            // Filho direito
            if (i < arr.Length && arr[i] != null)
            {
                current.right = new TreeNode(arr[i].Value);
                queue.Enqueue(current.right);
            }
            i++;
        }

        return root;
    }

    private static IList<int> PreorderTraversal(string mode, TreeNode root)
    {
        return mode != "rec" ?
            PreorderTraversalRec(root, new List<int>()) :
            PreorderTraversalDFS(root, new List<int>());
    }

    private static IList<int> PreorderTraversalRec(TreeNode root, List<int> result)
    {
        if (root is null)
            return new List<int>();

        var stack = new Stack<TreeNode>();

        stack.Push(root);

        while (stack.Count > 0)
        {
            var currentNode = stack.Pop();

            result.Add(currentNode.val);

            // Root -> Left -> Right
            // por estar usando uma pilha, precisamos empilhar ao contrário da ordem que queremos visitar.

            // right primeiro
            if (currentNode.right != null)
                stack.Push(currentNode.right);

            // left depois
            if (currentNode.left != null)
                stack.Push(currentNode.left);
        }


        return result;
    }

    private static IList<int> PreorderTraversalDFS(TreeNode root, List<int> result)
    {
        if (root is null)
            return new List<int>();

        var stack = new Stack<TreeNode>();

        stack.Push(root);

        while (stack.Count > 0)
        {
            var currentNode = stack.Pop();

            result.Add(currentNode.val);

            // Root -> Left -> Right
            // por estar usando uma pilha, precisamos empilhar ao contrário da ordem que queremos visitar.

            // right primeiro
            if (currentNode.right != null)
                stack.Push(currentNode.right);

            // left depois
            if (currentNode.left != null)
                stack.Push(currentNode.left);
        }


        return result;
    }

    public static void SolvePreorderTraversalProblem()
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
			
			var result = PostorderTraversal(mode, node);

			Console.WriteLine($"[{nameof(SolvePostorderTraversalProblem)}] - Execution {i++}:");
			Console.WriteLine($"Input: {input}");
			Console.WriteLine($"Output: {JsonSerializer.Serialize(result)}");
			Console.WriteLine();
		}
	}
}

