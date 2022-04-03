using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    [SerializeField] private float rangeX;
    [SerializeField] private float rangeY;
    [SerializeField] private float maxVelocity;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.S))
        {
            if (playerRb.velocity.y < maxVelocity)
            {
                Debug.Log("Up Force Added");
                playerRb.AddForce(new Vector3(0, 3000, 0));
            }
        }
        else if(Input.GetKey(KeyCode.A))
        {
            if(playerRb.velocity.x > -maxVelocity)
            {
                Debug.Log("Left Force Added");
                playerRb.AddForce(new Vector3(-3000, 0, 0));
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (playerRb.velocity.x < maxVelocity)
            {
                Debug.Log("Right Force Added");
                playerRb.AddForce(new Vector3(3000, 0, 0));
            }
        }
        else if (Input.GetKey(KeyCode.W))
        {
            if (playerRb.velocity.y > 0)
            {
                Debug.Log("Down Force Added");
                playerRb.AddForce(new Vector3(0, -1000, 0));
            }
        }
        if (gameObject.transform.position.x > rangeX)
            gameObject.transform.position = new Vector3(-rangeX, gameObject.transform.position.y,0);
        else if (gameObject.transform.position.x < -rangeX)
            gameObject.transform.position = new Vector3(rangeX, gameObject.transform.position.y,0);
    }
}
