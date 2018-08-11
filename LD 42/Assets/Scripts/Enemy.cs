using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private Rigidbody2D rb;
    private HouseIsReady[] houseIsReady;
    private PlayerController player;

    public float MoveSpeed;
    public BoxCollider2D hitSpot;
    public BoxCollider2D weakSpot;
    public PolygonCollider2D FOV;
    public GameObject target;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        houseIsReady = FindObjectsOfType<HouseIsReady>();
        
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
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, MoveSpeed * Time.deltaTime);
        
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject == player)
        {
            print("Enemy destroyed");
            Destroy(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == player)
        {
            AttackPlayer();
        }
    }

    private void AttackPlayer()
    {
        target = player.gameObject;
    }

}
