using GameFramework;
using GameFramework.DataTable;
using GameFramework.Sound;
using UnityGameFramework.Runtime;

namespace GameMain
{
    public static class SoundExtension
    {
        /// <summary>
        /// 淡出音量持续时间
        /// </summary>
        private const float FadeVolumeDuration = 1f;
        /// <summary>
        /// 音乐序列号
        /// </summary>
        private static int? s_MusicSerialId = null;

        // public static int? PlayMusic(this SoundComponent soundComponent, int musicId, object userData = null)
        // {
        //     soundComponent.StopMusic();
        //     
        //     IDataTable<DRMusic> dtMusic = GameModule.DataTable.GetDataTable<DRMusic>();
        //     DRMusic drMusic = dtMusic.GetDataRow(musicId);
        //     if (drMusic == null)
        //     {
        //         Log.Warning("Can not load music '{0}' from data table.", musicId.ToString());
        //         return null;
        //     }
        //     
        //     PlaySoundParams playSoundParams = PlaySoundParams.Create();
        //     playSoundParams.Priority = 64;
        //     playSoundParams.Loop = true;
        //     playSoundParams.VolumeInSoundGroup = 1f;
        //     playSoundParams.FadeInSeconds = FadeVolumeDuration;
        //     playSoundParams.SpatialBlend = 0f;
        //     s_MusicSerialId = soundComponent.PlaySound(AssetUtility.GetMusicAsset(drMusic.AssetName), "Music", Constant.AssetPriority.MusicAsset, playSoundParams, null, userData);
        //     return s_MusicSerialId;
        // }

        /// <summary>
        /// 播放音乐
        /// </summary>
        /// <param name="soundComponent">音效组件</param>
        /// <param name="musicId">音效声音</param>
        /// <param name="userData">声音数据</param>
        /// <returns></returns>
        public static int? PlayMusic(this SoundComponent soundComponent, string musicAssetName, object userData = null)
        {
            soundComponent.StopMusic();
            SoundProperty soundProperty = SoundConfig.DicSoundProperty[musicAssetName];
            PlaySoundParams playSoundParams = soundProperty.Params;
            s_MusicSerialId = soundComponent.PlaySound(musicAssetName, soundProperty.SoundGroup, Constant.AssetPriority.MusicAsset, playSoundParams, null, userData);

            return s_MusicSerialId;
        }

        /// <summary>
        /// 停止背景音乐
        /// </summary>
        /// <param name="soundComponent">声音组件</param>
        public static void StopMusic(this SoundComponent soundComponent)
        {
            if (!s_MusicSerialId.HasValue)
            {
                return;
            }

            soundComponent.StopSound(s_MusicSerialId.Value, FadeVolumeDuration);
            s_MusicSerialId = null;
        }

        /// <summary>
        /// 播放音效
        /// </summary>
        /// <param name="soundComponent">音效组件</param>
        /// <param name="soundId">音效Id</param>
        /// <param name="bindingEntity">绑定实体</param>
        /// <param name="userData">声音数据</param>
        /// <returns></returns>
        public static int? PlaySound(this SoundComponent soundComponent, string soundAssetName, Entity bindingEntity = null, object userData = null)
        {
            SoundProperty soundProperty = SoundConfig.DicSoundProperty[soundAssetName];
            PlaySoundParams playSoundParams = soundProperty.Params;

            return soundComponent.PlaySound(soundAssetName, soundProperty.SoundGroup, Constant.AssetPriority.MusicAsset, playSoundParams, bindingEntity, userData);
        }
        
