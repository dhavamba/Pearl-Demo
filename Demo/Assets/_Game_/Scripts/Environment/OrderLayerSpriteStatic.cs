using UnityEngine;

namespace it.twoLives.graphic
{
    public class OrderLayerSpriteStatic : MonoBehaviour
    {
        #region Protected Fields
        protected const int granularity = 100;
        #endregion

        #region UnityCallBacks
        // Use this for initialization
        private void OnEnable()
        {
            ChangeOrderLayer();
        }
        #endregion

        #region Protected Methods
        protected virtual void ChangeOrderLayer()
        {
            GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * granularity) * -1;
        }
        #endregion
    }
}
