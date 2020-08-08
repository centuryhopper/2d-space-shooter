using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    //private Vector2 movement;
    //private Rigidbody2D rb;

    private float xMin;
    private float XMax;

    private float yMin;
    private float yMax;

    public float padding = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        SetUpXYBounds();
    }

    // Update is called once per frame
    void Update()
    {
        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.x = Mathf.Clamp(movement.x, xMin, XMax);

        //movement.y = Input.GetAxisRaw("Vertical");
        //movement.y = Mathf.Clamp(movement.y, yMin, yMax);


        // adjust horizontal movement accordingly
        float deltaX = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        float newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, XMax);

        // adjust vertical movement accordingly
        float deltaY = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        float newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);
    }

    //private void FixedUpdate()
    //{
    //    rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    //    Debug.Log((Vector2) transform.position);
    //}

    private void SetUpXYBounds()
    {
        Camera camera = Camera.main;
        xMin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        XMax = camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = camera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

}
