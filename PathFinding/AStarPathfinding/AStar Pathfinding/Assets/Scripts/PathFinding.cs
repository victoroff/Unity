using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    Grid grid;
    public Transform StartPosition;
    public Transform TargedtPosition;

    private void Awake()
    {
        grid = GetComponent<Grid>();
    }
    private void Update()
    {
        FindPath(StartPosition.position,TargedtPosition.position);
    }

    private void FindPath(Vector3 startPosition, Vector3 targetPosition)
    {
        Node startNode = grid.NodeFromWorldPosition(startPosition);
        Node targetNode = grid.NodeFromWorldPosition(targetPosition);

        List<Node> openList = new List<Node>();
        HashSet<Node> closedList = new HashSet<Node>();

        openList.Add(startNode);
        while (openList.Count > 0)
        {
            Node currentNode = openList[0];
            for (int i = 0; i < openList.Count; i++)
            {
                if (openList[i].FCost < currentNode.FCost || openList[i].FCost == currentNode.FCost &&
                    openList[i].hCost < currentNode.hCost )
                {
                    currentNode = openList[i];
                }
            }

            openList.Remove(currentNode);
            closedList.Add(currentNode);

            if (currentNode == targetNode)
            {
                GetFinalPath(startNode, targetNode);
            }

            foreach (Node neighborNode in grid.GetNeighboringNodes(currentNode))
            {
                if (!neighborNode.isWall || closedList.Contains(neighborNode))
                {
                    continue;
                }
                int moveCost = currentNode.gCost + GetmanhattenDistance(currentNode,neighborNode);    
            }
        }
    }

    private int GetmanhattenDistance(Node currentNode, Node neighborNode)
    {
        throw new NotImplementedException();
    }

    private void GetFinalPath(Node startNode, Node targetNode)
    {
        int x = Mathf.Abs(startNode.gridX - targetNode.gridX);
        int y = Mathf.Abs(startNode.y - targetNode.gridY);
    }
}
