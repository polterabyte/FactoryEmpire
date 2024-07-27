using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Common
{
    public interface IRepository<out T>
    {
        public IEnumerable<T> All { get; }
        public UniTask<bool> Read();
    }
}