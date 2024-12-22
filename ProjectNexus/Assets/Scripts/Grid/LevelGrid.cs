using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{

    public static LevelGrid Instance { get; private set; }

    [SerializeField] private Transform gridDebugbjectPrefab;
    private GridSystem gridSystem;
    [SerializeField] private Unit unit;
    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("There is more than Level Grid Instance");

            Destroy(gameObject);

            return;
        }

        Instance = this;
        gridSystem = new GridSystem(10,10,2);
        gridSystem.CreateDebugObjects(gridDebugbjectPrefab);
    }

    private void Update()
    {
        //Debug.Log(gridSystem.GetGridPosition(MouseWorld.GetPosition()));
       
    }

    public void AddUnitAtGridPosition(GridPosition gridPosition,Unit unit)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        gridObject.AddUnit(unit);
    }

    public List<Unit> GeUnitListAtGridPosition(GridPosition gridPosition)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        return gridObject.GetUnitList();
    }


    public void RemoveUnitAtGridPosition(GridPosition gridPosition,Unit unit)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        gridObject.RemoveUnit(unit);
    }

    public void UnitMovedGridPosition(Unit unit,GridPosition fromGridPositon,GridPosition toGridPosition)
    {
        RemoveUnitAtGridPosition(fromGridPositon,unit);

        AddUnitAtGridPosition(toGridPosition, unit);
    }

    public GridPosition GetGridPosition(Vector3 worldPosition) => gridSystem.GetGridPosition(worldPosition);


    public Vector3 GetWorldPosition(GridPosition gridPosition) => gridSystem.GetWorldPosition(gridPosition); 

    public bool IsValidGridPositon(GridPosition gridPosition) => gridSystem.IsValidGridPosition(gridPosition);


    public int GetWidth()  => gridSystem.GetWidth();

    public int GetHeight() => gridSystem.GetHeight();

    public bool HasAnyUnitAtGridPosition(GridPosition gridPosition)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);

        return gridObject.HasAnyUnit();
    }
}

