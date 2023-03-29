using UnityEngine;
#if UNITY_2020_2_OR_NEWER
using UnityEditor.AssetImporters;
#else
using UnityEditor.Experimental.AssetImporters;
#endif
using MMD;

[ScriptedImporter(1, ".vmd")]
public class VMDImporter : ScriptedImporter {
    public MMDEngine pmdPrefab;
    public VMDImportConfig importConfig;

    public override void OnImportAsset(AssetImportContext ctx) {
        if (importConfig == null) importConfig = Config.LoadAndCreate().vmd_config.Clone();
        if (pmdPrefab == null) return;
        var agent = new MotionAgent(ctx.assetPath);
        agent.CreateAnimationClip(pmdPrefab.gameObject, false, importConfig.interpolationQuality, ctx);
    }
}
