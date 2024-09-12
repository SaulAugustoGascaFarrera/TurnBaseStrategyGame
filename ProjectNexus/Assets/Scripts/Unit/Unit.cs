using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Unit : MonoBehaviour
{
    [Header("Movement Atts")]
    private Vector3 targetPosition;
    [SerializeField] private float movementSpeed = 4.0f;

    // Update is called once per frame
    void Update()
    {
        float stoppingDistance = 0.1f;

        if(Vector3.Distance(transform.position,targetPosition) > stoppingDistance)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            transform.position += moveDirection * movementSpeed * Time.deltaTime;


            transform.forward = Vector3.Slerp(transform.forward, moveDirection, 6.0f * Time.deltaTime);
           
        }

       
        if(Input.GetMouseButtonDown(0))
        {
            Move(MouseWorld.GetPosition());
        }
        

    }


    private void Move(Vector3 targetPosition)
    {
          this.targetPosition = targetPosition;
    }
}
