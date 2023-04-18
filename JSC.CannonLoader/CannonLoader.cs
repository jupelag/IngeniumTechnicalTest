using JSC.CannonLoader.Contracts;

namespace JSC.CannonLoader
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

            return _searchStrategy.Search(heights);
        }
    }
}