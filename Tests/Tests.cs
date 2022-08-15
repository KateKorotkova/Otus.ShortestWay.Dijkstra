using NUnit.Framework;
using Otus.ShortestWay.Dijkstra.Logic;
using Otus.ShortestWay.Dijkstra.Logic.Dtos;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Can_Find_Way_Via_Dijkstra_Example_From_Wiki()
        {
            var adjacencyMatrix = new[,]
            {
                {0, 7, 9, 0, 0, 14},
                {7, 0, 10, 15, 0, 0},
                {9, 10, 0, 11, 0, 2},
                {0, 15, 11, 0, 6, 0},
                {0, 0, 0, 6, 0, 9},
                {14, 0, 2, 0, 9, 0}
            };


            var result = new DijkstraAlgorithm().Run(adjacencyMatrix);


            Assert.That(result.Length, Is.EqualTo(6));
            Assert.That(result[0], Is.EqualTo(new Edge(null, 0, 0)));
            Assert.That(result[1], Is.EqualTo(new Edge(0, 1, 7)));
            Assert.That(result[2], Is.EqualTo(new Edge(0, 2, 9)));
            Assert.That(result[3], Is.EqualTo(new Edge(2, 3, 20)));
            Assert.That(result[4], Is.EqualTo(new Edge(5, 4, 20)));
            Assert.That(result[5], Is.EqualTo(new Edge(2, 5, 11)));
        }
    }
}