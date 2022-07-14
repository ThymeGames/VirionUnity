using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{

    public GameObject Grid;

    // Update is called once per frame
    void Update()
    {
        if (Grid.GetComponentInChildren<GridMaster>().IsSolved()) {
            float timerFinal = Grid.GetComponent<DNA_Controller>().timerFinal;
            gameObject.transform.Rotate(
                new Vector3(0, 0, -Time.deltaTime / timerFinal)
            );
        }
    }

}
