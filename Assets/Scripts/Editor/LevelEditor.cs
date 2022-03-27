#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
#endif
using UnityEngine;

namespace Editor
{
#if UNITY_EDITOR
    public class LevelEditor : EditorWindow
    {
        [MenuItem("Level/Level Editor")]
        private static void ShowWindow()
        {
            var window = GetWindow<LevelEditor>();
            window.titleContent = new GUIContent("Level Editor");
            window.Show();
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Spawn Essentials"))
            {
                Spawn("Prefabs/Bounds");
                Spawn("Prefabs/Managers");
                Spawn("Prefabs/UI");
                Spawn("Prefabs/Player");

                SetSkyboxMaterial();
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

        private void Spawn(string path)
        {
            if (!GameObject.Find(Resources.Load(path).name))
            {
                EditorUtility.SetDirty(PrefabUtility.InstantiatePrefab(Resources.Load<GameObject>(path)));
            }
        }
    }
#endif
}