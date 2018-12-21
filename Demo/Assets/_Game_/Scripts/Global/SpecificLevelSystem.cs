using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using it.amalfi.Pearl.level;
using it.amalfi.Pearl;

namespace it.demo
{
    public class SpecificLevelSystem : LevelSystem
    {
        #region Override Methods
        protected override void SetDictonary()
        {
            levelList = new Bictionary<LevelEnum, string>();
            levelList[LevelEnum.Level] = "Level";

        }
        #endregion
    }
}
