using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    // x and y position in the Node Arr
    public int gridX;
    public int gridY;

    //Info if the node is being obstructed
    public bool isWall;

    //world position in the node
    public Vector3 Position;

    //For the Astar algorithm, will store what node it previously came from so it can trace the shortest path
    public Node Parent;

    //the cost of movint to the next square
    public int gCost;
    //the distance to the goal from this node
    public int hCost;

    // quick get fn of g and h costs sum. We don't need set fn because we won't edit FCost
    public int FCost { get { return gCost + hCost; } }

    public Node(bool a_isWall,Vector3 a_Pos, int a_gridX, int a_gridY)
    {
        isWall = a_isWall;
        Position = a_Pos;
        gridX = a_gridX;
        gridY = a_gridY;
    }
}
