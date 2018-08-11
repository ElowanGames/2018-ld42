using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaPickups : MonoBehaviour {

    private PlayerController player;
    
	void Start () {
        player = FindObjectOfType<PlayerController>();
	}
	
	void Update () {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.GetComponent<PlayerController>().PizzaPickup();
        Destroy(gameObject);
    }

}
