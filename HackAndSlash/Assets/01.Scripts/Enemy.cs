using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D target;
    private Rigidbody2D _rb;
    private void Awake() {
        
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        
        target = GameManager.Instance.player.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        
        Vector2 dirVec = target.position - _rb.position;
        Vector2 nextVec = dirVec.normalized * Time.fixedDeltaTime;
        _rb.MovePosition(_rb.position + nextVec);
        _rb.velocity = Vector2.zero;

    }
}
