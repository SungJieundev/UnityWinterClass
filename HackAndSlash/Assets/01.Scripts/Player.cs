using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    private Rigidbody2D _rb;
    private void Awake() {

        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        // GetAxisRaw는 -1, 0, 1
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");

        // _rb.AddForce 힘을 주어 밈 (관성 마찰이 적용됨)
        // _rb.velocity 속력 (일부만 적용)
        // _rb.MovePosition (거의 적용되지 않음)
    }

    private void FixedUpdate() {
        
        // 벡터는 방향과 힘의 크기. 노멀벡터는 힘의 크기를 1로 맞추게 해줌
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        
        _rb.MovePosition(_rb.position + nextVec);
       
    }
}
