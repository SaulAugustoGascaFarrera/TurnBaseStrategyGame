using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Unit : MonoBehaviour
{
   
    GridPosition gridPosition;
    MoveAction moveAction;

    private void Awake()
    {
        moveAction = GetComponent<MoveAction>();
    }

    private void Start()
    {
        gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.AddUnitAtGridPosition(gridPosition,this);
    }

    // Update is called once per frame
    void Update()
    {
        GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);

        if (newGridPosition != gridPosition)
        {
            //Unit change grid position
            LevelGrid.Instance.UnitMovedGridPosition(this, gridPosition, newGridPosition);

            gridPosition = newGridPosition;
        }
    }


    public MoveAction GetMoveAction()
    {
        return moveAction;  
    }

    public GridPosition GetGridPosition()
    {
        return gridPosition;
    }
    
}
