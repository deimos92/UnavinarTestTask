using UnityEngine;

namespace UnavinarTestTask.Assets.Scripts
{
    public class Field : MonoBehaviour
    {

        private GameObject _fieldUnitPrefab;
        private Vector3 _offset;
        private int _fieldWidth;
        private int _fieldLenght;

        private void Awake()
        {
            SetupThis();
            var field = Instantiate(_fieldUnitPrefab, transform);
            field.transform.localScale = new Vector3(_fieldWidth, 2f, _fieldLenght);
            field.transform.localPosition = _offset;
        }

        private void SetupThis()
        {
            _fieldUnitPrefab = Game.instance.GameSettings.FieldUnitPrefab;
            _offset = Game.instance.GameSettings.FieldOffset;
            _fieldWidth = Game.instance.GameSettings.FieldWidth;
            _fieldLenght = Game.instance.GameSettings.FieldLenght;
        }

    }
}