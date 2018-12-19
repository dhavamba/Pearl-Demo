using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using it.amalfi.Pearl.actionTrigger;
using it.amalfi.Pearl.multitags;

public class Test : MonoBehaviour, IEvent
{
    public void Trigger(Informations informations, List<Tags> tags)
    {
        if (tags.Contains(Tags.Attack))
            Debug.Log("sono stato colpito, ho preso " + informations.Take<byte>("damage") + " di danno");
        if (tags.Contains(Tags.Use))
            Debug.Log("sono stato colpito usato");
    }
}
