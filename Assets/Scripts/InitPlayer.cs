using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitPlayer : MonoBehaviour {

    private static bool playerExists;

    public Transform spawnPoint;

    private void Awake()
    {

        gameObject.transform.position = spawnPoint.position;

    }


}
