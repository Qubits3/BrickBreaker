using System;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    // [CustomEditor(typeof(BrickPlacer))]
    public class BrickPlacerInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            if (GUILayout.Button("Update All Bricks"))
            {
                foreach (var brickPlacer in FindObjectsOfType<BrickPlacer>())
                {
                    brickPlacer.UpdateBrickLocation();
                }
            }
            
            base.OnInspectorGUI();
        }
    }
}