﻿ using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using it.amalfi.Pearl.level;
using it.amalfi.Pearl;
using it.amalfi.Pearl.UI;

namespace it.twoLives.UI
{
    public class UIConcretMenuManager : UISpecificMenuManager
    {
        #region Public Methods
        public void NewGame()
        {
            gameObject.SetActive(false);
            GameManager.Instance.StartGame(LevelEnum.Level);
        }
        #endregion

        #region Override Methods
        protected override void SetSpecificUI()
        {
            base.SetSpecificUI();
            isOpenUI = true;
            DoComplexAction(MessageUIMenuEnum.ChangePanel, firstUIObjectEnable);
        }
        #endregion
    }
}
