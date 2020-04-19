using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float direction;
    public float moveSpeed;
    public bool done = false;

    public GameObject explosion;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        if (collision.gameObject.tag == "MainCamera")
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (done == false && direction != 0)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(direction * 20f, 0f), ForceMode2D.Impulse);
            done = true;
        }

    }
}
