using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBeheavior : MonoBehaviour
{
    public float damage;
    public GameObject bloodVFX;
    public float time;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameObject blood = Instantiate(bloodVFX, transform.position, transform.rotation);
            Destroy(blood, time);
            collision.gameObject.GetComponent<EnemyController>().loseHealth(damage);
            Destroy(gameObject);
        }
    }
}
