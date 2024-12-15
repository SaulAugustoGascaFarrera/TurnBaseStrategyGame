using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    public static UnitActionSystem instance;

    public event EventHandler<OnSelectedUnitEventArgs> OnSelectedUnitChanged;

    public class OnSelectedUnitEventArgs : EventArgs
    {
        public Unit argSelectedUnit;
    }

    [SerializeField] private Unit selectedUnit;
    [SerializeField] private LayerMask unitLayerMask;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("There is more than one instance");
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            if (TryHandleUnitSelection()) return;
            
            selectedUnit.Move(MouseWorld.GetPosition());
  
        }
    }

    private bool TryHandleUnitSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitResult, float.MaxValue, unitLayerMask))
        {
            
            if(hitResult.transform.TryGetComponent<Unit>(out Unit unit))
            {
               SetSelectedUnit(unit);
               return true;
            }
        }

        return false;
    }


    private void SetSelectedUnit(Unit selectedUnit)
    {

        this.selectedUnit = selectedUnit;

        OnSelectedUnitChanged?.Invoke(this, new OnSelectedUnitEventArgs
        {
            argSelectedUnit = selectedUnit
        });

    }

    public Unit GetSelectedUnit()
    {
        return selectedUnit;
    }


}
