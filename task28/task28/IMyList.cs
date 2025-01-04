namespace task28
{
    public interface IMyList<T> : IMyCollection<T>
    {
        void Add(int index, T element);
        void AddAll(int index, IMyCollection<T> c);
        T Get(int index);
        int IndexOf(object o);
        int LastIndexOf(object o);
        IMyIteratorList<T> ListIterator();
        IMyIteratorList<T> ListIterator(int index);
        T Remove(int index);
        void Set(int index, T element);
        IMyList<T> SubList(int fromIndex, int toIndex);
    }
}