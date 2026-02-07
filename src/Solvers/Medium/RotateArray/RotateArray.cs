using System.Text.Json;

namespace Problems.Solvers;


public static partial class Solver
{
	// V1: Espa o Extra O(n) - A mais intuitiva
	private static int[] RotateArrayV1(int[] nums, int k)
	{
		int n = nums.Length;
		k %= n; // Normaliza k
		var result = new int[n];

		for (int i = 0; i < n; i++)
		{
			// Ideia: Mapear direto a origem para o destino
			result[(i + k) % n] = nums[i];
		}

		return result;
	}

	// V2: In-place O(1) - Substitui  o C clica
	private static int[] RotateArrayV2(int[] nums, int k)
	{
		int n = nums.Length;
		k %= n;
		if (k == 0) return nums;

		int count = 0; // Quantos elementos j  colocamos no lugar certo

		// Come amos do  ndice 0 e, se o ciclo fechar, pulamos para o 1, 2...
		for (int start = 0; count < n; start++)
		{
			int current = start;
			int prevValue = nums[start];

			do
			{
				int next = (current + k) % n; // Destino calculado

				// Swap manual para n o perder o valor atropelado
				int temp = nums[next];
				nums[next] = prevValue;
				prevValue = temp;

				current = next; // Avan a para o pr ximo destino
				count++;        // Um elemento a mais garantido na posi  o correta

			} while (start != current); // Enquanto o ciclo n o fechar no in cio
		}

		return nums;
	}

	private static int[] RotateArrayV3(int[] nums, int k)
	{
		// Chave para o problema:
		// Imagine o array como dois blocos: A e B.
		// Se o array   [1, 2, 3, 4, 5, 6, 7] e k = 3,
		// os  ltimos 3 elementos s o o bloco B.
		// Bloco A: [1, 2, 3, 4]
		// Bloco B: [5, 6, 7]
		// O array original  : AB
		// O objetivo da rota  o   direita   transformar AB em BA.
		// Ou seja: [5, 6, 7, 1, 2, 3, 4].

		k = k % nums.Length;

		// funcao auxiliar
		void Reverse(int[] nums, int start, int end)
		{
			while (start < end)
			{
				var temp = nums[start];
				nums[start] = nums[end];
				nums[end] = temp;
				start++;
				end--;
			}
		}

		// inverter o array completo
		Reverse(nums, 0, nums.Length - 1);

		// Inverta os primeiros k elementos.
		Reverse(nums, 0, k - 1);

		// Inverta os elementos restantes.
		Reverse(nums, k, nums.Length - 1);

		return nums;
	}

	public static void SolveRotateArrayProblem()
	{
		var exectionData = new List<(int[], int, int)>
		{
			([1,2,3,4], 2, 3),
			([1,2,3,4], 3, 1),
			([1,2,3,4,5,6,7], 3, 3),
		};

		int i = 1;
		foreach (var (nums, k, variant) in exectionData)
		{
			var result = variant == 1 ?
				RotateArrayV1(nums, k) : variant == 2 ?
				RotateArrayV2(nums, k) : RotateArrayV3(nums, k);

			Console.WriteLine($"[{nameof(SolveRotateArrayProblem)}] - Execution {i++}:");
			Console.WriteLine("Result: " + JsonSerializer.Serialize(result));
			Console.WriteLine();
		}
	}
}