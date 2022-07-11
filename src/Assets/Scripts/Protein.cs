using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protein : MonoBehaviour
{

    Bounds _bounds;
    bool _isVertical;
    SpriteRenderer sprite;

    void Awake()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        _bounds = sprite.bounds;
        _isVertical = _bounds.size.x < _bounds.size.y;

        string s = _isVertical ? "vertical" : "horizontal";

        Debug.Log("Created " + s + " " + gameObject.name);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isVertical() {
        return _isVertical;
    }

    public Bounds bounds() {
        return sprite.bounds;
    }
}
