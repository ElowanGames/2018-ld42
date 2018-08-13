using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHit : MonoBehaviour {

    public GameObject regularCanvas;

    private PlayerController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOver();
    }

    public void GameOver()
    {
        player.gameObject.SetActive(false);
        SceneManager.LoadScene("GameOver");
    }

}
