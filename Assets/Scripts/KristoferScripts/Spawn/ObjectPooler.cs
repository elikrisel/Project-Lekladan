using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject ballPrefab;
        public int totalSize;

    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> pooledDictionary;


    void Start()
    {

        pooledDictionary = new Dictionary<string, Queue<GameObject>>();


        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.totalSize; i++)
            {
                GameObject obj = Instantiate(pool.ballPrefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            pooledDictionary.Add(pool.tag, objectPool);
        }
        
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!pooledDictionary.ContainsKey(tag))
        {
                Debug.LogWarning("Pooled object with tag " + " does not exist. ");
                return null;
        }
        
        
        GameObject objectToSpawn =  pooledDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        
        pooledDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;

    }
    
    
}
