namespace AHED.Types
{
    public interface IDeepClone<T>
        where T : class
    {
        T DeepClone();
    }
}
