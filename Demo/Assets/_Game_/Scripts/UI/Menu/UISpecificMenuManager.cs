using it.amalfi.Pearl.audio;
using it.amalfi.Pearl.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace it.twoLives.UI
{
    public class UISpecificMenuManager : UIMenuManager
    {
        #region Private Methods
        private Dictionary<string, Slider> sliders;
        #endregion

        #region Override Methods
        protected override void SetSpecificUI()
        {
            SetMusicSlider();
        }
        #endregion

        #region Public Methods
        public void ChangeSlide(string nameSlider)
        {
            AudioManager.Instance.SetVolume(nameSlider, sliders[nameSlider].value);
        }
        #endregion

        #region Private Methods
        private void SetMusicSlider()
        {
            Transform parent = transform.Find("OptionsPanel/");
            sliders = new Dictionary<string, Slider>
            {
                { "musicVolume", parent.Find("SliderMusic").GetComponent<Slider>() },
                { "soundEffectVolume", parent.Find("SliderEffects").GetComponent<Slider>() }
            };

            sliders["musicVolume"].value = AudioManager.Instance.GetMusicVolume();
            sliders["soundEffectVolume"].value = AudioManager.Instance.GetSoundEffectVolume();
        }
        #endregion
    }
}
