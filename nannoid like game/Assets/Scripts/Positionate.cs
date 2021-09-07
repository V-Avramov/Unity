using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is used to positionate the player on the right place at the beginning
public class Positionate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Camera game_OrthographicCamera = Camera.main.GetComponent<Camera>();
        CameraScale cameraScale = new CameraScale(game_OrthographicCamera);

        transform.position = new Vector3(0, -(cameraScale.getHalfHeight() - (transform.localScale.y / 2)), 0);
    }
}
