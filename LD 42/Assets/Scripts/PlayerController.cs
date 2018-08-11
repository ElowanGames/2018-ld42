using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public Text text;

    private Animator animator;


    // Initializes player animations
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Allows player movement with animations
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetInteger("Direction", 3);
            transform.Translate(-Vector2.right * 4 * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetInteger("Direction", 1);
            transform.Translate(Vector2.right * 4 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            animator.SetInteger("Direction", 0);
            transform.Translate(Vector2.up * 4 * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetInteger("Direction", 2);
            transform.Translate(-Vector2.up * 4 * Time.deltaTime);
        }
    }

    public void PizzaPickup()
    {
        int pizzas = 5; int score = 0;  string str = score.ToString();
        
        score += pizzas;
        text.text = str;
    }
    
}
