using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;


public class AssetBundleWindow : EditorWindow
{
    string assetBundleOutput = "Assets/AssetBundle_Output";

    [MenuItem("Custom/AssetBundleWindow")]
    static public void OpenAssetBundleWindow(){
        EditorWindow.GetWindow<AssetBundleWindow>(false, "AssetBundleWindow", true).Show();
    }

    private void OnGUI(){
        if(GUILayout.Button("Build AssetBundle")){


        }
    }

    private void BuildAssetBundle() {

        if (Directory.Exists(assetBundleOutput)) {

            Directory.CreateDirectory(assetBundleOutput);
        }
        BuildPipeline.BuildAssetBundles(
            assetBundleOutput, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
    }
}
