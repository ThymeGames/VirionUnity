using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeKey : MonoBehaviour
{
    // Start is called before the first frame update

    public float fadeTime = 2f;
    public List<string> keys = new List<string>{"up"};
    public bool all;

    SpriteRenderer sr;
    bool isFading = false;
    bool[] isPressed;

    void Awake()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        isPressed = new bool[keys.Count];
        for (int i = 0; i < keys.Count; ++i) {
            isPressed[i] = false;
        }

    }


    bool Check() {

        bool isAny = false;
        bool isAll = true;

        for (int i = 0; i < keys.Count; ++i) {
            string key = keys[i];
            bool isDown = Input.GetKeyDown(key);
            isPressed[i] |= isDown;
            isAny |= isDown;
            isAll &= isPressed[i];
        }

        return all ? isAll : isAny;

    }

    void Update()
    {

        if (Check()) {
            isFading = true;
        }

        if (isFading) {
            Fade_();
        }

        if (sr.material.color.a < 0.005) {
            Destroy(gameObject);
        }

    }

    void Fade_()
    {

        Color c = sr.material.color;

        float alpha_drop = Time.deltaTime / fadeTime;
        float alpha = c.a - alpha_drop;
        if (alpha < 0) {
            alpha = 0;
        }
        c.a = alpha;
        sr.material.color = c;

    }
}
