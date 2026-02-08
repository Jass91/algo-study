using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Problems.Solvers;

public static partial class Solver
{
    private class DSU<T> where T : notnull
    {
        private int _setCounter;
        
        // Armazenamos o pai de cada elemento. Se não existir no dicionário, o nó ainda não foi "criado".
        private readonly Dictionary<T, T> _parents = new();
        
        // Armazenamos o rank para manter a árvore equilibrada.
        private readonly Dictionary<T, int> _rank = new();

        public int NumSets => _setCounter;

        public void AddSet(T x)
        {
            // Se o elemento já existe, não fazemos nada (evita duplicar contagem)
            if (_parents.ContainsKey(x)) return;

            _parents[x] = x;
            _rank[x] = 0;
            _setCounter++;
        }

        public T Find(T x)
        {
            // Se o pai não for ele mesmo, seguimos para cima e aplicamos Path Compression
            if (!_parents[x].Equals(x))
                _parents[x] = Find(_parents[x]);
            
            return _parents[x];
        }

        public bool Merge(T x, T y)
        {
            T rootX = Find(x);
            T rootY = Find(y);

            if (rootX.Equals(rootY))
                return false;

            // União por Rank para manter a árvore baixa
            if (_rank[rootX] < _rank[rootY])
            {
                _parents[rootX] = rootY;
            }
            else if (_rank[rootX] > _rank[rootY])
            {
                _parents[rootY] = rootX;
            }
            else
            {
                _parents[rootY] = rootX;
                _rank[rootX]++;
            }

            _setCounter--;
            return true;
        }

        // Método auxiliar para verificar se um elemento já foi adicionado
        public bool Contains(T x) => _parents.ContainsKey(x);
    }
    
    private static IList<int> NumIslands2(int m, int n, int[][] positions)
    {
        var dsu = new DSU<int>();
        var answer = new int[positions.Length];

        var directions = new int[][]
        {
            [ -1,  0 ],
            [  1,  0 ],
            [  0, -1 ],
            [  0,  1 ]
        };

        for (int i = 0; i < positions.Length; i++)
        {
            int row = positions[i][0];
            int col = positions[i][1];
            int cellID = row * n + col;

            if (dsu.Contains(cellID))
            {
                answer[i] = dsu.NumSets;
                continue;
            }

            dsu.AddSet(cellID);

            foreach (var dir in directions)
            {
                int nr = row + dir[0];
                int nc = col + dir[1];

                if (nr < 0 || nr >= m || nc < 0 || nc >= n)
                    continue;

                int neighborID = nr * n + nc;

                if (!dsu.Contains(neighborID))
                    continue;

                dsu.Merge(cellID, neighborID);
            }

            answer[i] = dsu.NumSets;
        }

        return answer;
    }

    public static void SolveNumIslands2Problem()
    {
        var executionData = new List<(int[][], int, int)>
        {
            ([[0, 0], [0, 1], [1, 2], [2, 1]], 3, 3)
        };

        int i = 1;
        foreach (var (positions, m, n) in executionData)
        {
            var result = NumIslands2(m, n, positions);

            Console.WriteLine($"[{nameof(SolveNumIslands2Problem)}] - Execution {i++}:");
            Console.WriteLine($"Output: {JsonSerializer.Serialize(result)}");
            Console.WriteLine();
        }
    }
}