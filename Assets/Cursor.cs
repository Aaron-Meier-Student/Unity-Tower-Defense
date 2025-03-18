using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Cursor : MonoBehaviour
    {
        Grid grid;
        Vector3Int GetTargetTile()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Vector3Int targetTile;
                targetTile = Grid.WorldToGrid(hit.point + hit.normal * 0.5f);
                if (grid.Occupied(targetTile)) targetTile = new Vector3Int(0,100,0);
                return targetTile;
            }
            return new Vector3Int(0, 100, 0);
        }

        void Start ()
        {
            grid = FindObjectOfType<Grid>();
        }

        void Update()
        {
            transform.position = GetTargetTile();
        }

    }
}
