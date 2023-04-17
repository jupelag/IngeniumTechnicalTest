using JSC.CannonLoader.Contracts;
using JSC.DroneAssembler.Shared;

namespace JSC.CannonLoader.LinearSearch;

public class CannonLoaderLinearStrategy:ICannonLoaderSearchStrategy
{
    public int Search(IReadOnlyList<uint> heights)
    {
        ArgumentNullException.ThrowIfNull(heights, nameof(heights));
        if (heights.Count == 0) return 0;
        if (heights.Count == 1) return 0;

        var maximumPeaksPossible = heights.GetMaximumPeaksPossible();
        var firstPeakIndex= heights.GetFirstPeakIndex();
        if (firstPeakIndex == 0) return 0;

        var lastPeakIndex = heights.GetLastPeakIndex();

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