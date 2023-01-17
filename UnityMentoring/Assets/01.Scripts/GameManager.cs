using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public StageManager stageManager;

    public BigInteger gold = 0;
    public int stageLevel = 1;
    public float shootingDelay = 1;

    // Clicker 클래스
    private int clickerLevel;
    private float levelUpCost;
    private float clickerPower;

    private float enemyCost;

    private void Awake() {
        
        if(Instance == null){

            Instance = this;
        }

        stageManager = GetComponent<StageManager>();

        levelUpCost = 50 * Mathf.Pow(1.07f, clickerLevel - 1);

        clickerPower = levelUpCost * 0.4f;
        
    }

    private void Start() {
        
        StartCoroutine(ClickToAttack());
    }

    public void PlusGold(){

        enemyCost = 10 * Mathf.Pow(1.06f, 10f) - Mathf.Pow(1.06f, 10f + GameManager.Instance.stageLevel) / 1 - 1.06f;
        GameManager.Instance.gold += (BigInteger)enemyCost;
    }

    IEnumerator ClickToAttack(){
        while(true){


            if(Input.GetMouseButton(0)){

                stageManager.enemyList[0].GetComponent<Enemy>().myHp -= clickerPower;

                yield return new WaitForSeconds(0.1f);
            }
        }
    }


    




}
