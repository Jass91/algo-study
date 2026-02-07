using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Problems.Solvers;

public static partial class Solver
{
	private static int NumIslands(char[][] grid)
	{
		if (grid is null || grid.Length == 0) return 0;

		int islandsConter = 0;
		var rows = grid.Length;
		var cols = grid[0].Length;
		for (var row = 0; row < rows; row++)
		{
			for (var col = 0; col < cols; col++)
			{
				if (grid[row][col] == '0')
					continue;

				islandsConter++;
				DFS(grid, row, col, rows, cols);
			}
		}

		return islandsConter;
	}

	private static void DFS(char[][] grid, int row, int col, int rows, int cols)
	{
		var nodesToVisit = new Stack<(int row, int col)>();

		grid[row][col] = '0';
		nodesToVisit.Push((row, col));

		// Deslocamentos para: Cima, Baixo, Esquerda, Direita
		int[] rowOffsets = { -1, 1, 0, 0 };
		int[] colOffsets = { 0, 0, -1, 1 };

		while(nodesToVisit.Count > 0)
		{
			var (currentRow, currentCol) = nodesToVisit.Pop();


			// eh que tem 4 direcoes (no acima, abaixo, a esquerda e a direita)
			for (var i = 0; i < 4; i++)
			{
				var neighborRow = currentRow + rowOffsets[i];
				var neighborCol = currentCol + colOffsets[i];

				var isWithinBound = 0 <= neighborRow && neighborRow < rows && 0 <= neighborCol && neighborCol < cols;

				var shouldProcess =
					isWithinBound &&
					grid[neighborRow][neighborCol] == '1';

				if (!shouldProcess)
					continue;

				grid[neighborRow][neighborCol] = '0';
				nodesToVisit.Push((neighborRow, neighborCol));
			}
			
		}

	}

	public static void SolveNumberOfIslandsProblem()
	{
		var exectionData = new List<char[][]>
		{
            // Output: 1
            ([['0','1','1','1','0'],['0','1','0','1','0'],['1','1','0','0','0'],['0','0','0','0','0']]),
		};

		int i = 1;
		foreach (var grid in exectionData)
		{
			var input = JsonSerializer.Serialize(new { grid });
			
			var result = NumIslands(grid);

			Console.WriteLine($"[{nameof(SolveNumberOfIslandsProblem)}] - Execution {i++}:");
			Console.WriteLine($"Input: {input}");
			Console.WriteLine($"Output: {result}");
			Console.WriteLine();
		}
	}
}

