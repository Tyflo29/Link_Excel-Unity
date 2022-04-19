using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(JsonEditor))]
public class myScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Import"))
        {
            var targetAsPouet = (JsonEditor)target;

            //targetAsPouet.ImportFromJson();

        }
    }
}
