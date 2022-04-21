using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CsvEditor))]
public class myScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Import"))
        {
            var targetAsPouet = (CsvEditor)target;

            //targetAsPouet.ImportFromJson();

        }
    }
}
