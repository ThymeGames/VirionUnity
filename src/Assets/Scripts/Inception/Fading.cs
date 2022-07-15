using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fading : MonoBehaviour
{
    // Start is called before the first frame update

    public float fadeTime = 1f;

    SpriteRenderer sr;
    public bool isFadingOut = false;

    void Awake()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Color c = sr.material.color;
        float direction = isFadingOut ? -1 : 1;
        float alpha_drop = Time.deltaTime / fadeTime;
        float alpha = c.a + direction * alpha_drop;
        alpha = Mathf.Clamp01(alpha);
        c.a = alpha;
        sr.material.color = c;
    }

}
