using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField]  Waypoint startWaypoint;
    [SerializeField]  Waypoint endWaypoint;

    Dictionary<Vector2Int , Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    List<Waypoint> path = new List<Waypoint>();

    [SerializeField]bool isRunning = true;
    private Waypoint search;

    private Vector2Int[] directions =
    {
        Vector2Int.up, 
        Vector2Int.right,
        Vector2Int.down, 
        Vector2Int.left, 
    };

    public List<Waypoint> GetPath()
    {
        if (path.Count == 0)
        {
            CalculatePath();
        }
        return path;
    }

    private void CalculatePath()
    {
        LoadBlocks();
        ColorStartAndEnd();
        BreadthFirstSearch();
        CreatePath();
    }

    private void CreatePath()
    {
        path.Add(endWaypoint);
        endWaypoint.isPlaceable = false;

        var previous = endWaypoint.exploredFrom;
        while (previous != startWaypoint)
        {
            path.Add(previous);
            previous.isPlaceable = false;
            previous = previous.exploredFrom;

        }
        path.Add(startWaypoint);
        startWaypoint.isPlaceable = false;
        path.Reverse();
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startWaypoint);

        while (queue.Count > 0 && isRunning)
        {
            search = queue.Dequeue();
            search.isExplored = true;
            StopIfEndFound();
            ExploreNeighbours();
        }
    }

    void StopIfEndFound()
    {
        if (search == endWaypoint)
        {
            print("End point found at " + search); //todo remove log
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        if (!isRunning) { return;}
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourCoordinates = search.GetGridPos() + direction;
            try
            {
                QueueNewNeighbours(neighbourCoordinates);
            }
            catch
            {
                //Do nothing
            }
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourCoordinates)
    {
        var neighbour = grid[neighbourCoordinates];
        if (neighbour.isExplored || queue.Contains(neighbour))
        {
        }
        else
        {
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = search;
        }
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();

        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Skipping overlapping block " + waypoint);
            }
            else
            {
                grid.Add(gridPos, waypoint);
            }
        }
    }
}
