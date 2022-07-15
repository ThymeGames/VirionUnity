using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadInception : MonoBehaviour
{

    public float time_wait = 5f;
    float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > time_wait) {
            SceneManager.LoadScene("Inception");
        }
    }

}
