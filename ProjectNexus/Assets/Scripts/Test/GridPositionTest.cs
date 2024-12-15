using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct GridPositionTest 
{
    public int x;
    public int z;

    public GridPositionTest(int x, int z)
    {
        this.x = x; 
        this.z = z;
    }

    public override string ToString()
    {
        return $"x: {x},z: {z}";
    }

}
