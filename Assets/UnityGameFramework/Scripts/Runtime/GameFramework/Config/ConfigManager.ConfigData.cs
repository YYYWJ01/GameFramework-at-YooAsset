﻿using System.Runtime.InteropServices;

namespace GameFramework.Config
{
    internal sealed partial class ConfigManager : GameFrameworkModule, IConfigManager
    {
        /// <summary>
        /// 配置数据
        /// </summary>
        [StructLayout(LayoutKind.Auto)]
        private struct ConfigData
        {
            private readonly bool m_BoolValue;
            private readonly int m_IntValue;
            private readonly float m_FloatValue;
            private readonly string m_StringValue;

            public ConfigData(bool boolValue, int intValue, float floatValue, string stringValue)
            {
                m_BoolValue = boolValue;
                m_IntValue = intValue;
                m_FloatValue = floatValue;
                m_StringValue = stringValue;
            }

            public bool BoolValue
            {
                get
                {
                    return m_BoolValue;
                }
            }

            public int IntValue
            {
                get
                {
                    return m_IntValue;
                }
            }

            public float FloatValue
            {
                get
                {
                    return m_FloatValue;
                }
            }

            public string StringValue
            {
                get
                {
                    return m_StringValue;
                }
            }
        }
    }
}
