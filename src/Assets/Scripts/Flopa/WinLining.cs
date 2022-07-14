using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLining : MonoBehaviour
{

    public Transform WinLine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > WinLine.transform.position.x) {
            Debug.Log("WIN AGAGAGAGAGHAHA");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
