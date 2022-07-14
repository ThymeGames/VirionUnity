using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMaster : MonoBehaviour
{
    // Start is called before the first frame update

    public string PauseButton = "escape";
    public GameObject PauseCanvas;
    bool IsActivated = false;

    void Start()
    {
        DeActivatePause();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(PauseButton)) {

            if (IsActivated) {
                DeActivatePause();
            } else {
                ActivatePause();
            }

        }

    }

    void ActivatePause() {
        Debug.Log("Activate PAUSE! (╯°□°）╯︵ ┻━┻");
        IsActivated = true;
        PauseCanvas.SetActive(IsActivated);
        Time.timeScale = 0;    
    }

    void DeActivatePause() {
        Debug.Log("DeActivate PAUSE! ┬─┬﻿ ノ( ゜-゜ノ)");
        IsActivated = false;
        PauseCanvas.SetActive(IsActivated);
        Time.timeScale = 1;    
    }

}
