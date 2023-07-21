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
    public class UITemplate : UIFormLogic
    {
        private Transform _btnUIOpen;
        private Transform _btnSendEvent;
        private Transform _btnCancelEvent;
        private Transform _btnPlaySound;
        private Transform _btnPlayMusic1;
        private Transform _btnPlayMusic2;
        private Transform _btnSendUIEvent;
        private Transform _btnCancelUIEvent;
        private Transform _btnSaveLocalData;
        private Transform _btnChangeSaveLocalData;
        private Transform _btnGetSaveLocalData;
        private Transform _btnCloseUI;

        private void Awake()
        {
            Debug.LogWarning(" Awake! ");
            _btnUIOpen = transform.Find("Main/BtnUIOpen");
            _btnSendEvent = transform.Find("Main/BtnSendEvent");
            _btnCancelEvent = transform.Find("Main/BtnCancelEvent");
            _btnPlaySound = transform.Find("Main/BtnPlaySound");
            _btnPlayMusic1 = transform.Find("Main/BtnPlayMusic1");
            _btnPlayMusic2 = transform.Find("Main/BtnPlayMusic2");
            _btnSendUIEvent = transform.Find("Main/BtnSendUIEvent");
            _btnCancelUIEvent = transform.Find("Main/BtnCancelUIEvent");
            _btnSaveLocalData = transform.Find("Main/BtnSaveLocalData");
            _btnChangeSaveLocalData = transform.Find("Main/BtnChangeSaveLocalData");
            _btnGetSaveLocalData = transform.Find("Main/BtnGetSaveLocalData");
            _btnCloseUI = transform.Find("Main/BtnCloseUI");

            MEventTriggerListener.GetListener(_btnUIOpen).onPointerClick += OnClickBtnUIOpen;
            MEventTriggerListener.GetListener(_btnSendEvent).onPointerClick += OnClickBtnSendEvent;
            MEventTriggerListener.GetListener(_btnCancelEvent).onPointerClick += OnClickBtnCancelEvent;
            MEventTriggerListener.GetListener(_btnPlaySound).onPointerClick += OnClickBtnPlaySound;
            MEventTriggerListener.GetListener(_btnPlayMusic1).onPointerClick += OnClickBtnPlayMusic1;
            MEventTriggerListener.GetListener(_btnPlayMusic2).onPointerClick += OnClickBtnPlayMusic2;
            MEventTriggerListener.GetListener(_btnSendUIEvent).onPointerClick += OnClickBtnSendUIEvent;
            MEventTriggerListener.GetListener(_btnCancelUIEvent).onPointerClick += OnClickBtnCancelUIEvent;
            MEventTriggerListener.GetListener(_btnSaveLocalData).onPointerClick += OnClickBtnSaveLocalData;
            MEventTriggerListener.GetListener(_btnChangeSaveLocalData).onPointerClick += OnClickBtnChangeSaveLocalData;
            MEventTriggerListener.GetListener(_btnGetSaveLocalData).onPointerClick += OnClickBtnGetSaveLocalData;
            MEventTriggerListener.GetListener(_btnCloseUI).onPointerClick += OnClickBtnCloseUI;
        }

        public override void RegisterEvent()
        {   
            Debug.LogWarning(" RegisterEvent! ");
            //-------------------------注册自定义游戏事件------------------------
            GameModule.Event.Subscribe(TemplateEventArgs.EventId, TemplateEventHandle);

            //----------------------------注册UI事件----------------------------
            this.AddUIEvent<int,string>(1001,this.UIEventHandle);
        }

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            Debug.LogWarning(" OnInit !");
        }

        /// <summary>
        /// 界面回收
        /// </summary>
        protected override void OnRecycle()
        {
            Debug.LogWarning("界面回收 ! [Template] ");

            GameEvent.RemoveEventListener<int,string>(1001,this.UIEventHandle);
            GameModule.Event.Unsubscribe(TemplateEventArgs.EventId, TemplateEventHandle);
        }

        public override void ScriptGenerator()
        {
            Debug.LogWarning(" ScriptGenerator!");
        }

        public override void OnCreate()
        {
            Debug.LogWarning(" OnCreate!");
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            Debug.LogWarning(" OnOpen!");
        }

        public override void OnPause()
        {
            base.OnPause();

            Debug.LogWarning(" OnPause!");
        }

        protected override void OnCover()
        {
            Debug.LogWarning("界面遮挡!");
        }

        protected override void OnReveal()
        {
            Debug.LogWarning("界面遮挡恢复!");
        }

        protected override void OnRefocus(object userData)
        {
            Debug.LogWarning("界面激活!");
        }

        public override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            // Debug.Log(" elapseSeconds : "+elapseSeconds+" realElapseSeconds : "+realElapseSeconds);
        }

        protected override void OnDepthChanged(int uiGroupDepth, int depthInUIGroup)
        {
            Debug.LogWarning("界面深度改变! uiGroupDepth : "+uiGroupDepth+" depthInUIGroup : "+depthInUIGroup);
        }

        protected override void InternalSetVisible(bool visible)
        {
            base.InternalSetVisible(visible);

            Debug.LogWarning("设置界面可见性!"+visible.ToString());
        }

        //---------------------------创建新UI-----------------------------
        private void OnClickBtnUIOpen(GameObject go, PointerEventData eventData)
        {
            Debug.LogWarning("打开UI!");

            StartCoroutine(MUtils.InvokeOnClickOpenAction(UI.Loading));
        }
        //-----------------------------------------------------------------
        
        //------------------------游戏事件(自定义)---------------------------
        private void OnClickBtnSendEvent(GameObject go, PointerEventData eventData)
        {
            Debug.LogWarning("发送事件! ");

            List<object> listArray = new List<object>{"Item 1", 2, true};
            GameModule.Event.Fire(this, TemplateEventArgs.Create(listArray));
        }

        private void OnClickBtnCancelEvent(GameObject go, PointerEventData eventData)
        {
            Debug.LogWarning("取消事件! ");
            GameModule.Event.Unsubscribe(TemplateEventArgs.EventId, TemplateEventHandle);
        }
        //-----------------------------------------------------------------

        //------------------------音效&音乐------------------------------
        private void OnClickBtnPlaySound(GameObject go, PointerEventData eventData)
        {
            Debug.LogWarning("播放音效! ");

            GameModule.Sound.PlaySound(Sound.UButton);
        }

        private void OnClickBtnPlayMusic1(GameObject go, PointerEventData eventData)
        {
            Debug.LogWarning("播放背景音乐1! ");

            GameModule.Sound.PlayMusic(Sound.URain);
        }

        private void OnClickBtnPlayMusic2(GameObject go, PointerEventData eventData)
        {
            Debug.LogWarning("播放背景音乐2! ");

            GameModule.Sound.PlayMusic(Sound.UWin);
        }
        //-----------------------------------------------------------------

        //---------------------------UI事件---------------------------------
        private void OnClickBtnSendUIEvent(GameObject go, PointerEventData eventData)
        {
            Debug.LogWarning("发送UI事件! ");

            GameEvent.Send<int,string>(1001,10,"dfgdg");
        }

        private void OnClickBtnCancelUIEvent(GameObject go, PointerEventData eventData)
        {
            Debug.LogWarning("取消UI事件! ");

            // 正常不需要手动调用,会在界面关闭时对该界面注册的事件 统一移除注册处理
            GameEvent.RemoveEventListener<int,string>(1001,this.UIEventHandle);
        }
        //------------------------------------------------------------------
        
        //------------------------处理本地存储数据---------------------------
        private void OnClickBtnSaveLocalData(GameObject go, PointerEventData eventData)
        {
            var tempSaveData = 88.88f;
            GameModule.Setting.SetFloat(Constant.Setting.SettingTest, tempSaveData);
            GameModule.Setting.Save();

            Debug.LogWarning("保存本地数据成功! => "+tempSaveData);
        }

        private void OnClickBtnChangeSaveLocalData(GameObject go, PointerEventData eventData)
        {
            var tempSaveData = 99.99f;
            GameModule.Setting.SetFloat(Constant.Setting.SettingTest, tempSaveData);
            GameModule.Setting.Save();

            Debug.LogWarning("修改本地数据成功! => "+tempSaveData);
        }

        private void OnClickBtnGetSaveLocalData(GameObject go, PointerEventData eventData)
        {
            var tempTestData = GameModule.Setting.GetFloat(Constant.Setting.SettingTest, 0f);
            Debug.LogWarning("获取本地保存数据! => "+tempTestData);
        }
        //------------------------------------------------------------------

        //-----------------------------关闭UI--------------------------------
        private void OnClickBtnCloseUI(GameObject go, PointerEventData eventData)
        {
            Debug.LogWarning("关闭UI! ");
            
            //GameModule.UI.CloseUIForm(this.UIForm);
            this.Close();
        }
        //------------------------------------------------------------------

        //--------------------------游戏事件回调-------------------------------
        private void TemplateEventHandle(object sender, GameEventArgs e)
        {
            TemplateEventArgs ne = (TemplateEventArgs)e;
            var tempData = (List<object>)ne.UserData;

            Debug.Log(" 事件接收成功! param1 : "+(string)tempData[0]+" param2 : "+(int)tempData[1]+" param3 : "+(bool)tempData[2]);
        }
        //------------------------------------------------------------------

        //--------------------------UI事件回调-------------------------------
        private void UIEventHandle(int param1,string param2)
        {
            Debug.LogError(" UIEventHandle => param1 : "+param1+" param2 : "+param2);
        }
        //------------------------------------------------------------------

        protected override void Close()
        {
            base.Close();
            Debug.LogWarning("Close! ");
        }

        private void OnDestroy() {
            Debug.LogWarning("OnDestroy! ");
        }
    }
}
