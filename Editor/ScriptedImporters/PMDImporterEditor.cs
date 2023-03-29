using UnityEngine;
using UnityEditor;
#if UNITY_2020_2_OR_NEWER
using UnityEditor.AssetImporters;
#else
using UnityEditor.Experimental.AssetImporters;
#endif
using MMD;

[CustomEditor(typeof(PMDImporter))]
public class PMDImporterEditor : ScriptedImporterEditor {
    SerializedProperty shaderType;
    SerializedProperty rigidFlag;
    SerializedProperty animationType;
    SerializedProperty useIK;
    SerializedProperty scale;
    SerializedProperty isPMXBaseImport;

    public override void OnEnable() {
        base.OnEnable();
        shaderType = serializedObject.FindProperty("importConfig.shader_type");
        rigidFlag = serializedObject.FindProperty("importConfig.rigidFlag");
        animationType = serializedObject.FindProperty("importConfig.animation_type");
        useIK = serializedObject.FindProperty("importConfig.use_ik");
        scale = serializedObject.FindProperty("importConfig.scale");
        isPMXBaseImport = serializedObject.FindProperty("importConfig.is_pmx_base_import");
    }

    public override void OnInspectorGUI() {
        var importer = target as PMDImporter;
        if (importer == null) return;
        if (importer.importConfig == null) {
            importer.importConfig = Config.LoadAndCreate().pmd_config.Clone();
            shaderType.enumValueIndex = (int)importer.importConfig.shader_type;
            rigidFlag.boolValue = importer.importConfig.rigidFlag;
            animationType.enumValueIndex = (int)importer.importConfig.animation_type;
            useIK.boolValue = importer.importConfig.use_ik;
            scale.floatValue = importer.importConfig.scale;
            isPMXBaseImport.boolValue = importer.importConfig.is_pmx_base_import;
        }
        EditorGUILayout.PropertyField(shaderType, new GUIContent("Shader Type"));
        EditorGUILayout.PropertyField(rigidFlag, new GUIContent("Rigidbody"));
        EditorGUILayout.PropertyField(animationType, new GUIContent("Animation Type"));
        EditorGUILayout.PropertyField(useIK, new GUIContent("Use IK"));
        EditorGUILayout.PropertyField(scale, new GUIContent("Scale"));
        EditorGUILayout.BeginHorizontal();
        {
            EditorGUILayout.PrefixLabel(" ");
            if (GUILayout.Button("Original", EditorStyles.miniButtonLeft)) {
                scale.floatValue = 0.085f;
            }
            if (GUILayout.Button("1.0", EditorStyles.miniButtonRight)) {
                scale.floatValue = 1.0f;
            }
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.PropertyField(isPMXBaseImport, new GUIContent("Use PMX Base Import"));
        serializedObject.ApplyModifiedProperties();
        ApplyRevertGUI();
    }
}
