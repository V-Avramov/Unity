using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is used so that the walls are placed at the end of the screen
public class WallPlacement : MonoBehaviour
{ 
    public enum WallType { Front, Left, Right, Bottom };
    public WallType wType;
    public GameObject playAgainInterface;
    // Start is called before the first frame update
    void Start()
    {
        Camera game_OrthographicCamera = Camera.main.GetComponent<Camera>();
        CameraScale cameraScale = new CameraScale(game_OrthographicCamera);

        float height = 2 * cameraScale.getHalfHeight();
        float width = 2 * cameraScale.getHalfWidth();
        switch (wType)
        {
            case WallType.Front:
                transform.localScale = new Vector3(width, 1, 0);
                transform.position = new Vector3(0, cameraScale.getHalfHeight() + (transform.localScale.y / 2), 0);
                break;

            case WallType.Left:
                transform.localScale = new Vector3(height, 1, 0);
                transform.position = new Vector3(-(cameraScale.getHalfWidth() + (transform.localScale.y / 2)), 0, 0);
                break;
            case WallType.Right:
                transform.localScale = new Vector3(height, 1, 0);
                transform.position = new Vector3(cameraScale.getHalfWidth() + (transform.localScale.y / 2), 0, 0);
                break;

            case WallType.Bottom:
                transform.localScale = new Vector3(width, 1, 0);
                transform.position = new Vector3(0, -(cameraScale.getHalfHeight() + (transform.localScale.y)), 0);
                break;
        }
    }
}
