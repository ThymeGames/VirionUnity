using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLining : MonoBehaviour
{

    public Transform WinLine;

    void Update()
    {
        if (transform.position.x > WinLine.transform.position.x) {
            Debug.Log("WIN AGAGAGAGAGHAHA");
            SceneManager.LoadScene("Final");
        }
    }
}
