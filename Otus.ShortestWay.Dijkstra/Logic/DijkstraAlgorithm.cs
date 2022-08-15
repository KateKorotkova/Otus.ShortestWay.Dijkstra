using System.Collections.Generic;
using System.Linq;
using Otus.ShortestWay.Dijkstra.Logic.Dtos;

namespace Otus.ShortestWay.Dijkstra.Logic
{
    public class DijkstraAlgorithm
    {
        public Edge[] Run(int[,] adjacencyMatrix)
        {
            var distances = InitDistances(adjacencyMatrix);

            var fullyProcessedVertexes = new List<int>();

            for (var j = 0; j < adjacencyMatrix.GetLength(1); j++)
            {
                var vertexWithMinWeight = GetVertexWithMinWeight(distances, fullyProcessedVertexes);
                var weightForVertexFrom = distances.First(x => x.To == vertexWithMinWeight);

                var adjacencyVertexes = GetAdjacencyVertexes(adjacencyMatrix, vertexWithMinWeight);

                for (var i = 0; i < adjacencyVertexes.Length; i++)
                {
                    var vertexTo = adjacencyVertexes[i];

                    if (fullyProcessedVertexes.Contains(vertexTo))
                        continue;

                    var weight = adjacencyMatrix[vertexWithMinWeight, vertexTo];
                    var possibleNewWeight = weightForVertexFrom.Weight + weight;

                    var existedWay = distances.First(x => x.To == vertexTo);

                    if (possibleNewWeight < existedWay.Weight)
                    {
                        existedWay.From = vertexWithMinWeight;
                        existedWay.Weight = possibleNewWeight;
                    }
                }

                fullyProcessedVertexes.Add(vertexWithMinWeight);
            }

            return distances.ToArray();
        }


        #region Support Methods

        private List<Edge> InitDistances(int[,] adjacencyMatrix)
        {
            var distances = new List<Edge>();

            for (var i = 0; i < adjacencyMatrix.GetLength(1); i++)
            {
                var weight = i == 0 ? 0 : int.MaxValue;
                
                distances.Add(new Edge(null, i, weight));
            }

            return distances;
        }

        private int GetVertexWithMinWeight(List<Edge> edges, List<int> fullyProcessedVertexes)
        {
            return edges.Where(x => !fullyProcessedVertexes.Contains(x.To)).OrderBy(x => x.Weight).First().To;
        }

        private int[] GetAdjacencyVertexes(int[,] matrix, int vertex)
        {
            var adjacencyVertexes = new List<int>();
            for (var i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[vertex, i] != 0)
                {
                    adjacencyVertexes.Add(i);
                }
            }

            return adjacencyVertexes.ToArray();
        }

        #endregion
    }
}
