using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpSlider : MonoBehaviour
{
    public Enemy enemyInfo;
    private Slider hpSlider;
    private float hpBarPositionY;

    private void Awake() {
        
        hpSlider = GetComponent<Slider>();
    }

    private void Start() {
        
        hpSlider.maxValue = enemyInfo.myHp;
        
    }
    private void Update() {
        
        // if(Input.GetMouseButtonDown(0)){

        //     enemyInfo.myHp - 
        //hpSlider.value = enemyInfo.myHp;
        // }

        if(enemyInfo == null)
        {
            Destroy(gameObject);
            return;
        }
     
        gameObject.transform.position = Camera.main.WorldToScreenPoint(enemyInfo.transform.position); 
    }
}
