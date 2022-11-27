using UnityEngine;

namespace UnavinarTestTask.Assets.Scripts
{
    public class Barrier : MonoBehaviour
    {
        private GameObject _barrierUnitPrefab;
        private Vector3 _offset;
        private int[,] _barrierArray; 
        

        private void Awake()
        {
            SetupThis();            
        }
        
        private void SetupThis()
        {
            _barrierUnitPrefab = Game.instance.GameSettings.BarrierUnitPrefab;
            _offset = Game.instance.GameSettings.BarrierOffset;

            _barrierArray = Game.instance.BarriersArrays[Random.Range(0, 4)];
            FigurePlacer.PlaceFigure(_barrierUnitPrefab, _barrierArray, _offset, transform);
        }
    }
}
