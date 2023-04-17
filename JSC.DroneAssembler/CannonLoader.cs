using JSC.DroneAssembler.Contracts;

namespace JSC.DroneAssembler
{
    public class CannonLoader:ICannonLoader
    {
        public int GetCannonCount(IReadOnlyList<uint> heights)
        {
            var maxPicos = MaximoPicosPosibles(heights.Count);
            var picosIndices = new List<Pico>(maxPicos);
            for (uint i = 1; i < heights.Count; i++)
            {
                if (maxPicos == picosIndices.Count) break;
                int index = (int)i;
                if (heights[index] > heights[index - 1] && heights[index] > heights[index+1])
                {
                    var previousIndex = picosIndices.LastOrDefault()?.Index ?? int.MaxValue;
                    picosIndices.Add(new Pico()
                    {
                        Index = index,
                        Distance =(previousIndex == int.MaxValue ? int.MaxValue : index - previousIndex),
                    });
                }
            }
            int nPicos = picosIndices.Count;
            int maxDistance = picosIndices.Where(p=>p.Distance != int.MaxValue).Max(i=>i.Distance);
            int nCannons = Math.Min(nPicos, maxDistance);
            for (int i = nCannons; i != 0; i--)
            {
                if (picosIndices.Count(p => p.Distance >= i) >= i)
                {
                    return i;
                }

            }

            return 0;
        }
        public static int MaximoPicosPosibles(int numeroNumeros)
        {
            int max_picos = numeroNumeros / 2;
            if (numeroNumeros % 2 == 1)
            {
                max_picos++;
            }
            return max_picos;
        }

        internal class Pico
        {
            internal int Index { get; set; }
            internal int Distance { get; set; }
        }

    }
}