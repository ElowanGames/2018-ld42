using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private Rigidbody2D rb;
    private HouseIsReady[] houseIsReady;
    private PlayerController player;
    private Animator animator;

    public float MoveSpeed;
    public GameObject target;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        houseIsReady = FindObjectsOfType<HouseIsReady>();
        animator = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        //checks every house GamObject for if they are ready
        for (int i = 0; i < houseIsReady.Length; i++)
        {
            if (houseIsReady[i].name == "ReadyHouse")
            {
                target = houseIsReady[i].gameObject;
            }
        }

        animator.SetFloat("input_x", rb.velocity.x);
        animator.SetFloat("input_y", rb.velocity.y);

        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, MoveSpeed * Time.deltaTime);

    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        animator.SetBool("is_dead", true);
        print("Enemy destroyed");
        Destroy(this);
    }

     void OnTriggerEnter2D(Collider2D collision)
     {
        AttackPlayer();
     }

    private void AttackPlayer()
    {
        target = player.gameObject;
    }

}
