using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathLining : MonoBehaviour
{

    public Transform DeathLine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < DeathLine.transform.position.x) {
            Debug.Log("DEATH AGAGAGAGAGHAHA");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
