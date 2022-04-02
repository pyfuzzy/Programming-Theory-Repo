using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    [SerializeField] private float rangeX;
    [SerializeField] private float rangeY;
    [SerializeField] private float speedX;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.S))
        {
            Debug.Log("Up Force Added");
            playerRb.AddForce(new Vector2(0, 3000));
        }
        else if(Input.GetKey(KeyCode.A))
        {
            Debug.Log("Left Force Added");
            playerRb.MovePosition(new Vector2(gameObject.transform.position.x -
                                            speedX * Time.deltaTime,
                                            gameObject.transform.position.y));
            //playerRb.AddForce(new Vector2(-3000, 0));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Right Force Added");
            playerRb.MovePosition(new Vector2(gameObject.transform.position.x +
                                speedX * Time.deltaTime,
                                gameObject.transform.position.y));
            //playerRb.AddForce(new Vector2(3000, 0));
        }
        else if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("Down Force Added");
            playerRb.AddForce(new Vector2(0, -1000));
        }
        if (gameObject.transform.position.x > rangeX)
            gameObject.transform.position = new Vector2(rangeX, gameObject.transform.position.y);
        else if (gameObject.transform.position.x < -rangeX)
            gameObject.transform.position = new Vector2(-rangeX, gameObject.transform.position.y);
    }
}
