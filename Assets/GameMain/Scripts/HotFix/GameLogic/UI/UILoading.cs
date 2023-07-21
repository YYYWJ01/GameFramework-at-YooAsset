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

            MEventTriggerListener.GetListener(_btnStart).onPointerClick += OnClickBtnStart;
            MEventTriggerListener.GetListener(_btnAbout).onPointerClick += OnClickBtnAbout;
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

        public void OnClickBtnStart(GameObject go, PointerEventData eventData)
        {
            Debug.Log(" onClickBtn Start ! "+go.name);
            // MUtils.PlayBtnAnimatonAndSound(go.transform.parent);
            // StartCoroutine(MUtils.InvokeOnClickOpenAction(UI.Home));
        }

        public void OnClickBtnAbout(GameObject go, PointerEventData eventData)
        {
            Debug.Log(" onClickBtn About ! "+go.name);
            MUtils.PlayBtnAnimatonAndSound(go.transform.parent);
            StartCoroutine(MUtils.InvokeOnClickCloseAction(this.UIForm));
        }

        protected override void Close()
        {
            base.Close();
        }

        private void OnDestroy() {
            
        }
    }
}
