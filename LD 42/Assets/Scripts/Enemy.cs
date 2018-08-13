using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private Rigidbody2D rb;
    private HouseIsReady[] houseIsReady;
    private PlayerController player;
    private Animator animator;

    public GameObject pizzapizza;
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
                this.target = houseIsReady[i].gameObject;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, this.target.transform.position, MoveSpeed * Time.deltaTime);

        Vector2 me = transform.position;
        Vector2 target = this.target.transform.position;
        CalculateAngleForAnim(me, target);


    }

    public void EnemyDropoff()
    {
        player.GetComponent<PlayerController>().score -= 50;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (animator.GetBool("isHorizontal") == true)
        {
            gameObject.transform.Rotate(0, 0, 90);
        }
        animator.SetBool("is_dead", true);
        print("Enemy destroyed");
        Transform childed = transform.GetChild(0);
        Destroy(childed.gameObject);
        Instantiate(pizzapizza, gameObject.transform.position, Quaternion.identity);
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

    private void CalculateAngleForAnim(Vector2 me, Vector2 target)
    {
        float angleBetween = AngleBetweenVector2(me, target);

        if (angleBetween >= 45 && angleBetween < 135)
        {
            animator.SetTrigger("up");
            animator.SetBool("isHorizontal", false);
        }
        else if (angleBetween >= 135 || angleBetween < -135)
        {
            animator.SetTrigger("left");
            animator.SetBool("isHorizontal", true);
        }
        else if (angleBetween >= -135 && angleBetween < -45)
        {
            animator.SetTrigger("down");
            animator.SetBool("isHorizontal", false);
        }
        else if (angleBetween >= -45 && angleBetween < 45)
        {
            animator.SetTrigger("right");
            animator.SetBool("isHorizontal", true);
        }
    }
    private float AngleBetweenVector2(Vector2 vec1, Vector2 vec2)
    {
        Vector2 diference = vec2 - vec1;
        float sign = (vec2.y < vec1.y) ? -1.0f : 1.0f;
        return Vector2.Angle(Vector2.right, diference) * sign;
    }
}
