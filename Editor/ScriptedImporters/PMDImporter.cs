#if UNITY_2020_2_OR_NEWER
using UnityEditor.AssetImporters;
#else
using UnityEditor.Experimental.AssetImporters;
#endif
using MMD;

[ScriptedImporter(1, new string[] { ".pmd", ".pmx" })]
public class PMDImporter : ScriptedImporter {
    public PMDImportConfig importConfig;

    public override void OnImportAsset(AssetImportContext ctx) {
        if (importConfig == null) importConfig = Config.LoadAndCreate().pmd_config.Clone();
		var agent = new ModelAgent(ctx.assetPath);
        agent.CreatePrefab(
            importConfig.shader_type,
            importConfig.rigidFlag,
            importConfig.animation_type,
            importConfig.use_ik,
            importConfig.scale,
            importConfig.is_pmx_base_import,
            ctx
        );
    }
}
