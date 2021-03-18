using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiDARPrefabManager : MonoBehaviour
{
    public static LiDARPrefabManager instance;
    
    public GameObject prefab;

    [SerializeField]
    private Camera arCamera = null;

    [SerializeField]
    private float distanceFromCamera = 0.5f;

    [HideInInspector]
    public GameObject spawnedObject;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void ChangePrefab(GameObject prefab)
    {
        if (spawnedObject)
        {
            Destroy(spawnedObject);
        }

        Vector3 position = arCamera.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2, distanceFromCamera));

        spawnedObject = Instantiate(prefab, position, prefab.transform.rotation);
    }
    public void ChangePrefab()
    {
        if (spawnedObject)
        {
            Destroy(spawnedObject);
        }

        Vector3 position = arCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, distanceFromCamera));

        spawnedObject = Instantiate(prefab, position, prefab.transform.rotation);
    }
}
