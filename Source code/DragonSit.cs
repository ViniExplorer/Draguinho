using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSit : MonoBehaviour
{
    /// <summary>
    /// This is for keeping the dragon sitting on the player's hands.
    /// </summary>
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.parent.GetChild(0).position;
    }
}
