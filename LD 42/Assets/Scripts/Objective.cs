using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour {

    private Enemy enemy;
    private PlayerController player;

    private void Start()
    {
        enemy = FindObjectOfType<Enemy>();
        player = FindObjectOfType<PlayerController>();
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        
        player.GetComponent<PlayerController>().PizzaDropoff();
    }

}
