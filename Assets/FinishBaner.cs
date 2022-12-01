using UnityEngine;

namespace UnavinarTestTask
{
    public class FinishBaner : MonoBehaviour
    {
        private Animator _animator;
        
        private void Awake()
        {
            _animator= GetComponent<Animator>();
        }
        private void OnEnaled()
        {
            _animator.Play("Finished");
        }
    }
}
