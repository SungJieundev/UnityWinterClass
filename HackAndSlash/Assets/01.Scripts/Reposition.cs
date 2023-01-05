using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    public Player player;

    private void OnTriggerExit2D(Collider2D other) {

        if(!other.CompareTag("Area")) return;
        
        Vector3 playerPos = GameManager.Instance.player.transform.position;
        Vector3 myPos = transform.position;

        float diffx = Mathf.Abs(playerPos.x - myPos.x);
        float diffy = Mathf.Abs(playerPos.y - myPos.y);

        Vector3 playerDir = player.inputVec;
        float dirx = playerDir.x < 0 ? -1 : 1;
        float diry = playerDir.y < 0 ? -1 : 1;

        switch(transform.tag){

            case "Ground":{
                if(diffx > diffy){
                    transform.Translate(Vector2.right * dirx * 40);
                }
                else if(diffx < diffy){

                    transform.Translate(Vector2.up * diry * 40);
                }
            }
                break;
            
            case "Enemy":{

                transform.Translate(playerDir * 20 + new Vector3(Random.Range(-3f, 3f), Random.Range(-3, 3), 0f));
            }
            break;
        }
    }
}
