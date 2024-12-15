using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing2 : MonoBehaviour
{

    [SerializeField] private Transform gridDebugbjectPrefabTest;
     private GridSystemTest gridSystemTest;

    void Start()
    {
        gridSystemTest = new GridSystemTest(10, 10,2.0f);
        //Debug.Log(gridSystemTest.GetGridObjectTest(9,9));
        gridSystemTest.CreateDebugObjectTest(gridDebugbjectPrefabTest);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
