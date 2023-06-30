using System.Collections;
using System.Collections.Generic;
using Breeze.Utils;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityGameFramework.Runtime;
namespace Breeze.UILogic
{
    public class UILoading : UIFormLogic
    {
        private Transform _btnStart;
        private Transform _btnAbout;

        private void Awake()
        {
            _btnStart = transform.Find("Main/Start");
            _btnAbout = transform.Find("Main/About");

            MEventTriggerListener.GetListener(_btnStart).onPointerClick += OnClickBtnTest1;
            MEventTriggerListener.GetListener(_btnAbout).onPointerClick += OnClickBtnTest2;
        }

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            Debug.Log(" OnInit UILoading !");
        }

        public override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            // Debug.Log(" elapseSeconds : "+elapseSeconds+" realElapseSeconds : "+realElapseSeconds);
        }

        public void OnClickBtnTest1(GameObject go, PointerEventData eventData)
        {
            Debug.Log(" onClickBtn 1 ! "+go.name);
            MUtils.PlayBtnAnimatonAndSound(go.transform.parent);

            StartCoroutine(MUtils.InvokeOnClickOpenAction(UI.Home));
        }

        public void OnClickBtnTest2(GameObject go, PointerEventData eventData)
        {
            MUtils.PlayBtnAnimatonAndSound(go.transform.parent);
            Debug.Log(" onClickBtn 2 ! "+go.name);

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
