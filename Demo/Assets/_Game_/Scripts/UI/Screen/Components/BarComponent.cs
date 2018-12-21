using System.Collections;
using System.Collections.Generic;
using it.amalfi.Pearl.events;
using UnityEngine;

namespace it.demo.UI
{
    public class BarComponent : LogicalComponent<MessageScreeenUI>
    {
        #region Private Fields
        private Bar healthBar;
        private readonly float timeForDisableBars;

        private Coroutine coroutine;
        #endregion

        #region Constructors
        public BarComponent(LogicalManager<MessageScreeenUI> manager, GameObject gameObjectHealth, float timeForDisableBars, bool enableBarsInitial) : base(manager)
        {
            this.timeForDisableBars = timeForDisableBars;
            healthBar = gameObjectHealth.GetComponent<Bar>();
            gameObjectHealth.SetActive(enableBarsInitial);
        }
        #endregion

        #region Public Methods
        public void OnScreenHealthBar(float health)
        {
            OpenScreenBar();
            healthBar.SetBar(health);
        }
        #endregion

        #region Private Methods
        private void OpenScreenBar()
        {
            healthBar.gameObject.SetActive(true);

            manager.CancelInvoke(coroutine);
            coroutine = manager.Invoke(OffScreenBars, timeForDisableBars);
        }

        private void OffScreenBars()
        {
            healthBar.gameObject.SetActive(false);
        }
        #endregion
    }

}