using System;
using Cysharp.Threading.Tasks;
using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityEngine;
using UnityGameFramework.Runtime;
using YooAsset;

namespace GameMain
{
    public class ProcedureStartGame : ProcedureBase
    {
        public override bool UseNativeDialog { get; }

        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            StartGame().Forget();
        }

        protected override void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
        }

        private async UniTaskVoid StartGame()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(0));
            UILoadMgr.HideAll();
            
            // GameModule.Scene.LoadScene("Battle", Constant.AssetPriority.SceneAsset, this);    
            GameModule.UI.OpenUIForm(UI.Home,UIConfig.DicUIProperty[UI.Home]);
        }
    }
}