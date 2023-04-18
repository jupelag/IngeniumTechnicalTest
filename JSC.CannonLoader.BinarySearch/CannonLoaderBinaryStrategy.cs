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

            return GetCannonsByBinarySearch(heights, maximumPeaksPossible, firstPeakIndex, lastPeakIndex);
        }

        private static int GetCannonsByBinarySearch(IReadOnlyList<uint> heights, int maximumPeaksPossible, int firstPeakIndex,
            int lastPeakIndex)
        {
            int left = 1;
            int right = maximumPeaksPossible;
            int result = -1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                var nCannons = CountCannons(heights, firstPeakIndex, lastPeakIndex, mid);

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

        private static int CountCannons(IReadOnlyList<uint> heights, int firstPeakIndex, int lastPeakIndex, int mid)
        {
            int nCannons = 1;
            var peakIndex = firstPeakIndex;

            for (int j = firstPeakIndex + 1; j <= lastPeakIndex; j++)
            {
                var isPeak = heights[j] > heights[j - 1] && heights[j] > heights[j + 1];
                if (isPeak)
                {
                    if (j - peakIndex >= mid)
                    {
                        peakIndex = j;
                        nCannons++;
                    }
                }
            }

            return nCannons;
        }
    }
}
