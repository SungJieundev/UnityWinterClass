using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GoldButton : MonoBehaviour
{
    public TextMeshProUGUI goldText;
    //private int addGold = 11;
    
    //string goldText;

    
    // public void GoldButtonClick(){

        

    //     gold += 123456789;

    //     hM = Mathf.FloorToInt(gold / 100000000); //억 단위의 수를 구할 수 있다.

    //     tT = Mathf.FloorToInt(gold / 10000);
    //     tT  -= hM * 10000; //천 단위 수만 나옴

    //     one = gold;
    //     one -= hM * 100000000 + tT * 10000;
        
    //     goldText.text = $"Gold : {hM}hM {tT}tT {one}One\n{gold}";
    
    // }

    float k = Mathf.Pow(10,3);
    float m = Mathf.Pow(10,6);
    float b = Mathf.Pow(10,9);
    float t = Mathf.Pow(10,12);
    float e = Mathf.Pow(10,15);

    private void Update() {
        
        //
        GoldButtonClick();
    }
    public void GoldButtonClick(){

        //gold *= addGold;

        switch(GameManager.Instance.gold.ToString().Length){

            case 1 :
            case 2 : 
            case 3 :
                goldText.text = $"{GameManager.Instance.gold}";
                break;

            case 4 :
            case 5 : 
            case 6 :
                goldText.text = $"{GameManager.Instance.gold / (int)k}K \n {GameManager.Instance.gold}";
                break;
            case 7 : 
            case 8 :
            case 9 :
                goldText.text = $"{GameManager.Instance.gold / (int)m}M \n {GameManager.Instance.gold}";
                break;
            case 10 :
            case 11 :
            case 12 :
                goldText.text = $"{GameManager.Instance.gold / (int)b}B \n {GameManager.Instance.gold}";
                break;
            case 13 :
            case 14 :
            case 15 :
                goldText.text = $"{GameManager.Instance.gold / (int)t}T \n {GameManager.Instance.gold}";
                break;
            
            default :
                goldText.text = $"{GameManager.Instance.gold.ToString()[0]}.{GameManager.Instance.gold.ToString()[1]}{GameManager.Instance.gold.ToString()[2]}E + {GameManager.Instance.gold.ToString().Length -1} \n {GameManager.Instance.gold}";
                break;
        }
    }  
}
