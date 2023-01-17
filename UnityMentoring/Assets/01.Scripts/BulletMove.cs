using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    private float bulletSpeed = 10f;

    private void Update() {
        
        Move();
    }
    public void Move(){

        transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
    }    

    
}
