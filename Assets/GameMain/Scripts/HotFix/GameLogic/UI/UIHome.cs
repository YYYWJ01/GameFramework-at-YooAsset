using System.Collections;
using Breeze.Utils;
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

            MEventTriggerListener.GetListener(_btnPlay).onPointerClick += OnClickBtnTest1;
            MEventTriggerListener.GetListener(_btnSetting).onPointerClick += OnClickBtnTest2;
            MEventTriggerListener.GetListener(_btnSound).onPointerClick += OnClickBtnTest3;
            MEventTriggerListener.GetListener(_btnMusic).onPointerClick += OnClickBtnTest4;
        }

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
        }

        public override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            // Debug.Log(" elapseSeconds : "+elapseSeconds+" realElapseSeconds : "+realElapseSeconds);
        }

        public void OnClickBtnTest1(GameObject go, PointerEventData eventData)
        {
            Debug.Log(" onClickBtn 1 ! "+go.name);
            MUtils.PlayOnClickBtnAnimaton(go.transform.parent);

            StartCoroutine(MUtils.InvokeOnClickOpenAction(UI.Loading));
        }

        public void OnClickBtnTest2(GameObject go, PointerEventData eventData)
        {
            Debug.Log(" onClickBtn 2 ! "+go.name);
            MUtils.PlayOnClickBtnAnimaton(go.transform.parent);

            StartCoroutine(MUtils.InvokeOnClickCloseAction(this.UIForm));
        }

        public void OnClickBtnTest3(GameObject go, PointerEventData eventData)
        {
            Debug.Log(" onClickBtn 3 ! "+go.name);
        }   

        public void OnClickBtnTest4(GameObject go, PointerEventData eventData)
        {
            Debug.Log(" onClickBtn 4 ! "+go.name);
        }

        private void OnDestroy() {
            
        }
    }  
}

