using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public GameObject slidingFloor;
    public Animator sAnimator;

    private void Start()
    {
        sAnimator = slidingFloor.GetComponent<Animator>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            StartCoroutine(Pushed());
        }
    }

    IEnumerator Pushed()
    {
        sAnimator.SetBool("Start", true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }
}
