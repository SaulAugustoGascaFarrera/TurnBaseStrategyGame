using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{

    //[SerializeField] private Transform gridDebugbjectPrefab;
    //private GridSystem gridSystem;
    // Start is called before the first frame update
    [SerializeField] private Unit unit;
    void Start()
    {
        //gridSystem = new GridSystem(10, 10, 2);
        //gridSystem.CreateDebugObjects(gridDebugbjectPrefab);

    }

    private void Update()
    {
        //Debug.Log(gridSystem.GetGridPosition(MouseWorld.GetPosition()));
        if (Input.GetKeyDown(KeyCode.T))
        {
            GridSystemVisual.Instance.HideAllGridPosition();

            GridSystemVisual.Instance.ShowGridPositionList(unit.GetMoveAction().GetValidActionGridPositionList());

            //unit.GetMoveAction().GetValidActionGridPositionList();
            
        }
    }
}


