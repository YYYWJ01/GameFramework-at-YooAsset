using System.Collections;
using System.Collections.Generic;
using Breeze.Utils;
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

            MEventTriggerListener.GetListener(_btnBg).onPointerClick += OnClickBtnBg;
            MEventTriggerListener.GetListener(_btnClose).onPointerClick += OnClickBtnClose;
            MEventTriggerListener.GetListener(_btnSave).onPointerClick += OnClickBtnSave;
            MEventTriggerListener.GetListener(_btnResetProgress).onPointerClick += OnClickBtnResetProgress;
            MEventTriggerListener.GetListener(_btnHelp).onPointerClick += OnClickBtnHelp;
            MEventTriggerListener.GetListener(_btnInfo).onPointerClick += OnClickBtnInfo;

            MEventTriggerListener.AddToggleOnValueChanged(_toggleGirl,OnClickToggleGirl);
            MEventTriggerListener.AddToggleOnValueChanged(_toggleBoy,OnClickToggleBoy);
        }

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
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
            //TODO
        }

        private void OnClickBtnResetProgress(GameObject go, PointerEventData eventData)
        {
            //TODO
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
            Debug.Log(" OnClickToggleGirl value : "+value.ToString());
        }

        private void OnClickToggleBoy(bool value)
        {
            Debug.Log(" OnClickToggleBoy value : "+value.ToString());
        }
    }
}

