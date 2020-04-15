using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Color exploredColor;
    [SerializeField]GameObject towerPrefab;
    private GameObject instanciatedObject;


    //public is ok here because it is a data class
    public bool isExplored = false;
    public Waypoint exploredFrom;
    public bool isPlaceable = true;

    private Vector2Int gridPos;
    const int gridSize = 10;

    public int GetGridSize()
    {
        return gridSize;
    }

    void Update()
    {
        if (isExplored)
        {
            //SetTopColor(exploredColor);
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !PauseMenu.gameIsPaused && !PlayerHealth.isDead) //left click
        {
            if (isPlaceable)
            {
                FindObjectOfType<TowerFactory>().AddTower(this);
            }
        }
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize) ,
            Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }

    public void SetTopColor(Color color)
    {
        var topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }

}
