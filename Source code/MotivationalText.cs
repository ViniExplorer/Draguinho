using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MotivationalText : MonoBehaviour
{
    Text text;

    float drgSize;

    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<Text>();
        drgSize = GameObject.Find("Draguinho").GetComponent<Draguinho>().size;
        string[] motivationalStuff = {
            "You were quite unlucky. Actually no, you're just bad >:). But at least your dragon size was " + drgSize * 100 + " cm.",
            "You really need to learn how to take care of your stuff, especially a live dragon. The size was " + drgSize * 100 + " cm.",
            "Where are those pro gamer moves you were on about? Your dragon's size was " + drgSize * 100 + " cm.",
            "I hope you learned your lesson. Your dragon died with " + drgSize * 100 + " cm."
        };
        text.text = motivationalStuff[Random.Range(0, motivationalStuff.Length - 1)];
    }

}
