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

        return CountCannons(heights, maximumPeaksPossible, firstPeakIndex, lastPeakIndex);
    }

    private static int CountCannons(IReadOnlyList<uint> heights, int maximumPeaksPossible, int firstPeakIndex, int lastPeakIndex)
    {
        for (int i = maximumPeaksPossible; i != 0; i--)
        {
            var nCannons = CountCannonsForNumberOfPeaks(heights, firstPeakIndex, lastPeakIndex, i);

            if (nCannons >= i)
            {
                return i;
            }
        }

        return 0;
    }

    private static int CountCannonsForNumberOfPeaks(IReadOnlyList<uint> heights, int firstPeakIndex, int lastPeakIndex, int i)
    {
        int nCannons = 1;
        var peakIndex = firstPeakIndex;
        for (int j = firstPeakIndex + 1; j <= lastPeakIndex; j++)
        {
            var isPeak = heights[j] > heights[j - 1] && heights[j] > heights[j + 1];
            if (!isPeak) continue;

            var isInCorrectDistance = j - peakIndex >= i;
            if (!isInCorrectDistance) continue;

            peakIndex = j;
            nCannons++;
        }

        return nCannons;
    }
}