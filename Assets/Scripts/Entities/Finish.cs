using UnityEngine;
using UnavinarTestTask.Assets.Scripts.Game;

namespace UnavinarTestTask.Assets.Scripts.Entities
{
    public class Finish : MonoBehaviour
    {

        private GameObject _finishUnitPrefab;
        private Vector3 _offset;

        private void Awake()
        {
            SetupThis();
        }

        private void SetupThis()
        {
            var settings = Level.Instance.GameSettings;

            _finishUnitPrefab = settings.FinishUnitPrefab;
            _offset = settings.FinishOffset;

            var unit = Instantiate(_finishUnitPrefab, transform);
            unit.transform.localScale = new Vector3(settings.FieldWidth - 2, 1, 2);
            unit.transform.localPosition = _offset;
        }
    }
}
