using Cysharp.Threading.Tasks;

namespace Services
{
    public class UserAuthorizationService
    {
        public UserAuthorizationService()
        {
            
        }


        public async UniTask<bool> Connect()
        {
            await UniTask.WaitForSeconds(1);


            return true;
        }
    }
}