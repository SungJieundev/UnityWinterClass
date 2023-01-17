using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   

    public float moveSpeed = 8f;
    public GameObject bulletPrefab;

    private Rigidbody2D rigid;
    private OutLineShader outLineShader;
    

    private void Awake() {
        
        rigid = GetComponent<Rigidbody2D>();
        outLineShader = GetComponent<OutLineShader>();
    }

    private void Start() {
        
        StartCoroutine(Shooting());

        
    }

    private void Update() {
        
        Move();

        outLineShader.OutLine(true);
    }

    IEnumerator Shooting(){


        while(true){

            
            Instantiate(bulletPrefab, gameObject.transform.position, Quaternion.identity);
            Debug.Log(GameManager.Instance.gold);
            GameManager.Instance.shootingDelay = Mathf.Sqrt(GameManager.Instance.stageLevel);
            
            yield return new WaitForSeconds(GameManager.Instance.shootingDelay);
        }
    }

    private void Move(){

        float hori = Input.GetAxisRaw("Horizontal");
        float verti = Input.GetAxisRaw("Vertical");

        Vector2 dir = new Vector2(hori, verti);

        rigid.velocity = dir.normalized * moveSpeed;
    }

    IEnumerator Click(){
        while(true){

            if(Input.GetMouseButtonDown(0)){

                GameManager.Instance.stageManager.enemyList[0].GetComponent<Enemy>().myHp--;
            }

            yield return new WaitForSeconds(0.1f);
        }
    }
}
