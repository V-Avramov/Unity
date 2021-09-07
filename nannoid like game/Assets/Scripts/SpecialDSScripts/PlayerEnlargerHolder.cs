using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnlargerHolder : MonoBehaviour
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
            GameObject upgrade = transform.GetChild(0).gameObject;
            upgrade.SetActive(true);
            upgrade.transform.parent = transform.parent;
            upgrade.GetComponent<CircleCollider2D>().enabled = true;    // I literally have no idea why they are being deactivated
            upgrade.GetComponent<PlayerEnlarger>().enabled = true;      // so I do it manually
        }
    }
}
