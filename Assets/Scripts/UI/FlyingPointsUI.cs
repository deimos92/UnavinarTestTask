using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UnavinarTestTask.Assets.Scripts.UI
{
    public class FlyingPointsUI : UILayer
    {
        //public static FlyingPointsUI Instance {get; private set;}        

        [SerializeField]
        private TextMeshProUGUI _pointsTextPrefab;

        const int POOL_SIZE = 64;

        private Queue<TextMeshProUGUI> _pointsTextPool = new Queue<TextMeshProUGUI>();
        private List<ActiveText> _activeText = new List<ActiveText>();

        private void Awake()
        {
            //Instance = this;
        }

        private Camera _camera;
        private Transform _canvasTransform;

        private void Start()
        {
            _camera = Camera.main;
            _canvasTransform = transform;

            for (int i = 0; i < POOL_SIZE; i++)
            {
                TextMeshProUGUI temp = Instantiate(_pointsTextPrefab, _canvasTransform);
                temp.gameObject.SetActive(false);
                _pointsTextPool.Enqueue(temp);
            }
        }

        private void Update()
        {
            for(int i = 0; i < _activeText.Count; i++)
            {
                ActiveText activeText = _activeText[i];
                activeText.Timer -= Time.deltaTime;

                if (activeText.Timer <= 0f)
                {
                    activeText.UIText.gameObject.SetActive(false);
                    _pointsTextPool.Enqueue(activeText.UIText);
                    _activeText.RemoveAt(i);
                    --i;
                }
                else
                {
                    var color = activeText.UIText.color;
                    color.a = activeText.Timer / activeText.maxTime;
                    activeText.UIText.color = color;

                    activeText.MoveText(_camera);
                }
            }
        }

        public void AddText(int pointsAmount, Vector3 playerPosition)
        {
            var temp = _pointsTextPool.Dequeue();
            temp.text = pointsAmount.ToString();
            temp.gameObject.SetActive(true);

            ActiveText activeText = new ActiveText() { maxTime = 1f };
            activeText.Timer = activeText.maxTime;
            activeText.UIText = temp;
            activeText.unitPosition = playerPosition + Vector3.up;

            activeText.MoveText(_camera);

            _activeText.Add(activeText);
        }
    }   
}
