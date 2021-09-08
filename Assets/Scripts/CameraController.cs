using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool bounds = true;
    [SerializeField] float speed = 5f;
    [SerializeField] Transform playerTrans;

    void Start()
    {
        playerTrans = GameObject.Find("Player").GetComponent<Transform>();
    }

    void LateUpdate()
    {
        if (playerTrans == null)
            return;

        transform.position = Vector3.Slerp(transform.position,new Vector3(transform.position.x, playerTrans.position.y, transform.position.z),speed);
    }
}
