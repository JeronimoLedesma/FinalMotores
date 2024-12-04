using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public float health;
    public Slider healthSlider;
    public GameObject scoreManager;
    public int scoreGain;
    public Rigidbody body;

    void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("score");
        body = GetComponent<Rigidbody>();
        
    }

    public void loseHealth(float damage)
    {
        body.velocity = Vector3.zero;
        health -= damage;
        healthSlider.value = health;
        if (health <= 0)
        {
            scoreManager.gameObject.GetComponent<Score>().gainScore(scoreGain);
            Destroy(transform.parent.gameObject);
        }
    }
}
