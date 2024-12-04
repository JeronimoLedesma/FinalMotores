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
    public GameObject explosion;
    public Animator dAnimator;

    void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("score");
        body = GetComponent<Rigidbody>();
        dAnimator = GetComponent<Animator>();
    }

    public void loseHealth(float damage)
    {
        body.velocity = Vector3.zero;
        health -= damage;
        healthSlider.value = health;
        if (health <= 0)
        {
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        dAnimator.SetTrigger("Die");
        GetComponent<Collider>().enabled = false;
        GetComponentInParent<EnemyNAv>().enabled = false;
        scoreManager.gameObject.GetComponent<Score>().gainScore(scoreGain);
        GameObject explode = Instantiate(explosion, transform.position, transform.rotation);
        yield return new WaitForSeconds(1f);
        Destroy(explode, 1f);
        Destroy(transform.parent.gameObject);
    }
}
