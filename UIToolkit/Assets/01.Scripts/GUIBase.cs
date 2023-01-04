using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[ExecuteInEditMode]
public class GUIBase : MonoBehaviour
{
    public int intValue;
    public string stringValue;

    private string assetBundleName = "AssetBundle_Output";

    private void Start() {

        Debug.Log("Start");
    }

    private void Update() {
        
        Debug.Log("Update");
    }
    // 윈도우 창 자체를 수정
    private void OnGUI() {
        
        // if(Application.isPlaying){

        //     return;
        // }

        // Debug.Log("OnGUI");

        GUI.Box(new Rect(10, 10, 100, 90), "Loader Menu");
        if(GUI.Button(new Rect(20, 40, 80, 20), "Button1")){

            LoadBundleFile<GameObject>(assetBundleName, "A");
            //LoadAsset("A");
        }

        // 툴팁을 띄우는 코드 
        if(GUI.Button(new Rect(20, 70, 80, 20), new GUIContent("Button2", "ToolTip"))){

            LoadBundleFile<GameObject>(assetBundleName, "B");
            //LoadAsset("B");
        }

        // 툴팁 설정
        GUI.Label(new Rect(20, 100, 100, 40), GUI.tooltip);

        // GUI는 직접 포지션을 설정, GUILayout은 설정 필요 없음
    }

    private void LoadAsset(string name){

        GameObject obj = Resources.Load<GameObject>(name);

        if(obj == null){

            Debug.Log("obj is null");
        }

        GameObject.Instantiate(obj);
    }

    private T LoadBundleFile<T>(string bundleName, string assetName) where T : UnityEngine.Object {
        AssetBundle myAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, bundleName));
        
        if (!myAssetBundle) {

            Debug.Log("Failed to load AssetBundle");
            return default(T);
        }

        T asset = myAssetBundle.LoadAsset(assetName) as T;

        if (!asset) {

            Debug.Log("Asset is null");
        }

        AssetBundle.UnloadAllAssetBundles(false);

        GameObject.Instantiate(asset);

        return asset;
    }
}
