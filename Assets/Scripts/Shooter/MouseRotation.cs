using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotation : MonoBehaviour {

    public float horizontalSpeed;
    public float verticalSpeed;

    private float horizontalMovement = 0.0f;
    private float verticalMovement = 0.0f;

    void Update()
    {
        horizontalMovement += horizontalSpeed * Input.GetAxis("Mouse X");
        verticalMovement -= verticalSpeed * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(verticalMovement, horizontalMovement, 0.0f);
    }
}
