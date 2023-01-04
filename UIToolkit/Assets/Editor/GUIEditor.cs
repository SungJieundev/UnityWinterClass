using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(GUIBase))]
public class GUIEditor : Editor
{
    GUIBase _this;
    private void OnEnable() {
        _this = target as GUIBase;
    }
    public override void OnInspectorGUI()
    {
        GUILayout.Label("GUI Editor");
        if(GUILayout.Button("GUI Button1")){

            Debug.Log("Button Click");
            _this.intValue = 30;
        }
        

        GUILayout.Space(10);
        // GUILayout.TextField(_this.intValue.ToString());
        int inTestValue = int.Parse(GUILayout.TextField(_this.intValue.ToString()));
        _this.intValue = inTestValue;

        // Debug.Log(inTestValue.ToString());

        GUILayout.TextField(_this.stringValue);
        GUILayout.Space(10);
        
        // base.OnInspectorGUI();
    }
}
