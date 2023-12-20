using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleList : MonoBehaviour
{
    [SerializeField] GameObject[] prefabs;

    public GameObject GetRandomObsPrefab()
    {
        if (prefabs.Length == 0)
        {
            Debug.LogError("Please Add At Least 1 Prefab");
            return null;
        }
        int randomIndex = Random.Range(0, prefabs.Length);
        return prefabs[randomIndex];
    }
}
