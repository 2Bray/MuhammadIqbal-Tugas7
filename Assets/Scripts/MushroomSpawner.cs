using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomSpawner : MonoBehaviour
{
    [SerializeField] private Mushroom objPrefab;
    [SerializeField] private int size;

    private List<Mushroom> musroomPool;
    private Vector3 spawnPos;

    private void Start()
    {
        spawnPos = new Vector3(transform.position.x, 10, transform.position.z);

        musroomPool = new List<Mushroom>();

        for (int i = 0; i < size; i++)
        {
            InstantiateNewOne(objPrefab, musroomPool);
        }
    }

    void FixedUpdate(){
        SpawnObject(musroomPool, spawnPos);
    }

    private void InstantiateNewOne(Mushroom obj, List<Mushroom> pool)
    {
        Mushroom item = Instantiate(obj);
        item.DeActive();

        pool.Add(item);
    }

    private void SpawnObject(List<Mushroom> pool, Vector3 pos)
    {
        foreach (Mushroom item in pool)
        {
            if (!item.gameObject.activeInHierarchy)
            {
                item.SpawnObject(pos);
                return;
            }
        }

        InstantiateNewOne(objPrefab, pool);
        pool[pool.Count - 1].SpawnObject(pos);
    }
}
