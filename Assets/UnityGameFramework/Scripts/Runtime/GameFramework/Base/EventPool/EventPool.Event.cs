namespace GameFramework
{
    internal sealed partial class EventPool<T> where T : BaseEventArgs
    {
        /// <summary>
        /// 事件结点。
        /// </summary>
        private sealed class Event : IReference
        {
            private object m_Sender;
            private T m_EventArgs;

            public Event()
            {
                m_Sender = null;
                m_EventArgs = null;
            }

            /// <summary>
            /// 发送者
            /// </summary>
            public object Sender
            {
                get
                {
                    return m_Sender;
                }
            }

            /// <summary>
            /// 事件参数
            /// </summary>
            public T EventArgs
            {
                get
                {
                    return m_EventArgs;
                }
            }

            /// <summary>
            /// 创建事件
            /// </summary>
            /// <param name="sender">发送者</param>
            /// <param name="e">参数</param>
            /// <returns></returns>
            public static Event Create(object sender, T e)
            {
                Event eventNode = ReferencePool.Acquire<Event>();
                eventNode.m_Sender = sender;
                eventNode.m_EventArgs = e;
                return eventNode;
            }

            public void Clear()
            {
                m_Sender = null;
                m_EventArgs = null;
            }
        }
    }
}
