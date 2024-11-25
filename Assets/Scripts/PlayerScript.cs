using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Vector2 inputVector;
    public Rigidbody rigidBody;
    bool canJump;
    public TMPro.TextMeshProUGUI scoreText;
    public bool beingHit;
    public float stun;
    public int life;
    public Slider healthSlider;

    void Start()
    {
       rigidBody = GetComponent<Rigidbody>();
       beingHit = false;
       canJump = true;
       Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        Vector3 moveRelative = transform.TransformDirection(move) * speed * Time.deltaTime;

        rigidBody.MovePosition(rigidBody.position + moveRelative);

        if (Input.GetKeyDown(KeyCode.Space) && canJump) { 

            rigidBody.AddForce(0f, jumpForce, 0f, ForceMode.Impulse);
            canJump = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            canJump = true;
        }
        if (collision.gameObject.CompareTag("Enemy") && !beingHit)
        {
            life -= 10;
            healthSlider.value = life;
            if (life > 0)
            {
                StartCoroutine(hitStun());
            }
            else
            {
                SceneManager.LoadScene(2);
            }

        }
    }

    IEnumerator hitStun()
    {
        beingHit = true;
        yield return new WaitForSeconds(stun);
        beingHit = false;
    }
}


