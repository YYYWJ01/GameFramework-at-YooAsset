using System.Collections;
using System.Collections.Generic;
using Breeze.Utils;
using GameFramework.Event;
using GameMain;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityGameFramework.Runtime;

namespace Breeze.UILogic
{
    public class UIHome : UIFormLogic
    {
        private Transform _btnPlay;
        private Transform _btnSetting;
        private Transform _btnSound;
        private Transform _btnMusic;

        private void Awake()
        {
            _btnPlay = transform.Find("Main/PlayButton/PlayButton");
            _btnSetting = transform.Find("Main/Buttons/SettingsButton/Button");
            _btnSound = transform.Find("Main/Buttons/SoundButton/Button");
            _btnMusic = transform.Find("Main/Buttons/MusicButton/Button");

            MEventTriggerListener.GetListener(_btnPlay).onPointerClick += OnClickBtnPlay;
            MEventTriggerListener.GetListener(_btnSetting).onPointerClick += OnClickBtnSetting;
            MEventTriggerListener.GetListener(_btnSound).onPointerClick += OnClickBtnSound;
            MEventTriggerListener.GetListener(_btnMusic).onPointerClick += OnClickBtnMusic;
        }

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
        }

        public override void RegisterEvent()
        {
            // GameModule.Event.Subscribe(TestEventArgs.EventId, TestEventHandle);
        }

        public override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            // Debug.Log(" elapseSeconds : "+elapseSeconds+" realElapseSeconds : "+realElapseSeconds);
        }

        private void OnClickBtnPlay(GameObject go, PointerEventData eventData)
        {
            MUtils.PlayBtnAnimatonAndSound(go.transform.parent,Sound.UButton);

        }

        private void OnClickBtnSetting(GameObject go, PointerEventData eventData)
        {
            MUtils.PlayBtnAnimatonAndSound(go.transform.parent,Sound.UButton);

            StartCoroutine(MUtils.InvokeOnClickOpenAction(UI.SettingsPopup));
        }

        private void OnClickBtnSound(GameObject go, PointerEventData eventData)
        {
            Debug.Log(" onClickBtn 3 ! "+go.name);

            List<object> listArray = new List<object>{"Item 1", 2, true};
            GameModule.Event.Fire(this, TemplateEventArgs.Create(listArray));
        }   

        private void OnClickBtnMusic(GameObject go, PointerEventData eventData)
        {
            StartCoroutine(MUtils.InvokeOnClickOpenAction(UI.Template));
        }

        protected override void Close()
        {
            base.Close();
        }

        private void OnDestroy() {
            
        }
    }  
}