        // public static int? PlayUISound(this SoundComponent soundComponent, int uiSoundId, object userData = null)
        // {
        //     IDataTable<DRUISound> dtUISound = GameModule.DataTable.GetDataTable<DRUISound>();
        //     DRUISound drUISound = dtUISound.GetDataRow(uiSoundId);
        //     if (drUISound == null)
        //     {
        //         Log.Warning("Can not load UI sound '{0}' from data table.", uiSoundId.ToString());
        //         return null;
        //     }
        //
        //     PlaySoundParams playSoundParams = PlaySoundParams.Create();
        //     playSoundParams.Priority = drUISound.Priority;
        //     playSoundParams.Loop = false;
        //     playSoundParams.VolumeInSoundGroup = drUISound.Volume;
        //     playSoundParams.SpatialBlend = 0f;
        //     return soundComponent.PlaySound(AssetUtility.GetUISoundAsset(drUISound.AssetName), "UISound", Constant.AssetPriority.UISoundAsset, playSoundParams, userData);
        // }
        
        /// <summary>
        /// 获取声音组是否静音
        /// </summary>
        /// <param name="soundComponent">声音组件</param>
        /// <param name="soundGroupName">声音组Name</param>
        /// <returns></returns>
        public static bool IsMuted(this SoundComponent soundComponent, string soundGroupName)
        {
            if (string.IsNullOrEmpty(soundGroupName))
            {
                Log.Warning("Sound group is invalid.");
                return true;
            }
        
            ISoundGroup soundGroup = soundComponent.GetSoundGroup(soundGroupName);
            if (soundGroup == null)
            {
                Log.Warning("Sound group '{0}' is invalid.", soundGroupName);
                return true;
            }
        
            return soundGroup.Mute;
        }

        /// <summary>
        /// 设置声音组静音
        /// </summary>
        /// <param name="soundComponent">声音组件</param>
        /// <param name="soundGroupName">声音组Name</param>
        /// <param name="mute">是否静音</param>
        public static void Mute(this SoundComponent soundComponent, string soundGroupName, bool mute)
        {
            if (string.IsNullOrEmpty(soundGroupName))
            {
                Log.Warning("Sound group is invalid.");
                return;
            }

            ISoundGroup soundGroup = soundComponent.GetSoundGroup(soundGroupName);
            if (soundGroup == null)
            {
                Log.Warning("Sound group '{0}' is invalid.", soundGroupName);
                return;
            }

            soundGroup.Mute = mute;

            GameModule.Setting.SetBool(Utility.Text.Format(Constant.Setting.SoundGroupMuted, soundGroupName), mute);
            GameModule.Setting.Save();
        }

        /// <summary>
        /// 获取音量
        /// </summary>
        /// <param name="soundComponent">声音组件</param>
        /// <param name="soundGroupName">声音组Name</param>
        /// <returns></returns>
        public static float GetVolume(this SoundComponent soundComponent, string soundGroupName)
        {
            if (string.IsNullOrEmpty(soundGroupName))
            {
                Log.Warning("Sound group is invalid.");
                return 0f;
            }

            ISoundGroup soundGroup = soundComponent.GetSoundGroup(soundGroupName);
            if (soundGroup == null)
            {
                Log.Warning("Sound group '{0}' is invalid.", soundGroupName);
                return 0f;
            }

            return soundGroup.Volume;
        }

        /// <summary>
        /// 设置音量
        /// </summary>
        /// <param name="soundComponent">声音组件</param>
        /// <param name="soundGroupName">声音组Name</param>
        /// <param name="volume">音量</param>
        public static void SetVolume(this SoundComponent soundComponent, string soundGroupName, float volume)
        {
            if (string.IsNullOrEmpty(soundGroupName))
            {
                Log.Warning("Sound group is invalid.");
                return;
            }

            ISoundGroup soundGroup = soundComponent.GetSoundGroup(soundGroupName);
            if (soundGroup == null)
            {
                Log.Warning("Sound group '{0}' is invalid.", soundGroupName);
                return;
            }

            soundGroup.Volume = volume;

            GameModule.Setting.SetFloat(Utility.Text.Format(Constant.Setting.SoundGroupVolume, soundGroupName), volume);
            GameModule.Setting.Save();
        }
    }
}
