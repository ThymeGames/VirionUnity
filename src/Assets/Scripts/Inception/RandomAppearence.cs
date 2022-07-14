using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAppearence : MonoBehaviour
{

    public float time_start = 1f;
    public float proba = 1e-2f;

    float timer = 0;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Awake()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if ((timer > time_start) && (Random.value < proba)) {
            sr.enabled = true;
        }
    }
}
