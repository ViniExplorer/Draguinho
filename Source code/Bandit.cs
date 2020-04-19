using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandit : MonoBehaviour
{
    GameObject draguinho;
    Animator anim;
    public bool getDraguinho;
    float moveSpeed;
    bool alreadyMoving;
    bool done;
    bool moving;
    
    // Start is called before the first frame update
    void Awake()
    {
        moving = false;
        done = false;
        anim = GetComponent<Animator>();
        moveSpeed = 5f;
        getDraguinho = false;
        alreadyMoving = false;
        draguinho = GameObject.Find("Draguinho");
    }

    IEnumerator Burn()
    {
        if (!done)
        {
            done = true;
            float a = 0.1f;

            while (a != 1f)
            {
                GetComponent<SpriteRenderer>().color = new Color(a, a, a);
                a += 0.1f;
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(1f);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fire")
            Destroy(gameObject);
    }

    void FaceDraguinho()
    {
        if (draguinho.transform.position.x < transform.position.x)
            transform.localScale = new Vector3(-0.4f, 0.4f, 1f);
        else
            transform.localScale = new Vector3(0.4f, 0.4f, 1f);
    }
    
    // Update is called once per frame
    void Update()
    {
        //print(System.Math.Abs((new Vector3(transform.position.x, -8.98f, transform.position.z) - transform.position).y) <= 3f && alreadyMoving == false));
        if (transform.position.y < 0f && alreadyMoving == false)
        {
            alreadyMoving = true;
            anim.SetBool("CloseToGround", true);
            getDraguinho = true;
            StartCoroutine(GoToDraguinho());
        }
        if (Vector2.Distance(transform.position, draguinho.transform.position) > 1.3f && alreadyMoving == true && moving == false)
            StartCoroutine(GoToDraguinho()); 
        FaceDraguinho();
    }
    
    IEnumerator GoToDraguinho()
    {
        if (moving == false)
        {
            moving = true;
            while (System.Math.Abs(transform.position.x - draguinho.transform.position.x) > 1.3f)
            {
                if (draguinho.transform.position.x - transform.position.x < 0)
                {
                    transform.position += new Vector3(Mathf.Abs(moveSpeed * Time.deltaTime) * -1f, 0f);
                    yield return null;
                }
                else
                {
                    transform.position += new Vector3(Mathf.Abs(moveSpeed * Time.deltaTime), 0f);
                    yield return null;
                }
            }
            moving = false;
        }
        
    }
}
