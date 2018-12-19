using UnityEngine;
using it.amalfi.Pearl;
using it.amalfi.Pearl.events;
using System.Collections.Generic;
using System;

namespace it.twoLives.camera
{
    public class CameraManager : LogicalSimpleManager
    {
        #region Override Methods
        protected override void AddActionWhenReceiveEvent()
        {
            receiveEvent.Add(EventAction.CreatePlayer, delegate (Dictionary<string, object> objects)
            {
                CreateCamera((Transform)objects["transformPlayer"]);
            });
        }

        public override void SendOut(EventAction messagge, params Tuple<string, object>[] objects)
        {
        }
        #endregion

        #region Private Methods
        private void CreateCamera(Transform transformPlayer)
        {
            transform.position = new Vector3(transformPlayer.position.x, transformPlayer.position.y, transform.position.z);
            transform.parent = transformPlayer;
        }
        #endregion
    }
}
