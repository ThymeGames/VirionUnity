using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPlayerPosition : MonoBehaviour
{
    // Start is called before the first frame update

    public float world_width = 60f;
    public float world_height = 60f;
    public string targetTag;
    Bounds bounds;
    Transform target;

    void Start()
    {
        target = GameObject.FindWithTag(targetTag).transform;
        bounds = gameObject.GetComponentInParent<SpriteRenderer>().bounds;
    }

    // Update is called once per frame
    void Update()
    {

        if (target == null) {
            return;
        }

        float x = target.position.x;
        float y = target.position.y;

        float x_percent = x / world_width / 2;
        float y_percent = y / world_height / 2;

        float x_draw = 1.6f * x_percent;  // bounds.extents.x * x_percent;
        float y_draw = 1.6f * y_percent; // bounds.extents.y * y_percent;

        Debug.Log("MINIMAP");
        Debug.Log(x_percent.ToString() + " " + y_percent.ToString());
        Debug.Log(bounds.extents.x.ToString() + " " + bounds.extents.y.ToString());
        Debug.Log(x_draw.ToString() + " " + y_draw.ToString());

        transform.position = transform.parent.position + new Vector3(x_draw, y_draw);
    }
}
