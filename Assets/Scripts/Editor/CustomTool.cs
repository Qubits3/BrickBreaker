#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
#endif
using UnityEngine;

namespace Editor
{
#if UNITY_EDITOR
    public class CustomTool : EditorWindow
    {
        [MenuItem("Window/Custom Tool")]
        private static void ShowWindow()
        {
            var window = GetWindow<CustomTool>();
            window.titleContent = new GUIContent("Custom Tool");
            window.Show();
        }

        private void OnGUI()
        {
            var path = Application.persistentDataPath + "/savefile.json";

            if (GUILayout.Button("Spawn Essentials"))
            {
                SpawnPrefab("Prefabs/Bounds");
                SpawnPrefab("Prefabs/Managers");
                SpawnPrefab("Prefabs/UI");
                SpawnPrefab("Prefabs/Player");

                SpawnBrickBundle();

                SetSkyboxMaterial();
            }

            if (GUILayout.Button("Open Save File Path"))
            {
                EditorUtility.RevealInFinder(@"C:\Users\Metin\AppData\LocalLow\DefaultCompany\Brick Breaker\");
            }

            if (GUILayout.Button("Open Save File"))
            {
                if (File.Exists(path))
                {
                    Application.OpenURL($"file://{path}");
                }
                else
                {
                    Debug.LogError("File does not exists");
                }
            }
        }

        private static void SpawnBrickBundle()
        {
            var bundleName = $"Level{SceneManager.GetActiveScene().buildIndex}Bricks";

            if (!GameObject.Find(bundleName))
            {
                var bundle = new GameObject(bundleName)
                {
                    tag = "BrickBundle"
                };

                EditorUtility.SetDirty(bundle);
            }
        }

        private void SetSkyboxMaterial()
        {
            if (RenderSettings.skybox != Resources.Load<Material>("Materials/M_SolidSkybox"))
            {
                RenderSettings.skybox = Resources.Load<Material>("Materials/M_SolidSkybox");
                EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
            }
        }

        private void SpawnPrefab(string path)
        {
            if (!GameObject.Find(Resources.Load(path).name))
            {
                EditorUtility.SetDirty(PrefabUtility.InstantiatePrefab(Resources.Load<GameObject>(path)));
            }
        }
    }
#endif
}