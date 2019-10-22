using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    Grid grid;
    public Transform StartPosition;
    public Transform TargetPosition;
      
    private void Awake()
    {
        grid = GetComponent<Grid>();
    }
    private void Update()
    {
        FindPath(StartPosition.position,TargetPosition.position);
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
            for (int i = 1; i < openList.Count; i++)
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
                int moveCost = currentNode.gCost + GetManhattenDistance(currentNode,neighborNode);

                if (moveCost < neighborNode.gCost || !openList.Contains(neighborNode))
                {
                    neighborNode.gCost = moveCost;
                    neighborNode.hCost = GetManhattenDistance(neighborNode, targetNode);
                    neighborNode.Parent = currentNode;

                    if (!openList.Contains(neighborNode))
                    {
                        openList.Add(neighborNode);
                    }
                }
            }
        }
    }

    private int GetManhattenDistance(Node currentNode, Node neighborNode)
    {
        int x = Mathf.Abs(currentNode.gridX - neighborNode.gridX);
        int y = Mathf.Abs(currentNode.gridY - neighborNode.gridY);
        return x + y;
    }

    private void GetFinalPath(Node startingNode, Node targetNode)
    {
        List<Node> FinalPath = new List<Node>();
        Node currentNode = targetNode;

        while (currentNode != startingNode)
        {
            FinalPath.Add(currentNode);
            currentNode = currentNode.Parent;
        }

        FinalPath.Reverse();
        grid.FinalPath = FinalPath;
    }
}
