using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform playerTarget;
    [SerializeField] Vector3 camOffset;
    // Start is called before the first frame update
    void Start()
    {
        playerTarget = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(camOffset.x,
                                    playerTarget.transform.position.y+camOffset.y, camOffset.z);
    }
}
