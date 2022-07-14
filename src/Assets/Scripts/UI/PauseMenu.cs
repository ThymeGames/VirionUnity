using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void BackToMenu () {
        Debug.Log("Load Menu");
        SceneManager.LoadScene("Menu");
    }
}
