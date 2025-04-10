using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FireBallDestroy : MonoBehaviour
{
    public Vector2 initialVelocity;
    private Rigidbody2D rb;
    public GameObject fireball;
    public GameObject blow1;
    public GameObject blow2;
    private CapsuleCollider2D capsuleCollider;
    float timer = 0;


    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collide)
    {
        if (collide.gameObject.CompareTag("Enemy") || collide.gameObject.CompareTag("Edge"))
        {
            
            Destroy(fireball);
            GameObject.Find("fire").GetComponent<FireBallController>().FireBallAmount--;
        }
       
        
    }
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > 5) 
        {
            Destroy(fireball);
            GameObject.Find("fire").GetComponent<FireBallController>().FireBallAmount--;
        }
    }
}

