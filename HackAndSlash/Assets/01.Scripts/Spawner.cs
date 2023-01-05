using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private void Update() {
        
        if(Input.GetKeyDown(KeyCode.Alpha1)){

            GameManager.Instance.poolManager.Get(0);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2)){

            GameManager.Instance.poolManager.Get(1);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3)){

            GameManager.Instance.poolManager.Get(2);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha4)){

            GameManager.Instance.poolManager.Get(3);
        }
    }
}
