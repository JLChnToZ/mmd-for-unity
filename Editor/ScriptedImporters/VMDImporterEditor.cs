using UnityEngine;
using UnityEditor;
#if UNITY_2020_2_OR_NEWER
using UnityEditor.AssetImporters;
#else
using UnityEditor.Experimental.AssetImporters;
#endif
using MMD;

[CustomEditor(typeof(VMDImporter))]
public class VMDImporterEditor : ScriptedImporterEditor {
    SerializedProperty pmdPrefab;
    SerializedProperty interpolationQuality;


    public override void OnEnable() {
        base.OnEnable();
        pmdPrefab = serializedObject.FindProperty("pmdPrefab");
        interpolationQuality = serializedObject.FindProperty("importConfig.interpolationQuality");
    }

    public override void OnInspectorGUI() {
        var importer = target as VMDImporter;
        if (importer == null) return;
        EditorGUILayout.PropertyField(pmdPrefab);
        if (importer.importConfig == null) {
            importer.importConfig = Config.LoadAndCreate().vmd_config.Clone();
            interpolationQuality.floatValue = importer.importConfig.interpolationQuality;
        }
        EditorGUILayout.PropertyField(interpolationQuality, new GUIContent("Interpolation Quality"));
        serializedObject.ApplyModifiedProperties();
        ApplyRevertGUI();
    }
}