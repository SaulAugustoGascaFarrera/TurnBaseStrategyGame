using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystemTest 
{
    private int width = 0;
    private int height = 0;
    private float cellSize = 0;
    private GridObjectTest[,] gridObjectTestArray;

    private GridPositionTest gridPositionTest;

    public GridSystemTest(int width,int height,float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridObjectTestArray = new GridObjectTest[width,height];

        for(int x=0;x<width;x++)
        {
            for(int z=0;z < height;z++)
            {

                gridPositionTest = new GridPositionTest(x, z);

                gridObjectTestArray[x, z] = new GridObjectTest(this, gridPositionTest);

                //Debug.Log($"x: {gridPositionTest.x},y: {gridPositionTest.z}");

               

                Debug.DrawLine(GetWorldPosition(gridPositionTest), GetWorldPosition(gridPositionTest) + Vector3.right, Color.yellow, 10000);

            }
           
        }
    }


    public Vector3 GetWorldPosition(GridPositionTest gridPositionTest)
    {
        return new Vector3(gridPositionTest.x,0,gridPositionTest.z) * cellSize;
    }

    public void CreateDebugObjectTest(Transform debugPrefab)
    {
        for(int x=0;x<width; x++)
        {
            for (int z=0;z<height;z++)
            {
                GridPositionTest gridPositionTest = new GridPositionTest(x, z);
                Transform debugTransform = GameObject.Instantiate(debugPrefab,GetWorldPosition(gridPositionTest), Quaternion.identity);
                GridDebugObjectTest gridDebugObjectTest = debugTransform.GetComponent<GridDebugObjectTest>();
                gridDebugObjectTest.SetGridObjectTest(GetGridObjectTest(gridPositionTest));


            }
        }
    }


    public GridObjectTest GetGridObjectTest(GridPositionTest gridPositionTest)
    {
        return gridObjectTestArray[gridPositionTest.x, gridPositionTest.z];
    }

}
