using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMasterOpenSpace : MonoBehaviour
{

    public GameObject Player;
    Docking docking;
    
    void Start()
    {
        foreach (Transform t in Player.transform) {
            if (t.name == "Butt") {
                docking = t.GetComponent<Docking>();
            }
        }
    }

    void Update()
    {
        if (docking.IsNicelyDocked()) {
            gameObject.GetComponent<LoadInception>().enabled = true;
        }
    }
}
