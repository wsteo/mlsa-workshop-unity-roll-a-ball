using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField]
    private GameObject player;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    //LateUpdate will run after all other Updates has been called.
    private void LateUpdate() {
        transform.position = player.transform.position + offset;
    }
}
