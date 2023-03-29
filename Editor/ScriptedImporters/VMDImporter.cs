using UnityEngine;
#if UNITY_2020_2_OR_NEWER
using UnityEditor.AssetImporters;
#else
using UnityEditor.Experimental.AssetImporters;
#endif
using MMD;

[ScriptedImporter(1, ".vmd")]
public class VMDImporter : ScriptedImporter {
    public GameObject pmdPrefab;
    public VMDImportConfig importConfig;

    public override void OnImportAsset(AssetImportContext ctx) {
        if (importConfig == null) importConfig = Config.LoadAndCreate().vmd_config.Clone();
        var agent = new MotionAgent(ctx.assetPath);
        agent.CreateAnimationClip(pmdPrefab, false, importConfig.interpolationQuality, ctx);
    }
}
