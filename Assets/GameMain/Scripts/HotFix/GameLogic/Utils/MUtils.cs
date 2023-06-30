using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace Breeze.Utils
{
    public static class MUtils
    {
        /// <summary>
        /// 打开新UI窗口
        /// </summary>
        /// <param name="uiName">UI名字</param>
        /// <param name="userData">自定义数据</param>
        /// <returns></returns>
        public static IEnumerator InvokeOnClickOpenAction(string uiName,object userData = null)
        {
            yield return new WaitForSeconds(0.1f);
            GameModule.UI.OpenUIForm(uiName,UIConfig.DicUIProperty[uiName],userData);
        }

        /// <summary>
        /// 关闭指定UI窗口
        /// </summary>
        /// <param name="uiForm">UI窗口实例</param>
        /// <returns></returns>
        public static IEnumerator InvokeOnClickCloseAction(UIForm uiForm,Transform go = null)
        {
            Animator tempAnimator = null;
            if (go != null)
            {
                tempAnimator = go.GetComponent<Animator>();
            }
            
            if (tempAnimator != null)
            {
                tempAnimator.Play("Close");
            }

            yield return new WaitForSeconds(0.25f);
            GameModule.UI.CloseUIForm(uiForm);
        }
        
        /// <summary>
        /// 播放点击按钮动画与音效
        /// </summary>
        /// <param name="go"></param>
        public static void PlayOnClickBtnAnimaton(GameObject go)
        {
            var tempAnimator = go.GetComponent<Animator>();
            if (tempAnimator != null)
            {
                tempAnimator.SetTrigger("Pressed");
            }
        }

        /// <summary>
        /// 播放点击按钮动画与音效
        /// </summary>
        /// <param name="go"></param>
        public static void PlayBtnAnimatonAndSound(Transform go,string soundName = "")
        {
            var tempAnimator = go.GetComponent<Animator>();
            if (tempAnimator != null)
            {
                tempAnimator.SetTrigger("Pressed");
            }

            if (soundName != "")
            {
                GameModule.Sound.PlaySound(soundName,SoundConfig.DicSoundProperty[soundName]);
            }
        }
    } 
}

