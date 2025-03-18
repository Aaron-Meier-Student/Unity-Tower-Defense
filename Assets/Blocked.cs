using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Blocked : MonoBehaviour
    {
        void Awake()
        {
            CollectPoints();
        }

        public void CollectPoints()
        {
            Grid grid = FindObjectOfType<Grid>();

            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject child = transform.GetChild(i).gameObject;
                Vector3 point = child.transform.position;

                grid.Add(Grid.WorldToGrid(point), child);
                child.SetActive(false);
            }
        }
    }
}
