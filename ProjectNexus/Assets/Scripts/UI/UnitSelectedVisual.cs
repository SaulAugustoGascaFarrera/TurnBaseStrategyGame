using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectedVisual : MonoBehaviour
{

    //private UnitActionSystem actionSystem;
    private Unit unit;
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        unit = GetComponentInParent<Unit>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        UnitActionSystem.instance.OnSelectedUnitChanged += Instance_OnSelectedUnitChanged; ;
    }

    private void Instance_OnSelectedUnitChanged(object sender, UnitActionSystem.OnSelectedUnitEventArgs e)
    {
        if (e.argSelectedUnit == unit)
        {
            meshRenderer.enabled = true;
        }
        else
        {
            meshRenderer.enabled = false;
        }
    }

    private void UpdateVisual()
    {

        if (UnitActionSystem.instance.GetSelectedUnit() == unit)
        {
            meshRenderer.enabled = true;
        }
        else
        {
            meshRenderer.enabled = false;
        }
    }

    
}
