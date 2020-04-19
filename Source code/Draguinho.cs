using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draguinho : MonoBehaviour
{
    public float food;
    public float maxFood;
    public bool eating;
    public float hp;
    public float maxHP;
    public float size;
    public float hunger;

    bool doneBurning;

    public GameObject fire;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        doneBurning = true;
        size = 0.4f;
        hunger = size * 20;
        eating = true;
        animator = GetComponent<Animator>();
        StartCoroutine(DecreaseFood());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (eating == true && collision.gameObject.tag == "Food")
        {
            Food foodStatus = collision.gameObject.GetComponent<Food>();
            if (food + foodStatus.foodPoints > maxFood || food == maxHP)
            {
                food = maxFood;
            }
            else
            {
                food += foodStatus.foodPoints;
                size += 0.002f;
            }
            GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Eat");
            Instantiate(foodStatus.explosion, transform.GetChild(0).position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Bandit")
        {
            transform.parent = collision.transform;
            transform.localScale = new Vector3(-4f, 4f, 1f);
        }
    }

    public IEnumerator Eating()
    {
        eating = true;
        for (int i = 0; i <= 1; i++)
        {
            if (i == 0)
            {
                yield return new WaitForSeconds(1f);
            }
            else
            {
                eating = false;
                break;
            }
        }
    }

    IEnumerator Damaging()
    {
        while (food <= 0f)
        {
            hp -= hunger;
            yield return new WaitForSeconds(0.5f);
        }
        
    }

    IEnumerator DecreaseFood()
    {
        while (true)
        {
            if (food - hunger > 0f)
            {
                food -= hunger;
                if (food > 0f && hp != maxHP)
                {
                    if (hp + hunger > maxHP)
                    {
                        hp = maxHP;
                        food -= hunger;
                    }
                    else
                    {
                        hp += hunger;
                        food -= hunger;
                    }
                }
            }
            else if (food - hunger <= 0f)
            {
                food = 0f;
                StartCoroutine(Damaging());
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator BurnSomeStuffBois()
    {
        if (food - (7 * 30) > 0 && doneBurning == true)
        {
            doneBurning = false;
            animator.SetTrigger("Eat");
            yield return new WaitForSeconds(1f);
            GameObject bulletFire = Instantiate(fire, transform.GetChild(0).position, Quaternion.identity);
            bulletFire.transform.parent = GameObject.Find("GameStuff").transform;
            bulletFire.GetComponent<Fire>().direction = transform.parent.parent.localScale.x;
            food -= 210f;
            doneBurning = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            StartCoroutine(BurnSomeStuffBois());

        hunger = size * 20;

        transform.localScale = new Vector3(size, size, 1f);

        size = Mathf.Clamp(size, 0.4f, 5f);
    }
}
