using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMasterOpenSpace : MonoBehaviour
{

    public string sceneName = "Inception";
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
            SceneManager.LoadScene(sceneName);
        }
    }
}
