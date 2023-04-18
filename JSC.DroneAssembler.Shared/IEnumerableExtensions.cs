namespace JSC.DroneAssembler.Shared
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Calculate the number of peaks that a list of heights can contain, ignoring the first and last height. 
        /// </summary>
        /// <param name="heights"></param>
        /// <returns>Maximum number of peaks</returns>
        public static int GetMaximumPeaksPossible(this IEnumerable<uint> heights)
        {
            var n = heights.Count();
            int maxPeaks = (n - 2) / 2;
            if (n % 2 == 1)
            {
                maxPeaks++;
            }
            return maxPeaks;
        }

        public static int GetLastPeakIndex(this IEnumerable<uint> heights)
        {
            var indexableHeigts = heights.ToArray();
            int lastPeakIndex = 0;
            for (int i = indexableHeigts.Length - 1; i > 0; i--)
            {
                var isPeak = indexableHeigts[i] > indexableHeigts[i - 1] && indexableHeigts[i] > indexableHeigts[i + 1];
                if (isPeak)
                {
                    lastPeakIndex = i;
                    break;
                }
            }

            return lastPeakIndex;
        }

        public static int GetFirstPeakIndex(this IEnumerable<uint> heights)
        {
            var indexableHeigts = heights.ToArray();
            int firstPeakIndex = 0;
            for (uint i = 1; i < indexableHeigts.Length; i++)
            {
                int index = (int)i;
                if (indexableHeigts[index] > indexableHeigts[index - 1] && indexableHeigts[index] > indexableHeigts[index + 1])
                {
                    firstPeakIndex = index;
                    break;
                }
            }

            return firstPeakIndex;
        }
    }
}