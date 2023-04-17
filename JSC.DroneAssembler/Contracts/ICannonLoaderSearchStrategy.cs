using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSC.DroneAssembler.Contracts
{
    public interface ICannonLoaderSearchStrategy
    {
        public int Search(IReadOnlyList<uint> heights,int maximumPeaksPossible, int firtsPeakIndex, int lastPeakIndex);
    }
}
