using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JSC.DroneAssembler.Contracts;

namespace JSC.DroneAssembler
{
    public class CannonLoaderBinarySearch:ICannonLoaderSearchStrategy
    {
        public int Search(IReadOnlyList<uint> heights, int maximumPeaksPossible, int firstPeakIndex, int lastPeakIndex)
        {
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
