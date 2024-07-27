using Cysharp.Threading.Tasks;

namespace Services
{
    public interface ISaveLoaderService
    {
        public UniTask<bool> Update();
        public UniTask<bool> Save();
    }
}