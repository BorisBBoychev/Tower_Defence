using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] private List<Block> path;

    // Start is called before the first frame update
    void Start()
    {
        PrintAllWaypoints();
    }

    private void PrintAllWaypoints()
    {
        foreach (var waypoint in path)
        {
            print(waypoint);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
