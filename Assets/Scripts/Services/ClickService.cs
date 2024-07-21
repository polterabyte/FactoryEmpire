using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Services
{
    public class ClickService
    {
        private int _clickCounter;
        
        public void ApplyClick()
        {
            Debug.Log($"{++_clickCounter}");
        }
    }
}