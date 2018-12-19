using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using it.amalfi.Pearl.events;
using it.amalfi.Pearl.input;
using it.amalfi.Pearl;

namespace it.twoLives.player
{
    public class PlayerStatsComponent : LogicalComponent<MessagePlayerEnum>
    {
        #region Private Fields
        private int maxHealth = 100;
        private int actualHealt;
        #endregion

        #region Constructors
        public PlayerStatsComponent(LogicalManager<MessagePlayerEnum> manager, byte maxHealth) : base(manager)
        {
            InitStats(maxHealth);
        }
        #endregion

        #region Private Methods
        private void InitStats(byte maxHealth)
        {
            this.maxHealth = maxHealth;
            actualHealt = maxHealth;
        }

        private void OnChangeHealth()
        {
            float actualHealtInPercent = MathfExtend.Percent(actualHealt, maxHealth);
            manager.SendOut(EventAction.SendHealth, KeyTuple("health", actualHealtInPercent));
        }
        #endregion
    }
}
