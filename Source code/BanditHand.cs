using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditHand : MonoBehaviour
{
    Bandit bandit;
    GameObject draguinho;

    // Start is called before the first frame update
    void Awake()
    {
        draguinho = GameObject.Find("Draguinho");
        bandit = transform.parent.gameObject.GetComponent<Bandit>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bandit.getDraguinho == true)
            transform.position = new Vector3(draguinho.transform.position.x, draguinho.transform.position.y, transform.position.z);
    }
}
