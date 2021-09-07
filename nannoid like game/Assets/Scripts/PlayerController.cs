using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Camera game_OrthographicCamera;

    //camera sizes
    private float halfHeight;
    private float halfWidth;
    //

    public float speed;
    private float playerScaleSize;
    
    void Start()
    {
        game_OrthographicCamera = Camera.main.GetComponent<Camera>();
        halfHeight = game_OrthographicCamera.orthographicSize;
        halfWidth = game_OrthographicCamera.aspect * halfHeight;
        // speed = 0.05f;
        playerScaleSize = transform.localScale.x;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = transform.position + new Vector3(-speed, 0);
            if (transform.position.x <= -(halfWidth - playerScaleSize / 2)) // we take the width of the camera and subtract half of the size of
                                                                            // our player so that when we reach the end the player stays onscreen
            {
                transform.position = new Vector3(-(halfWidth - playerScaleSize / 2), transform.position.y);
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = transform.position + new Vector3(speed, 0);
            if (transform.position.x >= halfWidth - playerScaleSize / 2)
            {
                transform.position = new Vector3(halfWidth - playerScaleSize / 2, transform.position.y);
            }
        }
    }
}
