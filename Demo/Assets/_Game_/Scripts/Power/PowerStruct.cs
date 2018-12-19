﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace it.twoLives.power
{
    [Serializable]
    public struct PowerStruct
    {
        #region Inspector Fields
        public string name;
        public GameObject prefab;
        public float distanceForInstantiate;
        [Range(0, 255)]
        public byte damage;
        #endregion
    }
}
