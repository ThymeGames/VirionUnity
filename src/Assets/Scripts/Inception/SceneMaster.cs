using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMaster : MonoBehaviour
{

    public string sceneName = "Flopa";
    public GameObject Grid;

    void Update()
    {
        if (Grid.GetComponent<DNA_Controller>().IsSolved()) {
            SceneManager.LoadScene(sceneName);
        }
    }
}
