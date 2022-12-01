using TMPro;
using UnityEngine;

namespace UnavinarTestTask.Assets.Scripts.UI
{
    public class ActiveText
    {
        public TextMeshProUGUI UIText;
        public float maxTime;
        public float Timer;
        public Vector3 unitPosition;

        public void MoveText(Camera camera)
        {
            float delta = 1f - (Timer / maxTime);
            Vector3 position = unitPosition + new Vector3(delta, delta, 0f);
            position = camera.WorldToScreenPoint(position);
            position.z = 0f;

            UIText.transform.position = position;
        }
    }
}
