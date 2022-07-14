using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMaster : MonoBehaviour
{

    public string sceneName = "Flopa";
    public GameObject GridMaster;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GridMaster.GetComponent<GridMaster>().IsSolved()) {
            SceneManager.LoadScene(sceneName);
        }
    }
}
