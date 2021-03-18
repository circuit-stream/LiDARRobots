using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LiDARButton : MonoBehaviour
{
    [SerializeField]
    private GameObject robotSphere;

    [SerializeField]
    private GameObject plane;

    [SerializeField]
    private TMP_Text text;

    /// <summary>
    /// If false, spawn the robot
    /// If true, spawn the plane
    /// </summary>
    private bool switchPrefab = true;

    
    public void Toggle()
    {
        switchPrefab = !switchPrefab;

        if (switchPrefab)
        {
            LiDARPrefabManager.instance.prefab = plane;
            
        }
        else
        {
            LiDARPrefabManager.instance.prefab = robotSphere;
        }

        text.text = switchPrefab ? "Robot" : "Plane";

        LiDARPrefabManager.instance.ChangePrefab();
    }

}
