using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private void Update()
    {
        Vector3 inputMoveDirection = new Vector3(0, 0, 0);

        if(Input.GetKey(KeyCode.W))
        {
            inputMoveDirection.z = +1.0f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            inputMoveDirection.z = -1.0f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            inputMoveDirection.x = -1.0f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputMoveDirection.x = +1.0f;
        }

        float moveSpeed = 10.0f;

        Vector3 moveVector = transform.forward * inputMoveDirection.z + transform.right * inputMoveDirection.x;
        transform.position += moveVector * moveSpeed * Time.deltaTime;

        Vector3 rotationVector =  new Vector3 (0, 0, 0);

        if (Input.GetKey(KeyCode.Q))
        {
            rotationVector.y = +1.0f;
        }

        if (Input.GetKey(KeyCode.E))
        {
            rotationVector.y = -1.0f;
        }


        float rotationSpeed = 100.0f;

        transform.eulerAngles += rotationVector * rotationSpeed * Time.deltaTime;
    }
}
