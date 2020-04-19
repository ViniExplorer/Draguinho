using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2D;

    public float moveSpeed = 5f;

    public bool isOnGround;

    public GameObject jumpExplosion;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        isOnGround = true;
    }

    void GetInput()
    {
        if (Input.GetButtonDown("Jump") && isOnGround == true)
        {
            GetComponent<Animator>().SetTrigger("Jump");
            GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Jump");
            Instantiate(jumpExplosion, new Vector3(transform.position.x, -4f), Quaternion.identity);
            rb2D.AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
            isOnGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        if (Input.GetAxis("Horizontal") != 0f)
        {
            GetComponent<Animator>().SetBool("Walking", true);
            transform.position += new Vector3(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0f);
            if (Input.GetAxis("Horizontal") < 0)
                transform.localScale = new Vector3(-0.4f, 0.4f, 1f);
            else
                transform.localScale = new Vector3(0.4f, 0.4f, 1f);
        }
        else
            GetComponent<Animator>().SetBool("Walking", false);
    }
}
