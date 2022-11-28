using UnityEngine;
using UnavinarTestTask.Assets.Scripts.Game;

namespace UnavinarTestTask.Assets.Scripts.Entities
{
    public class Field : MonoBehaviour
    {
        private GameObject _fieldUnitPrefab;
        private Vector3 _offset;
        private int _fieldWidth;
        private float _fieldLenght;

        private void Awake()
        {
            SetupThis();
        }

        private void SetupThis()
        {
            _fieldUnitPrefab = Level.Instance.GameSettings.FieldUnitPrefab;
            _offset = Level.Instance.GameSettings.FieldOffset;
            _fieldWidth = Level.Instance.GameSettings.FieldWidth;
            _fieldLenght = Level.Instance.GameSettings.FieldLenght;

            var field = Instantiate(_fieldUnitPrefab, transform);
            field.transform.localScale = new Vector3(_fieldWidth, 2f, _fieldLenght);
            field.transform.localPosition = new Vector3(0, 0, _fieldLenght / 2) + _offset;
        }

    }
}