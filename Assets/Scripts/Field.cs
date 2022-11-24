using UnityEngine;

namespace UnavinarTestTask.Assets.Scripts
{
    public class Field : MonoBehaviour
    {
        [SerializeField]
        private GameObject _fieldUnitPrefab;

        [SerializeField]
        private Material _fieldFigureMaterial;

        private Vector3 _pivot = new Vector3(5.5f, 0, -2f);

        [SerializeField]
        private int _fieldWidth = 11;

        [SerializeField]
        private int _fieldLenght = 100;

        private void Awake()
        {
            var field = Instantiate(_fieldUnitPrefab, transform);
            field.transform.localScale = new Vector3(_fieldWidth, 2f, _fieldLenght);
            field.transform.localPosition = _pivot;
            field.GetComponentInChildren<MeshRenderer>().material = _fieldFigureMaterial;
        }

    }
}