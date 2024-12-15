using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Unit : MonoBehaviour
{
    [Header("Movement Atts")]
    private Vector3 targetPosition;
    [SerializeField] private float movementSpeed = 4.0f;
    [SerializeField] private float rotationSpeed = 10.0f;

    [Header("Animation Atts")]
    private Animator animator;
    [SerializeField] private string animator_IsWalking = "IsWalking";

    GridPosition gridPosition;

    private void Awake()
    {
        targetPosition = transform.position;
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.AddUnitAtGridPosition(gridPosition,this);
    }

    // Update is called once per frame
    void Update()
    {
        if (!animator) return;

        

        float stoppingDistance = 0.1f;

        if(Vector3.Distance(transform.position,targetPosition) > stoppingDistance)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            transform.position += moveDirection * movementSpeed * Time.deltaTime;


            transform.forward = Vector3.Lerp(transform.forward, moveDirection, rotationSpeed * Time.deltaTime);

            animator.SetBool(animator_IsWalking, true);

        }
        else
        {
            animator.SetBool(animator_IsWalking, false);
        }

        GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);

        if(newGridPosition != gridPosition)
        {
            //Unit change grid position
            LevelGrid.Instance.UnitMovedGridPosition(this,gridPosition,newGridPosition);

            gridPosition = newGridPosition;
        }
    }


    public void Move(Vector3 targetPosition)
    {
          this.targetPosition = targetPosition;
    }
}
