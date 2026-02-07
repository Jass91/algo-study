using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Problems.Solvers;

public static partial class Solver
{
	private static string Encode(IList<string> strs)
	{
		var encoded = string.Join(string.Empty, strs.Select(s => $"{s.Length}#{s}"));

		return encoded;
	}

	private static List<string> Decode(string s)
	{
		int i = 0;
		var result = new List<string>();

		while (i < s.Length)
		{
			// 1. Achar onde o delimitador '#' está
			int j = i;
			while (s[j] != '#')
			{
				j++;
			}

			// 2. Extrair o número que está entre 'i' e 'j'
			int length = int.Parse(s.AsSpan(i, j - i));

			// 3. Pular o '#'
			i = j + 1;

			// 4. Extrair a string baseada no tamanho lido
			result.Add(s.Substring(i, length));

			// 5. Mover o ponteiro 'i' para o início da próxima seção
			i += length;
		}

		return result;
	}
	public static void SolveEncodeDecodeProblem()
	{
		var exectionData = new List<string[]>
		{
            // Output: [2,3]
            (["Hello", "World"]),
		};

		int i = 1;
		foreach (var strs in exectionData)
		{
			var input = JsonSerializer.Serialize(new { strs });
			
			var encodeResult = Encode(strs);
			var decodeResult = Decode(encodeResult);

			Console.WriteLine($"[{nameof(SolveEncodeDecodeProblem)}] - Execution {i++}:");
			Console.WriteLine($"Input: {input}");
			Console.WriteLine("Output:");
			Console.WriteLine($"Encoded: {encodeResult}");
			Console.WriteLine($"Decoded: {decodeResult}");
			Console.WriteLine();
		}
	}
}

