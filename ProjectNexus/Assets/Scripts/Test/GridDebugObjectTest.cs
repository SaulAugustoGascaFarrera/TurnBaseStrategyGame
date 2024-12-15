using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridDebugObjectTest : MonoBehaviour
{
    private GridObjectTest gridObjectTest;
    [SerializeField] private TextMeshPro textMeshPro;

    public void SetGridObjectTest(GridObjectTest gridObjectTest)
    {
        this.gridObjectTest = gridObjectTest;
    }

    // Update is called once per frame
    void Update()
    {
        textMeshPro.text = gridObjectTest.ToString();
    }
}
