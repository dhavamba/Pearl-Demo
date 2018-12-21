using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using it.amalfi.Pearl.events;
using it.amalfi.Pearl;
using it.demo.player;
using System;

namespace it.demo.UI
{
    public class ScreenUIManager : LogicalManager<MessageScreeenUI>
    {
        #region Inspector Fields
        [SerializeField]
        private bool enableBarsInitial = false;
        [SerializeField]
        private float timeForDisableBars = 3f;
        [SerializeField]
        private GameObject prefabPotion;
        #endregion

        #region Override Methods
        protected override void CreateComponents()
        {
            GameObject healthBar = transform.Find("HealthBar").gameObject;

            listComponents = new Dictionary<Type, LogicalComponent<MessageScreeenUI>>
            {
                { typeof(BarComponent), new BarComponent(this, healthBar, timeForDisableBars, enableBarsInitial) },
            };
        }

        protected override void AddActionWhenReceiveEvent()
        {
            receiveEvent.Add(EventAction.SendHealth, delegate (Dictionary<string, object> objects)
            {
                GetLogicalComponent<BarComponent>().OnScreenHealthBar((float)objects["health"]);
            });
        }

        public override void DoComplexAction(MessageScreeenUI enumerator, params object[] objects)
        {
        }

        public override void SendOut(EventAction messagge, params Tuple<string, object>[] objects)
        {
        }
        #endregion
    }
}
