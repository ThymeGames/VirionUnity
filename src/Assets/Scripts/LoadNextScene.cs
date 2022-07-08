using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{

    public float time_wait = 5f;
    public float time_fade = 4f;

    public float alpha_step = 0.01f;

    float timer = 0f;
    SpriteRenderer sr;
    // bool isFaded = false;

    void Awake()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > time_wait) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (timer > time_fade) {
            StartCoroutine(Fade_());
        }
    }

    IEnumerator Fade_()
    {
        Color c = sr.material.color;
        for (float alpha = 1f; alpha > 0; alpha -= alpha_step)
        {
            c.a = alpha;
            sr.material.color = c;
            // Debug.Log(alpha.ToString());
            yield return null;  // new WaitForSeconds(.1f);
        }
    }
}
