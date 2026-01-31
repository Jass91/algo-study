using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Problems.Solvers.Medium;

public static partial class Solver
{
    // vamos supor nums = [1,2,3,4]
    private static int[] ProductExceptSelf(int[] nums, bool debug = false)
    {
        int n = nums.Length;
        var result = new int[n];

        if (debug)
        {
            Console.WriteLine("=== INÍCIO DO PROCESSO ===");
            Console.WriteLine($"Array Original: [{string.Join(", ", nums)}]\n");
        }

        // --- PASSO 1: PREFIXOS (Esquerda para Direita) ---
        result[0] = 1;
        if (debug) Console.WriteLine(">>> FASE 1: Calculando produtos à ESQUERDA");

        for (var i = 1; i < n; i++)
        {
            result[i] = result[i - 1] * nums[i - 1];
            if (debug) 
                DisplayStep(nums, result, i, result[i], "PREFIX");
        }

        // --- PASSO 2: SUFIXOS (Direita para Esquerda) ---
        if (debug) Console.WriteLine("\n>>> FASE 2: Calculando produtos à DIREITA e multiplicando");

        var sufix = 1;
        for (var i = n - 1; i >= 0; i--)
        {
            result[i] = result[i] * sufix;

            if (debug)
                DisplayStep(nums, result, i, sufix, "SUFFIX");
            
            sufix *= nums[i];
        }

        return result;
    }

    private static void DisplayStep(int[] nums, int[] result, int currentIdx, int acumulador, string tipo)
    {
        Console.WriteLine($"--- Analisando Índice {currentIdx} (Valor: {nums[currentIdx]}) ---");

        // Linha visual do Array
        Console.Write("Fila:    ");
        for (int i = 0; i < nums.Length; i++)
        {
            if (i == currentIdx) Console.Write($"[{nums[i]}] "); // Elemento atual "protegido"
            else Console.Write($"{nums[i]}   ");
        }
        Console.WriteLine();

        if (tipo == "PREFIX")
        {
            // No prefixo, mostramos que o valor em result[i] vem da multiplicação dos anteriores
            Console.WriteLine($"Cálculo: Tudo à esquerda de {nums[currentIdx]} é {acumulador}");
        }
        else
        {
            // No sufixo, mostramos a combinação das duas metades
            Console.WriteLine($"Cálculo: (Esquerda: {result[currentIdx] / acumulador}) * (Direita acumulada: {acumulador}) = {result[currentIdx]}");
        }

        Console.WriteLine($"Result atual: [{string.Join(", ", result)}]");
        Console.WriteLine(new string('-', 45));
    }

    public static void SolveProductsArrayExceptSelfProblem()
	{
		var exectionData = new List<int[]>
		{
            ([1,2,3,4]),

            // Output: [2,3]
            ([1,2,2,3,3,3]),
			
            ([4,1,-1,2,-1,2,3])
		};

		int i = 1;
		foreach (var nums in exectionData)
		{
			var input = JsonSerializer.Serialize(new { nums });

			var execResult = ProductExceptSelf(nums, true);
			var output = JsonSerializer.Serialize(execResult);

			Console.WriteLine($"[{nameof(SolveProductsArrayExceptSelfProblem)}] - Execution {i++}:");
			Console.WriteLine($"Input: {input}");
			Console.WriteLine($"Output: {output}");
			Console.WriteLine();
		}
	}
}

