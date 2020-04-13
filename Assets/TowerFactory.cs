using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] private int towerLimit = 5;
    [SerializeField] private Tower towerPrefab;
    private int towerCounter;

    public void AddTower(Waypoint baseWaypoint)
    {
        if (towerCounter < towerLimit)
        {
            InstantiateTower(baseWaypoint);
        }
        else
        {
            print("Limit hit");
        }
        
    }

    private void InstantiateTower(Waypoint baseWaypoint)
    {
        Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        towerCounter++;
        baseWaypoint.isPlaceable = false;
    }
}
