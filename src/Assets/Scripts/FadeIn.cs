using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    // Start is called before the first frame update

    public float alpha_step = 0.01f;
    SpriteRenderer sr;
    // bool isFaded = false;
    void Awake()
    {
        GameObject Flash = GameObject.Find("Flash");
        if (Flash == null) {
            Debug.LogWarning("Flash is not found");
        }
        sr = Flash.GetComponent<SpriteRenderer>();
    }

    public IEnumerator Fade_()
    {
        Color c = sr.material.color;
        for (float alpha = 0f; alpha < 1f; alpha += alpha_step)
        {
            c.a = alpha;
            sr.material.color = c;
            Debug.Log(alpha.ToString());
            yield return null;  // new WaitForSeconds(.1f);
        }
    }
}
