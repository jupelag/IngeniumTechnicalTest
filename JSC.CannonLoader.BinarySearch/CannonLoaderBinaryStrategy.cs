using JSC.CannonLoader.Contracts;
using JSC.DroneAssembler.Shared;

namespace JSC.CannonLoader.BinarySearch
{
    public class CannonLoaderBinaryStrategy:ICannonLoaderSearchStrategy
    {
        public int Search(IReadOnlyList<uint> heights)
        {
            ArgumentNullException.ThrowIfNull(heights, nameof(heights));
            if (heights.Count == 0) return 0;
            if (heights.Count == 1) return 0;

            var firstPeakIndex = heights.GetFirstPeakIndex();
            if (firstPeakIndex == 0) return 0;

            var lastPeakIndex = heights.GetLastPeakIndex();
            var maximumPeaksPossible = heights.GetMaximumPeaksPossible();

            int left = 1;
            int right = maximumPeaksPossible;
            int result = -1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int nCannons = 1;
                var peakIndex = firstPeakIndex;

                for (int j = firstPeakIndex + 1; j <= lastPeakIndex; j++)
                {
                    if (heights[j] > heights[j - 1] && heights[j] > heights[j + 1])
                    {
                        if (j - peakIndex >= mid)
                        {
                            peakIndex = j;
                            nCannons++;
                        }
                    }
                }

                if (nCannons >= mid)
                {
                    result = mid;
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return result;
        }
    }
}
