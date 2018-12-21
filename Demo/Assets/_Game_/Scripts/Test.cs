using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using it.amalfi.Pearl.actionTrigger;
using it.amalfi.Pearl.multitags;

namespace it.demo.test
{
    public class Test : MonoBehaviour, IEvent
    {
        public void Trigger(Informations informations, List<Tags> tags)
        {
            if (tags.Contains(Tags.Attack))
                Debug.Log("I was hit, I took " + informations.Take<byte>("damage") + " of damage");
            if (tags.Contains(Tags.Use))
                Debug.Log("I have been used");
        }
    }
}
