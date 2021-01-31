using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CreateCubeGrid))]
public class CreateCubeGridEditor : Editor
{
    public override void OnInspectorGUI()
    {
        CreateCubeGrid myTarget = (CreateCubeGrid)target;

        DrawDefaultInspector();

        if (GUILayout.Button("Create new placeholder map"))
        {
            myTarget.CreateGrid();
        }
        if (GUILayout.Button("Replace placeholders"))
        {
            myTarget.ReplacePlaceHolders();
        }
        if (GUILayout.Button("Color abilities on placeholders"))
        {
            myTarget.RevealAbilities();
        }
    }
}
