using UnityEngine;
using UnavinarTestTask.Assets.Scripts.Game;

namespace UnavinarTestTask.Assets.Scripts.Entities
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
            _barrierUnitPrefab = Level.Instance.GameSettings.BarrierUnitPrefab;
            _offset = Level.Instance.GameSettings.BarrierOffset;

            float i = Random.Range(0f, 100f);
            {
                if (i < 25)
                    _barrierArray = Level.Instance.BarriersArrays[0];
                if (i >= 25 && i < 50)
                    _barrierArray = Level.Instance.BarriersArrays[1];
                if (i >= 50 && i < 75)
                    _barrierArray = Level.Instance.BarriersArrays[2];
                if (i >= 75 && i <= 100)
                    _barrierArray = Level.Instance.BarriersArrays[3];
            }

            FigurePlacer.PlaceFigure(_barrierUnitPrefab, _barrierArray, _offset, transform);
        }
    }
}
