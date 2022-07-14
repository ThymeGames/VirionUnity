using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Dash : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;
    public GameObject DashArrow;
    public Vector2 start;
    public Vector3 step;
    
    Dashing dash;
    int count = 0;
    List<GameObject> DrawnObjects = new List<GameObject>();


    void Start()
    {
        dash = player.GetComponent<Dashing>();
        count = dash.GetCount();
        ReDraw();
    }

    // Update is called once per frame
    void Update()
    {
        int c = dash.GetCount();
        if (c != count) {
            count = c;
            ReDraw();
        }

    }

    void ReDraw() {

        foreach(GameObject obj in DrawnObjects) {
            Destroy(obj);
        }

        DrawnObjects.Clear();

        for (int i = 0; i < count; ++i) {
            GameObject obj = Instantiate(DashArrow, transform);
            RectTransform rt = obj.GetComponent<RectTransform>();
            rt.position = rt.position + step * i;

            DrawnObjects.Add(obj);
        }

        return;

    }

}
