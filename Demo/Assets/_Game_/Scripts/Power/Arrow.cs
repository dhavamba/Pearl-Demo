using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using it.amalfi.Pearl.actionTrigger;
using it.amalfi.Pearl.multitags;
using it.amalfi.Pearl;

namespace it.twoLives.power
{
    public class Arrow : ComplexAction, IEvent
    {
        [SerializeField]
        private float speed;
        private const float timeForDestroy = 0.01f;

        private void OnDisable()
        {
            ForceManagerSystem.Instance.DisableForce(gameObject.GetInstanceID());
        }

        public override void SetAction()
        {
            transform.rotation = QuaternionExtend.CalculateRotation2D(Take<Vector2>("direction"));
            ForceManagerSystem.Instance.EnableForce(gameObject.GetInstanceID());
            ForceManagerSystem.Instance.AddForce(gameObject.GetInstanceID(), "movement", Take<Vector2>("direction") * speed);
        }

        public void Trigger(Informations informations, List<Tags> tags)
        {
            Invoke("Destroy", timeForDestroy);
        }

        private void Destroy()
        {
            GameObjectExtend.Destroy(gameObject);
        }

        public override void SetAwake()
        {
            ForceManagerSystem.Instance.AddManagerForce(gameObject.GetInstanceID(), GetComponent<Rigidbody2D>());
        }
    }
}
