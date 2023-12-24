using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    public GameObject currentMap;
    GameObject nextMap, previousMap;
    public GameObject[] mapPrefabs;
    bool isThisFirstTime = true;

    private void Start()
    {
        SpawnNextMap();
    }
    private void SpawnNextMap()
    {
        nextMap = Instantiate(GetNewMap());
        nextMap.transform.position = currentMap.transform.position + new UnityEngine.Vector3(0, 0, 160f);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!isThisFirstTime) DeletePrevMap();
            else isThisFirstTime = false;
            SetCurrentMap();
            SpawnNextMap();
            SetNewPosition();
        }
    }

    private void SetNewPosition()
    {
        transform.position = new UnityEngine.Vector3(transform.position.x, transform.position.y, transform.position.z + 160f);
    }

    private void SetCurrentMap() => currentMap = nextMap;
    private GameObject GetNewMap() => mapPrefabs[UnityEngine.Random.Range(0, mapPrefabs.Length - 1)];
    private void DeletePrevMap()
    {
        Destroy(previousMap);
        previousMap = currentMap;
    }
}
