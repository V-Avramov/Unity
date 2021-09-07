using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMultiplier : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collidingObject)
    {
        // exit if there is a game manager and the game is over
        if (GameManager.gm)
        {
            if (GameManager.gm.gameIsOver)
                return;
        }

        if (collidingObject.gameObject.tag == "Ball")
        {
            BallMovement ball = collidingObject.gameObject.GetComponent<BallMovement>();

            GameObject ballClone = Instantiate(collidingObject.gameObject);
            ballClone.transform.localPosition = new Vector2(collidingObject.transform.localPosition.x + 1, collidingObject.transform.localPosition.y);
            ball.increaseBalls();
            ballClone = Instantiate(collidingObject.gameObject);    // reusing variable
            ballClone.transform.localPosition = new Vector2(collidingObject.transform.localPosition.x - 1, collidingObject.transform.localPosition.y);
            ball.increaseBalls();
        }
    }
}
