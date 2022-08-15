namespace Otus.ShortestWay.Dijkstra.Logic.Dtos
{
    public class Edge
    {
        public int? From { get; set; }
        public int To { get; set; }
        public int Weight { get; set; }


        public Edge(int? from, int to, int weight)
        {
            From = from;
            To = to;
            Weight = weight;
        }


        public override bool Equals(object obj)
        {
            var otherEdge = (Edge)obj;

            return From == otherEdge.From && To == otherEdge.To;
        }

        public override string ToString()
        {
            return $"{From} -> {To} ({Weight})";
        }
    }
}