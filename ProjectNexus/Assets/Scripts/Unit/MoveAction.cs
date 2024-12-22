using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : MonoBehaviour
{
    [Header("Movement Atts")]
    [SerializeField] private float movementSpeed = 4.0f;
    [SerializeField] private float rotationSpeed = 10.0f;
    [SerializeField] private int maxMoveDistance = 4;

    private Vector3 targetPosition;
    [SerializeField] private Unit unit;
   

    [Header("Animation Atts")]
    private Animator animator;
    [SerializeField] private string animator_IsWalking = "IsWalking";
    private void Awake()
    {
        unit = GetComponent<Unit>();
        targetPosition = transform.position;
    }

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        if (!animator) return;



        float stoppingDistance = 0.1f;

        if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
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

       
    }

    public void Move(GridPosition gridPosition)
    {
        this.targetPosition = LevelGrid.Instance.GetWorldPosition(gridPosition);
    }


    public bool IsValidActionGridPosition(GridPosition gridPosition)
    {
        List<GridPosition> validGridPositionList = GetValidActionGridPositionList();
        
        return validGridPositionList.Contains(gridPosition);
    }

    public List<GridPosition> GetValidActionGridPositionList()
    { 

        List<GridPosition> validGridPositionList = new List<GridPosition>();

        GridPosition unitGridPosition = unit.GetGridPosition();

        for(int x=-maxMoveDistance;x <= maxMoveDistance;x++)
        {
            for(int z=-maxMoveDistance;z<=maxMoveDistance;z++)
            {
                GridPosition offsetGridPosition = new GridPosition(x,z);

                GridPosition testGridPosition = unitGridPosition + offsetGridPosition;

                if (!LevelGrid.Instance.IsValidGridPositon(testGridPosition))
                {
                    continue;
                }

                if(unitGridPosition == testGridPosition)
                {
                    //same grid position where the unit is already at
                    continue;
                }

                if (LevelGrid.Instance.HasAnyUnitAtGridPosition(testGridPosition))
                {
                    ///Grid Position already occupied with another unit
                    continue;
                }


                validGridPositionList.Add(testGridPosition);
                //Debug.Log(testGridPosition);
            }
        }

        return validGridPositionList;
    }

}
