using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    EnemyHit enemy;
    Animator anim;

    private void Start()
    {
        enemy = FindObjectOfType<EnemyHit>();
        anim = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        bool FirstTime = false;
        if (coll.tag == "ReadyHouse")
        {
            enemy.GetComponent<EnemyHit>().GameOver();
        }
        if (FirstTime)
        {
            return;
        }
        if (coll.tag == "Player")
        {
            anim.SetTrigger("FoundPlayer");
            FirstTime = true;
        }
    }
}
