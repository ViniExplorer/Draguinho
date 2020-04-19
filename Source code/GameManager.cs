using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> plants = new List<GameObject>();
    bool isUp;
    Draguinho drg;
    Transform player;
    public GameObject bandit;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        drg = GameObject.Find("Draguinho").GetComponent<Draguinho>();
        isUp = true;
        StartCoroutine(SpawnStuff());
    }

    private void Update()
    {
        if (drg.hp <= 0f || drg.transform.parent.parent != GameObject.Find("Player").transform)
        {
            transform.GetChild(0).gameObject.SetActive(true);

            GameObject.Find("GameStuff").SetActive(false);
        }
        float chance;
        chance = Random.Range(0, 1000);
        if (chance == 1)
        {
            Instantiate(bandit, new Vector3(Random.Range(8f, -8f), 8f), Quaternion.identity);
        }
    }

    IEnumerator SpawnStuff()
    {
        while (isUp)
        {
            Instantiate(plants[Random.Range(0, plants.Count())], new Vector3(Mathf.Clamp(Random.Range(player.position.x - 3f, player.position.x + 3f), -8f, 8f), 7f), Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            drg.gameObject.GetComponent<Animator>().SetTrigger("Eat");
            drg.StartCoroutine(drg.Eating());
            yield return new WaitForSeconds(5f - ((drg.maxFood - drg.food) / 500));
        }
    }

}
