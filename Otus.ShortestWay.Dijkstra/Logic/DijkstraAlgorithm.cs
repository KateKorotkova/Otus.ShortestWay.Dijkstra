using System.Collections.Generic;
using System.Linq;
using Otus.ShortestWay.Dijkstra.Logic.Dtos;

namespace Otus.ShortestWay.Dijkstra.Logic
{
    public class DijkstraAlgorithm
    {
        public Edge[] Run(int[,] adjacencyMatrix)
        {
            var fullyProcessedVertexes = new List<int>();

            var distances = InitDistances(adjacencyMatrix);

            for (var j = 0; j < adjacencyMatrix.GetLength(1); j++)
            {
                var edgeWithMinWeight = GetEdgeWithMinWeight(distances, fullyProcessedVertexes);

                var adjacencyVertexes = GetAdjacencyVertexes(adjacencyMatrix, edgeWithMinWeight.To);

                foreach (var vertexTo in adjacencyVertexes)
                {
                    if (fullyProcessedVertexes.Contains(vertexTo))
                        continue;

                    var weightForVertexTo = adjacencyMatrix[edgeWithMinWeight.To, vertexTo];
                    var possibleNewWeight = edgeWithMinWeight.Weight + weightForVertexTo;

                    var existedWay = distances.First(x => x.To == vertexTo);

                    if (possibleNewWeight < existedWay.Weight)
                    {
                        existedWay.From = edgeWithMinWeight.To;
                        existedWay.Weight = possibleNewWeight;
                    }
                }

                fullyProcessedVertexes.Add(edgeWithMinWeight.To);
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

        private Edge GetEdgeWithMinWeight(List<Edge> edges, List<int> fullyProcessedVertexes)
        {
            Edge edge = null;
            var min = int.MaxValue;
            foreach (var e in edges)
            {
                if (e.Weight <= min && !fullyProcessedVertexes.Contains(e.To))
                {
                    min = e.Weight;
                    edge = e;
                }
            }

            return edge;
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
