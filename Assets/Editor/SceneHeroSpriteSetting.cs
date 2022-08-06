using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SceneHeroSpriteSetting: AssetPostprocessor
{
    static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets,
        string[] movedFromAssetPaths)
    {
        foreach (var imported in importedAssets)
        {
            if (imported.Contains("Res/Hero") || imported.Contains("Res/Scene"))
            {
                if (imported.EndsWith("png") || imported.EndsWith("jpg") || imported.EndsWith("jpeg"))
                {
                    TextureImporter importer = AssetImporter.GetAtPath(imported) as TextureImporter;
                    if (importer == null)
                    {
                        continue;
                    }

                    TextureImporterSettings textureImporterSettings = new TextureImporterSettings();
                    importer.ReadTextureSettings(textureImporterSettings);
                    if (textureImporterSettings.spriteAlignment != (int) SpriteAlignment.BottomCenter)
                    {
                        textureImporterSettings.spriteAlignment = (int) SpriteAlignment.BottomCenter;
                        importer.SetTextureSettings(textureImporterSettings);
                        importer.SaveAndReimport();
                    }
                }
            }
        }
    }
}
