using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour {

    public GameObject regularCanvas;
    public GameObject deathCanvas;

    private PlayerController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        regularCanvas.SetActive(true);
        deathCanvas.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOver();
    }

    public void GameOver()
    {
        player.gameObject.SetActive(false);
        regularCanvas.SetActive(false);
        deathCanvas.SetActive(true);
    }

}
