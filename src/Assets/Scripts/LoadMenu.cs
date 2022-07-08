using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{

    public float time_wait = 5f;
    float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > time_wait) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        }
    }
}
