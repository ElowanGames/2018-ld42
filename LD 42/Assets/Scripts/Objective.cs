using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour {

    private PlayerController player;
    private dialogue dial;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        dial = FindObjectOfType<dialogue>();
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        dial.GetComponent<dialogue>().SayStuff();
        player.GetComponent<PlayerController>().PizzaDropoff();
    }

}
