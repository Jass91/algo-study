using System.Collections.Generic;
using System.Text.Json;

namespace Problems.Solvers;


public static partial class Solver
{	
	/// <summary>
	/// Classe auxiliar para representar o nó do grafo
	/// </summary>
	private class Node
	{
		/// <summary>
		/// Representa o Id do onibus
		/// </summary>
		public int Bus { get; private set; }

		/// <summary>
		/// Quantos Onibus ja pegamos ate aqui
		/// </summary>
		public int Hops { get; private set; }

		public Node(int bus, int hops)
		{
			Bus = bus;
			Hops = hops;
		}
	}

	/// <summary>
	/// Eh basicamente um problema de encontrar o menor caminho em grafos
	/// Uma Busca em largura resolveria, no entanto, devido as restricoes do problema
	/// a abordagem se considerar cada parada de onibus como vertices, explodiria, pois
	/// 1 <= routes[i].length <= 10^5 (meu, isso eh muito grande)
	/// no entanto, se considerarmos que um onibus é definido pelo trajeto (paradas) que faz, entao,
	/// nosso problema reduz drasticamente, pois: 
	/// 1 <= routes.length <= 500.
	/// </summary>
	/// <param name="routes"></param>
	/// <param name="source"></param>
	/// <param name="target"></param>
	/// <returns></returns>
	private static int BusRoutes(int[][] routes, int source, int target)
	{
		// vamos encarar uma rota r = [a,b,c...] como sendo um onibus,
		// ou seja, um onibus eh definido pelo seu percurso

		// para o codigo ficar mais legivel, vou renomear a variavel routes para busses
		var busses = routes;

		// Caso especial: você já está lá!
		if (source == target) return 0;

		// 1. MAPEAMENTO: Parada -> Lista onibus
		// responde eficientemente quais onibus passam por uma determinada parada
		var stopToBuses = new Dictionary<int, List<int>>();

		// para cada onibus existente
		for (int bus = 0; bus < busses.Length; bus++)
		{
			// olhamos cada uma de suas paradas
			foreach (var busStop in routes[bus])
			{
				if (!stopToBuses.ContainsKey(busStop))
					stopToBuses[busStop] = new List<int>();

				// anotamos que o onibus 'bus' para no ponto 'busStop'
				stopToBuses[busStop].Add(bus);
			}
		}

		// Se a parada de origem ou destino nem existem no mapa, impossível chegar
		if (!stopToBuses.ContainsKey(source) || !stopToBuses.ContainsKey(target))
			return -1;

		// aqui, devemos encontrar o menor caminho que leva de source ate target
		// como nao existem pesos, uma BFS (busca em largura) se torna adequada
		
		// 2. CONFIGURAÇÃO DA BFS
		var travelQueue = new Queue<Node>();
		var processedStops = new HashSet<int>();
		var boardedBuses = new HashSet<int>();

		// Inicialização: Colocamos todos os ônibus que passam na parada 'source' na fila
		foreach (var bus in stopToBuses[source])
		{
			travelQueue.Enqueue(new Node(bus, hops: 1));
			boardedBuses.Add(bus);
		}

		// 3. O LOOP DA BFS
		while (travelQueue.Any())
		{
			var currentTrip = travelQueue.Dequeue();
			var currentBus = currentTrip.Bus;
			var currentHops = currentTrip.Hops;

			// Verificamos todas as paradas que ESTE ÔNIBUS faz
			foreach (var busStop in routes[currentBus])
			{
				// Encontramos o destino?
				if (busStop == target)
					return currentHops;

				// se ja exploramos essa parada
				if (processedStops.Contains(busStop))
					continue;

				// Se ainda não, vamos ver quais outros ônibus passam pela parada 'busStop'
				foreach (var connectingBus in stopToBuses[busStop])
				{
					// se ja exploramos esse onibus
					if (boardedBuses.Contains(connectingBus))
						continue;

					// do contrario, marcamos ele para explorar mais tarde
					boardedBuses.Add(connectingBus);

					// aqui o hops aumenta, pois encontramos um possivel novo caminho a partir do onibus 'currentBus'
					// para o onibus 'nextBus' usando a parada 'busStop'
					travelQueue.Enqueue(new Node(connectingBus, currentHops + 1));
				}

				// Marcamos a parada como processada para não olhar os ônibus dela de novo
				// afinal, ja olhamos todos os onibus dela no loop acima
				processedStops.Add(busStop);
			}
		}

		// Não encontramos um caminho
		return -1; 
	}

	// TODO: posso passar um arquivo teste
	public static void SolveBusRoutesProblem()
    {
        var exectionData = new List<(int[][], int, int)>
        {
            ([[1,2,7],[3,6,7]], 1, 6)
		};

        int i = 1;
        foreach(var (routes, start, target) in exectionData)
        {
            var execResult = BusRoutes(routes, start, target);
            Console.WriteLine($"[{nameof(SolveBusRoutesProblem)}] - Execution {i++}:");
            Console.WriteLine(execResult);
            Console.WriteLine();
        }
    }
}
