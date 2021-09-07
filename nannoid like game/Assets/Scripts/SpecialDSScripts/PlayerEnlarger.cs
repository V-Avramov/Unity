using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnlarger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collidingObject)
    {
        // exit if there is a game manager and the game is over
        if (GameManager.gm)
        {
            if (GameManager.gm.gameIsOver)
                return;
        }

        if (collidingObject.gameObject.tag == "Player" || collidingObject.gameObject.name == "WallBottom")
        {
            collidingObject.transform.localScale = new Vector2(collidingObject.transform.localScale.x + 5, 0.25f);
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1);
    }
}
