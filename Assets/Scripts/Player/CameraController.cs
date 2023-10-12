using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    private Vector3 offset;

    // Start is called before the first frame update
    private void Start()
    {
        offset = target.position - transform.position;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = target.position - offset;
    }
}