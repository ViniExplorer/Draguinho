using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food: MonoBehaviour
{
    public float foodPoints;

    private Collider2D c2d;

    SpriteRenderer spr;

    bool alreadyRotting;

    public GameObject explosion;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        c2d = GetComponent<BoxCollider2D>();
        alreadyRotting = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor" && alreadyRotting == false)
        {
            GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Hit");
            StartCoroutine(RotFood());
            alreadyRotting = true;
        }
    }

    IEnumerator RotFood()
    {
        float a = 1f;
        while (a != 0f)
        {
            spr.color = new Color(a, a, a);
            a -= 0.1f;
            if (a <= 0f)
            {
                yield return new WaitForSeconds(1f);
                Destroy(gameObject);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
