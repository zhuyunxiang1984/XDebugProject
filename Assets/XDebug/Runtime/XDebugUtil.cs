using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace XGameKit.Core
{
    public static class XDebugUtil
    {
        //Ԥ�����
        public const string CONDITIONAL_NAME = "XDEBUG";
        //����·����ֵ��
        public const string CONFIG_PATH_KEY = "XDebug_Config_Path";
        //Ĭ������·��
        public const string DEFAULT_CONFIG_PATH = "Assets/XGameKitSetting/";
        //Ĭ��Tag��
        public const string DEFAULT_TAG = "Default";

        //��ɫֵת��16����
        public static string ColorToHex(Color color)
        {
            return string.Format("{0}{1}{2}{3}",
                ((int)(color.r * 255)).ToString("X2"),
                ((int)(color.g * 255)).ToString("X2"),
                ((int)(color.b * 255)).ToString("X2"),
                ((int)(color.a * 255)).ToString("X2"));
        }

#if UNITY_EDITOR
        //��ȡ���õ���Դ·��
        public static string GetConfigAssetPath()
        {
            return $"{EditorPrefs.GetString(XDebugUtil.CONFIG_PATH_KEY, XDebugUtil.DEFAULT_CONFIG_PATH)}/XDebugConfig.asset";
        }
#endif
    }

}