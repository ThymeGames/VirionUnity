using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetMouseButtonDown(0) )
        {
            Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
            RaycastHit hit;
            
            Debug.Log("Mouse clicked on: ...");

            if( Physics.Raycast( ray, out hit, 100 ) )
            {
                Transform t = hit.transform;
                Debug.Log(t.gameObject.name );

                Bounds bounds = t.GetComponent<SpriteRenderer>().bounds;

                Debug.Log("Bounds");
                Debug.Log(bounds.min.ToString() + " " + bounds.max.ToString());
                
            } else {
                Debug.Log("nothing");
            }
        }
    }

}
