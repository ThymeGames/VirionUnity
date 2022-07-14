using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    public GameObject cam;
    public float parallaxEffect;

    private Vector3 startpos;

    void Awake()
    {
        startpos = transform.position;
    }

    void Update()
    {
        Vector3 dist = cam.transform.position * parallaxEffect;
        transform.position = new Vector3(
            startpos.x + dist.x,
            startpos.y + dist.y,
            startpos.z
        );
    }
}
