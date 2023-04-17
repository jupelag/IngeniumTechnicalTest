namespace JSC.CannonLoader.Contracts
{
    public interface ICannonLoaderSearchStrategy
    {
        public int Search(IReadOnlyList<uint> heights);
    }
}
