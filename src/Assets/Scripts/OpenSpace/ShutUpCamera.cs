using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShutUpCamera : MonoBehaviour
{

    public GameObject cam;

    void Start()
    {
        cam = GameObject.FindWithTag("MainCamera");
    }

    public void ShutUp() {

        foreach (AudioSource source in cam.GetComponents(typeof(AudioSource))) {
            Debug.Log("SHUT UP");
            source.Stop();
        }

    }

}
