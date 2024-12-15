using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObjectTest
{
    private GridSystemTest gridSystemTest;
    private GridPositionTest gridPositionTest;

    public GridObjectTest(GridSystemTest gridSystemTest,GridPositionTest gridPositionTest)
    {
        this.gridSystemTest = gridSystemTest;
        this.gridPositionTest = gridPositionTest;
    }

    public override string ToString()
    {
        return gridPositionTest.ToString();
    }
}
