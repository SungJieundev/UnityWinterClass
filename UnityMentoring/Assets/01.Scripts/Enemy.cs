using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;

public class Enemy : MonoBehaviour
{
    private int stageMaxPosX = 9;
    public int stageMinPosY = -5;
    private int cnt;

    public float myHp;
    //public Slider hpSlider;

    private void Start() {
        myHp = 2 * (10 * Mathf.Pow(1.06f, 10f) - Mathf.Pow(1.06f, 10f + GameManager.Instance.stageLevel) / 1 - 1.06f);
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.tag == "Player"){

            Destroy(other.gameObject);

            foreach(var item in GameManager.Instance.stageManager.enemyList){

                Destroy(item);
            }
            GameManager.Instance.stageManager.enemyList.Clear();

            StopCoroutine(GameManager.Instance.stageManager.Co_EnemySpawn);
        }

        if(other.gameObject.tag == "Bullet"){

            cnt++;

            // base price b = 10 / exponent r = 1.06 / k = 10

            if(cnt >= 10){
                
                cnt = 0;
                GameManager.Instance.stageLevel++;
                GameManager.Instance.shootingDelay = 100 * Mathf.Sqrt(GameManager.Instance.stageLevel);
            } 
            
            GameManager.Instance.stageManager.enemyList.Remove(gameObject);
            Destroy(gameObject);
        }
    }

    private void DestroyEnemy(){

        if(gameObject.transform.position.x < -stageMaxPosX || gameObject.transform.position.x > stageMaxPosX || gameObject.transform.position.y < stageMinPosY){

            GameManager.Instance.stageManager.enemyList.Remove(gameObject);
            Destroy(gameObject);
        }

        if(myHp == 0)
            Destroy(gameObject);
    }

    private void Update() {
        
        DestroyEnemy();
    }
}
