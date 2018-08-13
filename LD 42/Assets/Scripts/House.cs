using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour {

    Enemy enemy;

    private void Start()
    {
        enemy = FindObjectOfType<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        enemy.GetComponent<Enemy>().EnemyDropoff();
    }
}
