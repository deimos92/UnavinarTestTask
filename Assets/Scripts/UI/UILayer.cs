using UnityEngine;

namespace UnavinarTestTask
{
    public class UILayer : MonoBehaviour
    {
       public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}
