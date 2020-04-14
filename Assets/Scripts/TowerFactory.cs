using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] private int towerLimit = 5;
    [SerializeField] private Tower towerPrefab;
    public Queue<Tower> towers = new Queue<Tower>();
    [SerializeField] private GameObject towerParent;
    public void AddTower(Waypoint baseWaypoint)
    {
        var towerPrefab = FindObjectsOfType<Tower>();
        int towersCount = towers.Count;
        print(towersCount);
        if (towersCount < towerLimit)
        {
            InstantiateTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }
    }

    private void MoveExistingTower(Waypoint baseWaypoint)
    {
        var bottomTower = towers.Dequeue();
        bottomTower.baseWaypoint.isPlaceable = true;
        baseWaypoint.isPlaceable = false;
        bottomTower.transform.position = baseWaypoint.transform.position;
        towers.Enqueue(bottomTower);
    }

    private void InstantiateTower(Waypoint baseWaypoint)
    {
        var newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        newTower.transform.parent = towerParent.transform;
        baseWaypoint.isPlaceable = false;

        newTower.baseWaypoint = baseWaypoint;
        baseWaypoint.isPlaceable = false;
        towers.Enqueue(newTower);
    }
}
