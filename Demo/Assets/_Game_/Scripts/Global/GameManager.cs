using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using it.amalfi.Pearl.level;
using it.amalfi.Pearl;
using it.demo.player;

namespace it.demo
{
    public class GameManager : MonoBehaviour
    {
        #region Inspector Fields
        [SerializeField]
        [Tooltip("Game Version")]
        private string gameVersion = "1";
        [SerializeField]
        [Tooltip("The actual level")]
        private LevelEnum actualLevel;
        [SerializeField]
        [Tooltip("Enable or disable mouse")]
        private bool enableMouse;
        #endregion

        #region Private Fields
        private LevelSystem sceneManager;
        private CursorEnable cursorEnable;
        #endregion

        #region Propieties
        public LevelEnum ActualLevel { get { return actualLevel; } }

        public string GameVersion { get { return gameVersion; } }
        #endregion

        #region Unity CallBacks
        private void Awake()
        {
            sceneManager = new SpecificLevelSystem();
            cursorEnable = new CursorEnable(enableMouse);
            actualLevel = sceneManager.ReturnLevel();
        }
        #endregion

        #region Public Methods
        public void NewLevel(LevelEnum newLevel)
        {
            actualLevel = newLevel;
            sceneManager.NewScene(newLevel);
        }

        public void EnableMouse(bool enable)
        {
            cursorEnable.Enable = enable;
        }

        public void StartGame(LevelEnum level)
        {
            NewLevel(level);
        }
        #endregion

        #region Private Methods
        private string LevelToString(LevelEnum level)
        {
            return sceneManager.LevelToString(level);
        }
        #endregion
    }
}
