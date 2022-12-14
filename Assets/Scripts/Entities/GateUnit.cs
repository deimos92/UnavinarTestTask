using UnityEngine;

namespace UnavinarTestTask.Assets.Scripts.Entities
{
    public class GateUnit : MonoBehaviour
    {
        private Animation _animation;
        private Gate _gateParent;
        

        private void Start()
        {
            _gateParent = GetComponentInParent<Gate>();
            _gateParent.OnCrossing += _gateParent_OnCrossing;
            _animation = GetComponent<Animation>();
        }

        private void _gateParent_OnCrossing()
        {
            _animation.Play();
        }
    }
}
