using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Common
{
    public interface IRepositoryReader<T>
    {
        public UniTask<bool> CreateTable();
        public UniTask<IEnumerable<T>> ReadTable();
        public UniTask RemoveTable();
        public UniTask<bool> AddItem(T item);
        public UniTask<bool> RemoveItem(T item);
    }
}