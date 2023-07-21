using System.Collections;
using System.Collections.Generic;
using GameFramework;
using GameFramework.Event;
using UnityEngine;
namespace UnityGameFramework.Runtime
{
    public class TemplateEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(TemplateEventArgs).GetHashCode();
        public TemplateEventArgs()
        {
            UserData = null;
        }

        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        public object UserData
        {
            get;
            private set;
        }

        public static TemplateEventArgs Create(object userData = null)
        {
            TemplateEventArgs templateEventArgs = ReferencePool.Acquire<TemplateEventArgs>();
            templateEventArgs.UserData = userData;
            return templateEventArgs;
        }

        public override void Clear()
        {
            UserData = null;
        }
    }
}
