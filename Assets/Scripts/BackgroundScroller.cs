using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float scrollingSpeed = 0.5f;

    Material material;

    Vector2 offSet;

    // Start is called before the first frame update
    void Start()
    {
        material = this.GetComponent<Renderer>().material;

        // no x value b/c we are only scrolling the background up and down.
        offSet = new Vector2(0f, scrollingSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        // frame-rate independent arithmetic
        material.mainTextureOffset += offSet * Time.deltaTime;
    }
}
