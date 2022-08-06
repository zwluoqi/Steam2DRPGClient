using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Experimental.AssetImporters;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapMenu : Editor

{
    [MenuItem("TileMap/Create Palettee")]
    static void CreatePalettee()
    {
          if (!AssetDatabase.IsValidFolder("Assets/Palette"))
          {
              AssetDatabase.CreateFolder("Assets", "Palette");
          }
          DirectoryInfo dir = new DirectoryInfo("Assets/Res/Scene/tiles");
          if (dir.Exists)
          {
              /*
              遍历Resources/images下子目录，可以用不同目录存放不同层的图片
              比如ground目录下放ground层图片、build目录放build图片等等
              */
              foreach (DirectoryInfo subDir in dir.GetDirectories())
              {
                  string subPath = "Assets/Palette/" + subDir.Name;

                      if (!AssetDatabase.IsValidFolder(subPath))
                      {
                          AssetDatabase.CreateFolder("Assets/Palette", "" + subDir.Name);
                      }
   			          //创建Palette，相关参数含义请参考前面文章
                      GameObject palette = CreateNewPalette("Assets/Palette", subDir.Name, GridLayout.CellLayout.Rectangle,
                      GridPalette.CellSizing.Manual, new Vector3(1f, 1f, 1f), GridLayout.CellSwizzle.XYZ);
                    
                      //准备向Palette中写入地图块对象
                      Tilemap layer1 = palette.GetComponentInChildren<Tilemap>(true);
			          //获取目录下所有图片
                      FileInfo[] fileInfos = subDir.GetFiles();
                      // var sprites = AssetDatabase.LoadAllAssetsAtPath("Assets/Res/Scene/tiles/" + subDir.Name);

                      int x = 0;
                      int y = 0;
                      int lastx = 0;
                      int lasty = 0;
                      int maxy = 1;
                      for (int i = 0; i < fileInfos.Length; i++)
                      {
                          // var filePath = fileInfos[i].Name;
                          if (fileInfos[i].Name.EndsWith(".meta"))
                          {
                              continue;
                          }
                          var assetPath =
                              "Assets/Res/Scene/tiles/" + subDir.Name + "/" + fileInfos[i].Name;
                          var sprite =
                              AssetDatabase.LoadAssetAtPath<Sprite>(assetPath);
                          if (sprite == null)
                          {
                              Debug.LogError("not sprite "+assetPath);
                              continue;
                          }
                            TextureImporter textureImporter = AssetImporter.GetAtPath(assetPath) as TextureImporter;
                            TextureImporterSettings textureImporterSettings = new TextureImporterSettings();
                            textureImporter.ReadTextureSettings(textureImporterSettings);
                            if (textureImporterSettings.spriteAlignment != (int)SpriteAlignment.BottomCenter)
                            {
                                textureImporterSettings.spriteAlignment = (int)SpriteAlignment.BottomCenter;
                                textureImporter.SetTextureSettings(textureImporterSettings);
                                textureImporter.SaveAndReimport();
                            }

                          //var sprite = sprites[i] as Sprite;
                         
                          
                          
                          // string tilePath = AssetDatabase.GenerateUniqueAssetPath(subPath + "/" + tile.name + ".asset");
                          var tilePath = subPath + "/" + sprite.name + ".asset";
                          Tile tile = AssetDatabase.LoadAssetAtPath<Tile>(tilePath);
                          if (tile != null)
                          {
                              
                          }
                          else
                          {


                              /*
                            下面这行代码不是必要的，下面会解释。
                             */
                              // Vector2 offset = sprite.textureRectOffset;// TextureManager.GetSpriteOffset(sprites[i].name);

                              //在Palette里创建Tile
                              tile = Tile.CreateInstance<Tile>();
                              // switch(subDir.Name)
                              // {
                              //     case "ground":
                              //         tile.colliderType = Tile.ColliderType.None;
                              //         break;
                              //     case "build":
                              //         tile.colliderType = Tile.ColliderType.Grid;
                              //         break;
                              //     case "airbuild":
                              //         tile.colliderType = Tile.ColliderType.None;
                              //         break;
                              // }

                              tile.color = Color.white;
                              tile.sprite = sprite;
                              tile.flags = TileFlags.LockColor;
                              tile.name = sprite.name;

                              /*
                              下面5行代码不是必要的，用处是设置Palette中Tile默认的transform。
                              此处用来将我读取的图片资源偏移写入Palette的Tile中。
                              */
                              // Matrix4x4 matrix = tile.transform;
                              // matrix.m03 = sprite.rect.width/2 - offset.x;//x
                              // matrix.m13 = offset.y - sprite.rect.height;//y
                              // matrix.m23 = (offset.y - sprite.rect.height) * 2;//z
                              // tile.transform = matrix;

                              //生成Tile asset
                              AssetDatabase.CreateAsset(tile, tilePath);
                          }
                          
                          //此处将40个图片放在一行，可根据需要调整
                          var curx = Mathf.CeilToInt(sprite.rect.width * 0.006f);
                          var cury = Mathf.CeilToInt(sprite.rect.height * 0.006f);
                          if (cury > maxy)
                          {
                              maxy = cury;
                          }

                          x = x + (lastx + curx) / 2;
                          if(x >= 10)
                          {
                              y = y + maxy;
                              x = 0;
                          }

                          lastx = curx;
                          
                          //将Tile写入Pallette
                          layer1.SetTile(new Vector3Int(x, y, 0), tile);
                          
                      }
              }
              AssetDatabase.SaveAssets();
          }
            
    }
    
    
    private static GameObject CreateNewPalette(string folderPath, string name, GridLayout.CellLayout layout, GridPalette.CellSizing cellSizing, Vector3 cellSize, GridLayout.CellSwizzle swizzle)
    {
        GameObject temporaryGO = new GameObject(name);
        Grid grid = temporaryGO.AddComponent<Grid>();

        grid.cellSize = cellSize;
        grid.cellGap = cellSize;
        grid.cellLayout = layout;
        grid.cellSwizzle = swizzle;

        CreateNewLayer(temporaryGO, "Layer1", layout);

        // string path = AssetDatabase.GenerateUniqueAssetPath(folderPath + "/" + name + ".prefab");
        var path = folderPath + "/" + name + ".prefab";
        AssetDatabase.DeleteAsset(path);
        UnityEngine.Object prefab = PrefabUtility.SaveAsPrefabAsset(temporaryGO, path);
        GridPalette palette = CreateGridPalette(cellSizing);
        AssetDatabase.AddObjectToAsset(palette, prefab);
        // PrefabUtility.ApplyPrefabInstance(temporaryGO, InteractionMode.AutomatedAction);
        AssetDatabase.Refresh();

        GameObject.DestroyImmediate(temporaryGO);
        return AssetDatabase.LoadAssetAtPath<GameObject>(path);
    }

    private static GridPalette CreateGridPalette(GridPalette.CellSizing cellSizing)
    {
        var palette = GridPalette.CreateInstance<GridPalette>();
        palette.name = "Palette Settings";
        palette.cellSizing = cellSizing;
        return palette;
    }

    
    private static GameObject CreateNewLayer(GameObject paletteGO, string name, GridLayout.CellLayout layout)
    {
        GameObject newLayerGO = new GameObject(name);
        var tilemap = newLayerGO.AddComponent<Tilemap>();

        //Sprite Anchor需要根据实际情况调整
        tilemap.tileAnchor = new Vector3(0, 0, 0);

        var renderer = newLayerGO.AddComponent<TilemapRenderer>();
        newLayerGO.transform.parent = paletteGO.transform;
        newLayerGO.layer = paletteGO.layer;

        //默认设置
        switch (layout)
        {
            case GridLayout.CellLayout.Hexagon:
            {
                tilemap.tileAnchor = Vector3.zero;
                break;
            }
            case GridLayout.CellLayout.Isometric:
            case GridLayout.CellLayout.IsometricZAsY:
            {
                renderer.sortOrder = TilemapRenderer.SortOrder.TopRight;
                break;
            }
            case GridLayout.CellLayout.Rectangle:
                renderer.sortOrder = TilemapRenderer.SortOrder.TopRight;
                tilemap.tileAnchor = new Vector3(0.5f,0,0);
                break;
        }

        return newLayerGO;
    }

}
