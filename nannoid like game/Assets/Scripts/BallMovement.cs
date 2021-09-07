using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Camera game_OrthographicCamera;
    private float movePositionX;
    private float movePositionY;
    // camera sizes
    private float halfHeight;
    private float halfWidth;

    private float movableSphereScaleSize;

    public float speed;
    private static int numberOfBalls = 1;
    // Start is called before the first frame update
    void Start()
    {
        game_OrthographicCamera = Camera.main.GetComponent<Camera>();
        //transform.position = new Vector2(0, 0);
        halfHeight = game_OrthographicCamera.orthographicSize;
        halfWidth = game_OrthographicCamera.aspect * halfHeight;
        speed *= -1;
        movePositionX = 0;
        movePositionY = speed;

        this.GetComponent<Rigidbody2D>().velocity = new Vector2(movePositionX, movePositionY);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = transform.position + new Vector3(movePositionX, movePositionY);
    }

    void OnCollisionEnter2D(Collision2D collidingObject)
    {

        if (collidingObject.collider.name == "WallFront")
        {
            movePositionY *= -1;
            //this.GetComponent<Rigidbody2D>().velocity = new Vector2(movePositionX, movePositionY);
        }
        else if (collidingObject.collider.name == "WallLeft" || collidingObject.collider.name == "WallRight")
        {
            movePositionX *= -1;
            //this.GetComponent<Rigidbody2D>().velocity = new Vector2(movePositionX, movePositionY);
        }
        else if (collidingObject.collider.name == "WallBottom")
        {
            Destroy(gameObject);
            reduceBalls();
            if (numberOfBalls == 0)
            {
                GameManager.gm.userInterface.SetActive(true);
                GameManager.gm.playAgainInterface.SetActive(true);
            }
        }
        else
        {
            float x = hitFactor(transform.position,
                            collidingObject.transform.position);
            if (x > -0.1 && x < 0.1)
            {
                movePositionX = 0;
                movePositionY *= -1;
            }
            else if (x > 0.1)
            {
                movePositionX = 2 * x;
                movePositionY *= -1;
            }
            else if (x < -0.1)
            {
                movePositionX = 2 * x;
                movePositionY *= -1;
            }
        }
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(movePositionX, movePositionY);
    }

    float hitFactor(Vector3 ballPos, Vector3 racketPos)
    {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return (ballPos.x - racketPos.x);
    }

    public void reduceBalls()
    {
        numberOfBalls--;
    }
    public void increaseBalls()
    {
        numberOfBalls++;
    }
}
