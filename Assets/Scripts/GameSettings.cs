using UnityEngine;

namespace UnavinarTestTask.Assets.Scripts
{
    [CreateAssetMenu]
    public class GameSettings : ScriptableObject
    {
        [Header("Player Settings")]
        [SerializeField]
        private GameObject _playerUnitPrefab;
        public GameObject PlayerUnitPrefab => _playerUnitPrefab;

        [SerializeField]
        private Vector3 _playerOffset = new Vector3(0.5f, 2, -0.5f);
        public Vector3 PlayerOffset => _playerOffset;

        [SerializeField]
        private int _playerHeight = 8;
        public int PlayerHeight => _playerHeight;

        [SerializeField]
        private int _branchesCount = 4;
        public int BranchesCount => _branchesCount;

        [SerializeField]
        private float _rotationSpeed = 500f;
        public float RotationSpeed => _rotationSpeed;

        [Header("Gates Settings")]
        [SerializeField]
        private GameObject _gateUnitPrefab;
        public GameObject GateUnitPrefab => _gateUnitPrefab;

        [SerializeField]
        private int _gateWidth = 7;
        public int GateWidth => _gateWidth;

        [SerializeField]
        private Vector3 _gateOffset = new Vector3(-3.5f, 1, 0);
        public Vector3 GateOffset => _gateOffset;

        [Header("Barrier Settings")]
        [SerializeField]
        private GameObject _barrierUnitPrefab;
        public GameObject BarrierUnitPrefab => _barrierUnitPrefab;

        [SerializeField]
        private Vector3 _barrierOffset = new Vector3(-1.5f, 2f, 0);
        public Vector3 BarrierOffset => _barrierOffset;

        [Header("Field Settings")]
        [SerializeField]
        private GameObject _fieldUnitPrefab;
        public GameObject FieldUnitPrefab => _fieldUnitPrefab;

        [SerializeField]
        private Vector3 _fieldOffset = new Vector3(5.5f, 0, -2f);
        public Vector3 FieldOffset => _fieldOffset;

        [SerializeField]
        private int _fieldWidth = 11;
        public int FieldWidth => _fieldWidth;

        [SerializeField]
        private int _fieldLenght = 100;
        public int FieldLenght => _fieldLenght;

    }
}
