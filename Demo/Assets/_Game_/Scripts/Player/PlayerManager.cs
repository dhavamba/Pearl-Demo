using System.Collections.Generic;
using UnityEngine;
using System;
using it.amalfi.Pearl.events;
using it.amalfi.Pearl.multitags;
using it.amalfi.Pearl;
using it.amalfi.Pearl.input;
using static it.amalfi.Pearl.TupleExtend;
using it.demo.power;

namespace it.demo.player
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class PlayerManager : LogicalManager<MessagePlayerEnum>
    {
        #region Inspector Fields
        [Header("Movement Settings")]
        [Range(5, 10)]
        [SerializeField]
        private float speed = 5;
        [SerializeField]
        private Vector2 direction = Vector2.right;
        [Range(2, 10)]
        [SerializeField]
        private int countOldDirection = 4;

        [Header("Status Settings")]
        [SerializeField]
        private byte maxHealth = 100;

        [Header("Powers Settings")]
        [SerializeField]
        private PowerStruct power1;
        [SerializeField]
        private PowerStruct power2;
        #endregion

        #region Unity CallBacks
        protected override void OnAwake()
        {
            ForceManagerSystem forceManager = SingletonPool.Get<ForceManagerSystem>();
            forceManager.AddManagerForce(gameObject.GetInstanceID(), GetComponent<Rigidbody2D>(), gameObject);
        }

        private void Start()
        {
            SendOut(EventAction.CreatePlayer, KeyTuple("transformPlayer", transform));
        }
        #endregion

        #region Override Methods
        protected override void CreateComponents()
        {
            listComponents = new Dictionary<Type, LogicalComponent<MessagePlayerEnum>>
            {
                { typeof(PlayerPowerComponent), new PlayerPowerComponent(this, power1, power2) },
                { typeof(PlayerAnimationComponent), new PlayerAnimationComponent(this) },
                { typeof(PlayerMovementComponent), new PlayerMovementComponent(this, speed, direction, countOldDirection) },
                { typeof(PlayerStatsComponent), new PlayerStatsComponent(this, maxHealth) },
                { typeof(InputReaderComponent<MessagePlayerEnum>), new InputReaderPlayerComponent(this) },
            };
        }

        public override void DoComplexAction(MessagePlayerEnum enumerator, params object[] objects)
        {
            MessagePlayerEnum choose = (MessagePlayerEnum) Convert.ToInt32(enumerator);
            switch (choose)
            {
                case MessagePlayerEnum.GetMovement:
                    GetLogicalComponent<PlayerAnimationComponent>().SetMovementVar((Vector2)objects[0], (bool)objects[1]);
                    break;
                case MessagePlayerEnum.GetInputPower:
                    Vector2 direction = GetLogicalComponent<PlayerMovementComponent>().Direction;
                    GetLogicalComponent<PlayerPowerComponent>().UsePower((ActionInput)objects[0], direction);
                    break;
                case MessagePlayerEnum.GetInputMovement:
                    GetLogicalComponent<PlayerMovementComponent>().SetMovement(((Vector2)objects[0]).normalized);
                    break;
            }
        }

        public override void SendOut(EventAction message, params Tuple<string, object>[] objects)
        {
            switch (message)
            {
                case EventAction.SendHealth:
                    EventsManager.CallEventLocal(EventAction.SendHealth, objects[0]);
                    break;
                case EventAction.CreatePlayer:
                    EventsManager.CallEventLocal(EventAction.CreatePlayer, objects[0]);
                    break;
            }
        }

        protected override void AddActionWhenReceiveEvent()
        {
        }
        #endregion
    }
}
