using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MacroPredatorCollisions : MonoBehaviour
{

    public GameObject darkness;
    public float load_menu_offset = 5f;
    public float darkness_offset = 1.5f;

    Animator anim;
    AudioManager audioManager;
    float timer = 0;
    float timer_scene = 100000f;
    float timer_darkness = 1000000f;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > timer_scene) {
            LoadMenu();
        }

        if (timer > timer_darkness) {
            // Debug.Log("Instantiate DARKNESS!!!11");
            Instantiate(darkness);
            timer_darkness += 100000f;
        }

        // Debug.Log(timer.ToString());
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        string tag = col.gameObject.tag;
        if (tag == "Player") {

            Vector3 pos = col.gameObject.transform.position;
            transform.position = pos;

            anim.Play("Run", -1, 0f);

            timer_scene = timer + load_menu_offset;
            timer_darkness = timer + darkness_offset;

            gameObject.GetComponent<ShutUpCamera>().ShutUp();
            gameObject.GetComponent<AudioSource>().Stop();
            gameObject.GetComponent<StopEverything>().Execute();
            Destroy(gameObject.GetComponent<Homing>());

            // Debug.Log(timer_scene.ToString() + " " + timer_darkness.ToString());

        }
    }

    void LoadMenu() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
