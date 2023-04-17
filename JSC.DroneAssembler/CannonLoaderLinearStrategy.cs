using JSC.DroneAssembler.Contracts;

namespace JSC.DroneAssembler;

public class CannonLoaderLinearStrategy:ICannonLoaderSearchStrategy
{
    public int Search(IReadOnlyList<uint> heights, int maximumPeaksPossible, int firstPeakIndex,
        int lastPeakIndex)
    {
        for (int i = maximumPeaksPossible; i != 0; i--)
        {
            int nCannons = 1;
            var peakIndex = firstPeakIndex;
            for (int j = firstPeakIndex + 1; j <= lastPeakIndex; j++)
            {
                if (heights[j] > heights[j - 1] && heights[j] > heights[j + 1])
                {
                    if (j - peakIndex >= i)
                    {
                        peakIndex = j;
                        nCannons++;
                    }
                }
            }

            if (nCannons == i)
            {
                return i;
            }
        }

        return 0;
    }
}