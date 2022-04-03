using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform playerTarget;
    private GameManager gameManager;
    [SerializeField] Vector3 camOffset;
    private Vector3 lastPosition;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerTarget = GameObject.Find("Player").GetComponent<Transform>();
        transform.position = new Vector3(camOffset.x,
                             playerTarget.transform.position.y + camOffset.y, camOffset.z);
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (lastPosition.y < (playerTarget.position.y + camOffset.y))
        {
            transform.position = new Vector3(camOffset.x,
                                        playerTarget.position.y + camOffset.y, camOffset.z);
            lastPosition = transform.position;
        }
        else if (transform.position.y-playerTarget.position.y > camOffset.y*4)
        {
            gameManager.PlayerLost();
        }
    }
}
