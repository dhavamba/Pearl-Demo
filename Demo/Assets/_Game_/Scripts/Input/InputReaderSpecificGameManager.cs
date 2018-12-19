using UnityEngine;

namespace it.amalfi.Pearl.input
{
    public class InputReaderSpecificGameManager : InputReaderManager
    {
        #region Override Methods
        protected override void UpdateKeyboard()
        {
            if (Input.GetButtonDown("Submit"))
                ReadInput(ActionInput.EntryMenu);
            if (Input.GetButtonDown("Cancel"))
                ReadInput(ActionInput.UseReturnButton);

            if (!pause)
            {
                ReadInput(ActionInput.Movement, GetMovement());

                if (Input.GetButtonDown("Fire1"))
                    ReadInput(ActionInput.Use);

                if (Input.GetButtonDown("Fire2"))
                    ReadInput(ActionInput.Attack);
            }
        }


        protected override void UpdateJoystick()
        {
        }

        protected override StateInput UpdateStateInput()
        {
            return StateInput.Normal;
        }
        #endregion

        #region Private Methods
        private Vector2 GetMovement()
        {
            return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        #endregion
    }
}
