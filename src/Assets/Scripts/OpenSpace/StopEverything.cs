using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopEverything : MonoBehaviour
{

    public void Execute() {

        List<string> tags = new List<string>{"Player", "MacroPredator", "BestCellEver"};

        foreach (string tag in tags) {
            GameObject obj = GameObject.FindWithTag(tag);
            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezeAll;

            if (tag == "MacroPredator") {
                obj.GetComponent<AudioSource>().enabled = false;
            }

        }

    }

}