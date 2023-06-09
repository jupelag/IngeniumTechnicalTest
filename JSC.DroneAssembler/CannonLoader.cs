﻿using JSC.DroneAssembler.Contracts;
using System;

namespace JSC.DroneAssembler
{
    public class CannonLoader:ICannonLoader
    {
        private readonly ICannonLoaderSearchStrategy _searchStrategy;

        public CannonLoader(ICannonLoaderSearchStrategy searchStrategy)
        {
            _searchStrategy = searchStrategy;
        }
        public int GetCannonCount(IReadOnlyList<uint> heights)
        {
            ArgumentNullException.ThrowIfNull(heights,nameof(heights));
            if (heights.Count == 0) return 0;
            if (heights.Count == 1) return 0;

            var firstPeakIndex = GetFirstPeakIndex(heights);
            if (firstPeakIndex == 0) return 0;

            var lastPeakIndex = GetLastPeakIndex(heights);
            var maximumPeaksPossible = GetMaximumPeaksPossible(heights.Count);

            return _searchStrategy.Search(heights, maximumPeaksPossible, firstPeakIndex, lastPeakIndex);
        }

        private static int GetLastPeakIndex(IReadOnlyList<uint> heights)
        {
            int lastPeakIndex = 0;
            for (int i = heights.Count-1; i > 0; i--)
            {
                if (heights[i] > heights[i - 1] && heights[i] > heights[i + 1])
                {
                    lastPeakIndex = i;
                    break;
                }
            }

            return lastPeakIndex;
        }

        private static int GetFirstPeakIndex(IReadOnlyList<uint> heights)
        {
            int firstPeakIndex = 0;
            for (uint i = 1; i < heights.Count; i++)
            {
                int index = (int)i;
                if (heights[index] > heights[index - 1] && heights[index] > heights[index + 1])
                {
                    firstPeakIndex = index;
                    break;
                }
            }

            return firstPeakIndex;
        }

        public static int GetMaximumPeaksPossible(int numeroNumeros)
        {
            int maxPeaks = (numeroNumeros-2) / 2;
            if (numeroNumeros % 2 == 1)
            {
                maxPeaks++;
            }
            return maxPeaks;
        }
    }
}