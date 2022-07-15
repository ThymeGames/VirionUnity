using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA_Controller : MonoBehaviour
{
    // Start is called before the first frame update

    public GridMaster GridMaster;
    public float timerFinal = 1f;
    Animator anim;
    float timer = 0;
    bool isFinalStarted = false;

    void Awake() {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) {

            bool isGridSolved = GridMaster.GetComponent<GridMaster>().IsSolved();

            if (isGridSolved) {
                
                if (!isFinalStarted) {

                    Debug.Log("Start Final Animation");
                    FindObjectOfType<AudioManager>().Play("Yep");
                    anim.Play("Solved", -1, 0f);
                    isFinalStarted = true;
                }

            } else {

                Debug.Log("Animate this looser");
                FindObjectOfType<AudioManager>().Play("Nope");
                anim.Play("NotSolved", -1, 0f);
            }

        }

        if (isFinalStarted) {
            timer += Time.deltaTime;
        }

    }

    public bool IsSolved() {
        return isFinalStarted && (timer > timerFinal);
    }

}
