using Unity.VisualScripting;
using UnityEngine;

namespace UnavinarTestTask.Assets.Scripts
{
    public class Gate : MonoBehaviour
    {
        private GameObject _gateUnitPrefab;        
        private Vector3 _offset;
        private int[,] _gateArray;
        
        
        private void Awake()
        {
            SetupThis();            
        }

        private void SetupThis()
        {
            _gateUnitPrefab = Game.instance.GameSettings.GateUnitPrefab;            
            _offset = Game.instance.GameSettings.GateOffset;
            _gateArray = Game.instance.GateArray;
            FigurePlacer.PlaceFigure(_gateUnitPrefab, _gateArray, _offset, transform);
            
            /*BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
            MeshRenderer renderer = gameObject.GetComponent<MeshRenderer>();
            boxCollider.center = renderer.bounds.center;
            boxCollider.size = renderer.bounds.size;*/
        }

        private void OnTriggerExit(Collider other)
        {
            
        }
    }
}