using it.amalfi.Pearl.input;
using it.amalfi.Pearl.events;
using System;

namespace it.twoLives.player
{
    public class InputReaderPlayerComponent : InputReaderComponent<MessagePlayerEnum>
    {
        public InputReaderPlayerComponent(LogicalManager<MessagePlayerEnum> manager) : base(manager)
        {
        }

        public override void ReadInput(ActionInput actionInput, params object[] valueInput)
        {
            if (actionInput == ActionInput.Movement)
                manager.DoComplexAction(MessagePlayerEnum.GetInputMovement, valueInput[0]);
            if (actionInput == ActionInput.Use || actionInput == ActionInput.Attack)
                manager.DoComplexAction(MessagePlayerEnum.GetInputPower, actionInput);
        }

        public override void AddInput()
        {
            InputReaderManager.Add(ActionInput.Movement, this);
            InputReaderManager.Add(ActionInput.Use, this);
            InputReaderManager.Add(ActionInput.Attack, this);
        }

        public override void RemoveInput()
        {
            if (InputReaderManager.Instance)
            {
                InputReaderManager.Remove(ActionInput.Attack);
                InputReaderManager.Remove(ActionInput.Use);
                InputReaderManager.Remove(ActionInput.Movement);
            }
        }
    }
}
