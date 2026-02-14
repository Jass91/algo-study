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

                //DFS(grid, row, col, rows, cols);
                StackDFS(grid, row, col, rows, cols);

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
		int[] rowOffsets = [-1, 1, 0, 0];
		int[] colOffsets = [0, 0, -1, 1];

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

    private static void StackDFS(char[][] grid, int row, int col, int rows, int cols)
    {
        // armazena as posicoes a serem visitadas,
        // cada posicao eh representada por um array de 2 elementos: [row, col]
        var stack = new Stack<int[]>();

        // marca a posicao como visitada (afunda a ilha)
        grid[row][col] = '0';

        stack.Push([row, col]);

        var directions = new int[][]
        {
            [ 0,  1],
            [ 0, -1],
            [ 1,  0],
            [-1,  0]
        };

        while (stack.Count > 0)
        {
            // pega a posicao atual
            var cell = stack.Pop();

            // para cada uma das 4 direcoes (direita, esquerda, baixo, cima)
            foreach (var dir in directions)
            {
                // calcula a posicao do vizinho
                var currentRow = cell[0] + dir[0];
                var currentCol = cell[1] + dir[1];

                var isWithinRowBounds = 0 <= currentRow && currentRow < rows;
                var isWithinColBounds = 0 <= currentCol && currentCol < cols;

                // verifica se o vizinho esta dentro dos limites do grid
                var isWithinBounds = isWithinRowBounds && isWithinColBounds;

                if (!isWithinBounds)
                    continue;

                // se o vizinho ja foi visitado (tranformado em agua), volta
                if (grid[currentRow][currentCol] != '1')
					continue;

                // Importante marcar como visitado antes de colocar na pilha,
				// para evitar colocar o mesmo vizinho mais de uma vez
                
				// marca a posicao como visitada (afunda a ilha)
                grid[currentRow][currentCol] = '0';

                // coloca o vizinho na fila para ser explorado depois
                stack.Push([currentRow, currentCol]);
            }
        }
    }

    public static void SolveNumberOfIslandsProblem()
	{
		var exectionData = new List<char[][]>
		{
            // Output: 1
            ([
				['0','1','1','1','0'],
				['0','1','0','1','0'],
				['1','1','0','0','0'],
				['0','0','0','0','0']
			]),
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

