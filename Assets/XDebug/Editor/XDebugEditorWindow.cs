using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;

namespace XGameKit.Core
{
    public class XDebugEditorWindow : OdinEditorWindow
    {
        [MenuItem("XGameKit/XDebug/Setting")]
        static void OpenWindow()
        {
            var window = CreateWindow<XDebugEditorWindow>("XDebug Setting");
            window.minSize = new Vector2(300, 500);
            window.Show();
        }

        [LabelText("配置路径")]
        public string ConfigPath;
        [TableList]
        public List<XDebugConfig.LoggerInfo> Datas = new List<XDebugConfig.LoggerInfo>();

        [Button("创建配置", ButtonSizes.Medium), GUIColor(0.5f, 0.3f, 1f)]
        void CreateConfig()
        {
            Debug.Log("创建配置");

            var configPath = EditorPrefs.GetString(XDebugUtil.CONFIG_PATH_KEY, XDebugUtil.DEFAULT_CONFIG_PATH);
            if (!string.IsNullOrEmpty(ConfigPath) && configPath != ConfigPath)
            {
                EditorPrefs.SetString(XDebugUtil.CONFIG_PATH_KEY, ConfigPath);
            }
            var assetPath = XDebugUtil.GetConfigAssetPath();
            var config = AssetDatabase.LoadAssetAtPath<XDebugConfig>(assetPath);
            if (config != null)
            {
                Datas.Clear();
                foreach (var data in config.Datas)
                {
                    Datas.Add(data);
                }
            }
        }

        [Button("保存配置", ButtonSizes.Medium), GUIColor(0.3f, 0.7f, 0.5f)]
        void SaveConfig()
        {
            var assetPath = XDebugUtil.GetConfigAssetPath();
            var config = AssetDatabase.LoadAssetAtPath<XDebugConfig>(assetPath);
            if (config == null)
            {
                config = CreateInstance<XDebugConfig>();
                AssetDatabase.CreateAsset(config, assetPath);
            }
            config.Datas.Clear();
            config.Datas.AddRange(Datas);
            AssetDatabase.SaveAssets();
        }

        

        protected override void Initialize()
        {
            base.Initialize();

            ConfigPath = EditorPrefs.GetString(XDebugUtil.CONFIG_PATH_KEY, XDebugUtil.DEFAULT_CONFIG_PATH);
        }
    }

}

