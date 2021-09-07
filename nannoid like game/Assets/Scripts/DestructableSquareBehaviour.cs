using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableSquareBehaviour : MonoBehaviour
{

    public int scoreAmount = 0;
    public GameObject explosion;

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
            if (explosion)
            {
                Instantiate(explosion, transform.position, transform.rotation); // TODO check without transform position and rotation
            }
            if (GameManager.gm)
            {
                GameManager.gm.targetHit(scoreAmount);
            }
            Destroy(gameObject);
        }
    }
}
