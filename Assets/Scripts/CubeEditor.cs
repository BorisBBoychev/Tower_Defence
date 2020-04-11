using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{
    [SerializeField] [Range(1f,20f)]float snapParZ = 10f;
    [SerializeField] [Range(1f, 20f)] float snapParX = 10f;

    private TextMesh textMesh;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / snapParX) * snapParX;
        snapPos.z = Mathf.RoundToInt(transform.position.z / snapParZ) * snapParZ;
        transform.position = new Vector3(snapPos.x , 0 , snapPos.z);

        textMesh = GetComponentInChildren<TextMesh>();
        string labelText = snapPos.x / snapParX + "," + snapPos.z / snapParZ;
        textMesh.text = labelText;
        gameObject.name = "Cube " + labelText;
    }
}
