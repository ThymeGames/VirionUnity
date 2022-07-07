using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MacroPredatorCollisions : MonoBehaviour
{

    public GameObject darkness;
    public float death_time = 5f;

    Animator anim;
    float timer = 0;
    float scene_time = 100000f;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > scene_time) {
            LoadMenu();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        string tag = col.gameObject.tag;
        if (tag == "Player") {
            Debug.Log("OnCollisionEnter2D  " + tag);
            Vector3 pos = col.gameObject.transform.position;
            transform.position = pos;
            Instantiate(darkness);
            gameObject.GetComponent<Rigidbody2D>().velocity *= 0f;
            anim.Play("Run", -1, 0f);

            scene_time = timer + death_time;
        }
    }

    void LoadMenu() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
