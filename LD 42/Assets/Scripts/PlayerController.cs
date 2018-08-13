using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    int PizzaScore = 0;
    int pizzas = 5;
    public int score = 0;
    string str;

    public GameObject EnemyHit;
    public Text PizzaText;
    public Text ScoreText;

    private Animator animator;
    private Rigidbody2D rb;

    // Initialize player animations
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        float Slowdown = 0;
        Slowdown -= .1f * PizzaScore;
        animator.SetBool("is_walking", false);

        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("is_walking", true);
            animator.SetFloat("input_X", -1);
            animator.SetFloat("input_Y", 0);
            transform.Translate(-Vector2.right * (8 - Slowdown) * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("is_walking", true);
            animator.SetFloat("input_X", 1);
            animator.SetFloat("input_Y", 0);
            transform.Translate(Vector2.right * (8 - Slowdown) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("is_walking", true);
            animator.SetFloat("input_X", 0);
            animator.SetFloat("input_Y", 1);
            transform.Translate(Vector2.up * (8 - Slowdown) * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("is_walking", true);
            animator.SetFloat("input_X", 0);
            animator.SetFloat("input_Y", -1);
            transform.Translate(-Vector2.up * (8 - Slowdown) * Time.deltaTime);
        }
        

        str = PizzaScore.ToString();
        PizzaText.text = str;
        ScoreText.text = score.ToString();
    }

    public void PizzaPickup()
    {
        int pizzas = Random.Range(1, 6);

        PizzaScore += pizzas;
        PizzaText.text = str;
    }

    public void PizzaDropoff()
    {
        score += PizzaScore * 200;
        ScoreText.text = score.ToString();
        PizzaScore = 0;

    }
    
}
