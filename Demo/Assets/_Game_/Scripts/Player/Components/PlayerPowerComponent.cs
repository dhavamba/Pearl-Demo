using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using it.amalfi.Pearl.actionTrigger;
using it.amalfi.Pearl.events;
using it.amalfi.Pearl.input;
using it.twoLives.power;

namespace it.twoLives.player
{
    public class PlayerPowerComponent : LogicalComponent<MessagePlayerEnum>
    {
        #region Private Fields
        private ComplexAction action;
        private Dictionary<ActionInput, PowerStruct> actionToPower;
        private List<PowerStruct> powers;
        #endregion

        #region Constructors
        public PlayerPowerComponent(LogicalManager<MessagePlayerEnum> manager, PowerStruct power1, PowerStruct power2) : base(manager)
        {
            actionToPower = new Dictionary<ActionInput, PowerStruct>
            {
                { ActionInput.Use, power1 },
                { ActionInput.Attack, power2 }
            };
        }
        #endregion

        #region Private Method
        public void UsePower(ActionInput actionInput, Vector2 direction)
        {
            action = Power.CreatePrefab(actionToPower[actionInput], manager.transform, direction).GetComponent<ComplexAction>();
            action?.Add<byte>("damage", actionToPower[actionInput].damage);
            action?.Add<Vector2>("direction", direction);
            action?.SetAction();
        }
        #endregion
    }
}
