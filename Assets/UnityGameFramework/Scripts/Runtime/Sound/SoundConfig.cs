using System.Collections;
using System.Collections.Generic;
using GameFramework.Sound;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    public static class Sound
    {
        //---------------------Game----------------------
        public static readonly string GBall = "Ball";
        public static readonly string GBomb = "Bomb";
        public static readonly string GBoosterAward = "BoosterAward";
        public static readonly string GCollectable = "Collectable";
        public static readonly string GColorBomb = "ColorBomb";
        public static readonly string GCubePress = "CubePress";
        public static readonly string GCubePressError = "CubePressError";
        public static readonly string GDynamite = "Dynamite";
        public static readonly string GIceBreak = "IceBreak";
        public static readonly string GReachedGoal = "ReachedGoal";
        public static readonly string GStone = "Stone";

        //----------------------UI----------------------
        public static readonly string UButton = "Button";
        public static readonly string UBuyPopButton = "BuyPopButton";
        public static readonly string UCoinsPopButton = "CoinsPopButton";
        public static readonly string ULose = "Lose";
        public static readonly string UPopupClose = "PopupClose";
        public static readonly string UPopupCloseButton = "PopupCloseButton";
        public static readonly string UPopupOpen = "PopupOpen";
        public static readonly string UPopupOpenButton = "PopupOpenButton";
        public static readonly string UPopupOpenWhoosh = "PopupOpenWhoosh";
        public static readonly string URain = "Rain";
        public static readonly string UWin = "Win";
        public static readonly string UWinStarPop = "WinStarPop";
    }

    public static class SoundConfig
    {
        public static Dictionary<string, SoundProperty> DicSoundProperty = new Dictionary<string, SoundProperty>
        {
            // ------------------Game---------------------
            {Sound.GBomb,new SoundProperty(SoundGroup.Sound,new PlaySoundParams(false,0,false,false,0,1,0,1,0,0,100,1))},
            {Sound.GBall,new SoundProperty(SoundGroup.Sound,new PlaySoundParams(false,0,false,false,0,1,0,1,0,0,100,1))},
            {Sound.GBoosterAward,new SoundProperty(SoundGroup.Sound,new PlaySoundParams(false,0,false,false,0,1,0,1,0,0,100,1))},
            {Sound.GCollectable,new SoundProperty(SoundGroup.Sound,new PlaySoundParams(false,0,false,false,0,1,0,1,0,0,100,1))},
            {Sound.GColorBomb,new SoundProperty(SoundGroup.Sound,new PlaySoundParams(false,0,false,false,0,1,0,1,0,0,100,1))},
            {Sound.GCubePress,new SoundProperty(SoundGroup.Sound,new PlaySoundParams(false,0,false,false,0,1,0,1,0,0,100,1))},
            {Sound.GCubePressError,new SoundProperty(SoundGroup.Sound,new PlaySoundParams(false,0,false,false,0,1,0,1,0,0,100,1))},
            {Sound.GDynamite,new SoundProperty(SoundGroup.Sound,new PlaySoundParams(false,0,false,false,0,1,0,1,0,0,100,1))},
            {Sound.GIceBreak,new SoundProperty(SoundGroup.Sound,new PlaySoundParams(false,0,false,false,0,1,0,1,0,0,100,1))},
            {Sound.GReachedGoal,new SoundProperty(SoundGroup.Sound,new PlaySoundParams(false,0,false,false,0,1,0,1,0,0,100,1))},
            {Sound.GStone,new SoundProperty(SoundGroup.Sound,new PlaySoundParams(false,0,false,false,0,1,0,1,0,0,100,1))},

            // ------------------UI---------------------
            {Sound.UButton,new SoundProperty(SoundGroup.UISound,new PlaySoundParams(false,0,false,false,0,1,0,1,0,0,100,1))},
            {Sound.UBuyPopButton,new SoundProperty(SoundGroup.UISound,new PlaySoundParams(false,0,false,false,0,1,0,1,0,0,100,1))},
            {Sound.UCoinsPopButton,new SoundProperty(SoundGroup.UISound,new PlaySoundParams(false,0,false,false,0,1,0,1,0,0,100,1))},
            {Sound.ULose,new SoundProperty(SoundGroup.UISound,new PlaySoundParams(false,0,false,false,0,1,0,1,0,0,100,1))},
            {Sound.UPopupClose,new SoundProperty(SoundGroup.UISound,new PlaySoundParams(false,0,false,false,0,1,0,1,0,0,100,1))},
            {Sound.UPopupCloseButton,new SoundProperty(SoundGroup.UISound,new PlaySoundParams(false,0,false,false,0,1,0,1,0,0,100,1))},
            {Sound.UPopupOpen,new SoundProperty(SoundGroup.UISound,new PlaySoundParams(false,0,false,false,0,1,0,1,0,0,100,1))},
            {Sound.UPopupOpenButton,new SoundProperty(SoundGroup.UISound,new PlaySoundParams(false,0,false,false,0,1,0,1,0,0,100,1))},
            {Sound.UPopupOpenWhoosh,new SoundProperty(SoundGroup.UISound,new PlaySoundParams(false,0,false,false,0,1,0,1,0,0,100,1))},
            {Sound.URain,new SoundProperty(SoundGroup.Music,new PlaySoundParams(false,0,false,true,0,1,0,1,0,0,100,1))},
            {Sound.UWin,new SoundProperty(SoundGroup.Music,new PlaySoundParams(false,0,false,true,0,1,0,1,0,0,100,1))},
            {Sound.UWinStarPop,new SoundProperty(SoundGroup.UISound,new PlaySoundParams(false,0,false,false,0,1,0,1,0,0,100,1))},
        };
    }

    public class SoundGroup 
    {
        public static readonly string Music = "Music";
        public static readonly string Sound = "Sound";
        public static readonly string UISound = "UISound";
    }

    public class SoundProperty
    {
        public string SoundGroup;
        public PlaySoundParams Params;

        public SoundProperty(string soundGroup,PlaySoundParams param)
        {
            SoundGroup = soundGroup;
            Params = param;
        }
    }
}

