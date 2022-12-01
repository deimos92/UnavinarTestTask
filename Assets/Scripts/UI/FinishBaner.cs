using UnityEngine;

namespace UnavinarTestTask
{
    public class FinishBaner : MonoBehaviour
    {
        private Animator _animator;

        private void OnEnaled()
        {
            _animator = GetComponent<Animator>();
            _animator.Play("Finished");
        }        
    }
}
