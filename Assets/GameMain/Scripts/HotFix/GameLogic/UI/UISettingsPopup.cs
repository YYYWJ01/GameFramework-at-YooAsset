using System.Collections;
using System.Collections.Generic;
using Breeze.Utils;
using GameMain;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace Breeze.UILogic
{
    public class UISettingsPopup : UIFormLogic
    {
        private Transform _btnBg;
        private Transform _rootMain;
        private Transform _btnClose;
        private Transform _btnSave;
        private Transform _btnResetProgress;
        private Transform _btnHelp;
        private Transform _btnInfo;
        private Toggle _toggleGirl;
        private Toggle _toggleBoy;
        private Slider _soundSlider;
        private Slider _musicSlider;
        private Image _imgSoundSliderBg;
        private Image _imgMusicSliderBg;

        private void Awake()
        {
            _btnBg = transform.Find("Bg");
            _rootMain = transform.Find("Main");
            _btnClose = _rootMain.Find("CloseButton/Button");
            _btnSave = _rootMain.Find("SaveButton/Image");
            _btnResetProgress = _rootMain.Find("ResetProgressButton/Image");
            _btnHelp = _rootMain.Find("HelpInfoButtons/HelpButton/Image");
            _btnInfo = _rootMain.Find("HelpInfoButtons/InfoButton/Image");

            _toggleGirl = _rootMain.Find("Avatars/ToggleGroup/Toggle1").GetComponent<Toggle>();
            _toggleBoy = _rootMain.Find("Avatars/ToggleGroup/Toggle2").GetComponent<Toggle>();

            _soundSlider = _rootMain.Find("Slider/SoundSlider").GetComponent<Slider>();
            _musicSlider = _rootMain.Find("Slider/MusicSlider").GetComponent<Slider>();

            _imgSoundSliderBg = _rootMain.Find("Slider/SoundSlider/Background").GetComponent<Image>();
            _imgMusicSliderBg = _rootMain.Find("Slider/MusicSlider/Background").GetComponent<Image>();

            MEventTriggerListener.GetListener(_btnBg).onPointerClick += OnClickBtnBg;
            MEventTriggerListener.GetListener(_btnClose).onPointerClick += OnClickBtnClose;
            MEventTriggerListener.GetListener(_btnSave).onPointerClick += OnClickBtnSave;
            MEventTriggerListener.GetListener(_btnResetProgress).onPointerClick += OnClickBtnResetProgress;
            MEventTriggerListener.GetListener(_btnHelp).onPointerClick += OnClickBtnHelp;
            MEventTriggerListener.GetListener(_btnInfo).onPointerClick += OnClickBtnInfo;

            MEventTriggerListener.AddToggleOnValueChanged(_toggleGirl,OnClickToggleGirl);
            MEventTriggerListener.AddToggleOnValueChanged(_toggleBoy,OnClickToggleBoy);

            MEventTriggerListener.AddSliderOnValueChanged(_soundSlider,onClickSoundSlider);
            MEventTriggerListener.AddSliderOnValueChanged(_musicSlider,onClickMusicSlider);
        }

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            // 处理属性用户性别选择标识
            var tempSexState = GameModule.Setting.GetBool(Constant.Setting.PlayerSex, true);
            if (tempSexState) {
                _toggleGirl.isOn = tempSexState;
            } else {
                _toggleBoy.isOn = !tempSexState;
            }

            var tempSoundMuted = GameModule.Setting.GetBool(Constant.Setting.SoundMuted, false);
            _soundSlider.value = tempSoundMuted ? 1 : 0;
            var tempSSliderName = tempSoundMuted ? "Popups/Settings/SliderGreen" : "Popups/Settings/SliderGrey";
            _imgSoundSliderBg.SetSprite("Test",tempSSliderName);

            var tempMusicMuted = GameModule.Setting.GetBool(Constant.Setting.MusicMuted, false);
            _musicSlider.value = tempMusicMuted ? 1 : 0;
            var tempMSliderName = tempMusicMuted ? "Popups/Settings/SliderGreen" : "Popups/Settings/SliderGrey";
            _imgMusicSliderBg.SetSprite("Test",tempMSliderName);
        }

        private void OnClickBtnBg(GameObject go, PointerEventData eventData)
        {
            StartCoroutine(MUtils.InvokeOnClickCloseAction(this.UIForm,_rootMain));
        }

        private void OnClickBtnClose(GameObject go, PointerEventData eventData)
        {
            StartCoroutine(MUtils.InvokeOnClickCloseAction(this.UIForm,_rootMain));
        }

        private void OnClickBtnSave(GameObject go, PointerEventData eventData)
        {
            Debug.Log(" 保存所有设置! ");
            GameModule.Setting.Save();
        }

        private void OnClickBtnResetProgress(GameObject go, PointerEventData eventData)
        {
            Debug.Log(" 重置所有设置! ");
            GameModule.Setting.RemoveAllSettings();
        }

        private void OnClickBtnHelp(GameObject go, PointerEventData eventData)
        {
            //TODO
        }

        private void OnClickBtnInfo(GameObject go, PointerEventData eventData)
        {
            //TODO
        }

        private void OnClickToggleGirl(bool value)
        {
            GameModule.Setting.SetBool(Constant.Setting.PlayerSex, value);
        }

        private void OnClickToggleBoy(bool value)
        {
            //TODO
        }

        private void onClickSoundSlider(float value)
        {
            var tempMuted = value == 1;
            GameModule.Setting.SetBool(Constant.Setting.SoundMuted, tempMuted);
            GameModule.Sound.Mute(SoundGroup.Sound,tempMuted);
            GameModule.Sound.Mute(SoundGroup.UISound,tempMuted);

            var tempSSliderName = tempMuted ? "Popups/Settings/SliderGreen" : "Popups/Settings/SliderGrey";
            _imgSoundSliderBg.SetSprite("Test",tempSSliderName);
        }

        private void onClickMusicSlider(float value)
        {
            var tempMuted = value == 1;
            GameModule.Setting.SetBool(Constant.Setting.MusicMuted, tempMuted);
            GameModule.Sound.Mute(SoundGroup.Music,tempMuted);

            var tempMSliderName = tempMuted ? "Popups/Settings/SliderGreen" : "Popups/Settings/SliderGrey";
            _imgMusicSliderBg.SetSprite("Test",tempMSliderName);
        }
    }
}

