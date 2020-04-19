using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMeter : MonoBehaviour
{
    public bool isFood;

    Draguinho draguinho;

    private void Start()
    {
        draguinho = GameObject.Find("Draguinho").GetComponent<Draguinho>();
    }

    private void Update()
    {
        if (isFood)
        {
            float percentage = draguinho.food / draguinho.maxFood;
            transform.localScale = new Vector3(percentage, 1f, 1f);
        } else
        {
            float percentage = draguinho.hp / draguinho.maxHP;
            percentage = Mathf.Clamp(percentage, 0f, 1f);
            transform.localScale = new Vector3(percentage, 1f, 1f);
        }
    }
}
