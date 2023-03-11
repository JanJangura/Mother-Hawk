using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossSpawn : MonoBehaviour
{
    public RandomSpawner RS;
    public GameObject minionScript;
    public GameObject FinalBossPrefab;
    public Transform SpawnLocation;

    float timer = 5.5f;
    // Start is called before the first frame update
    void Start()
    {
        disableScript();
        StartCoroutine(waiter());
    }

    void disableScript()
    {
        RS.kill = true;
        minionScript.GetComponent<RandomSpawner>().enabled = false; // by start this turns off this script
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(timer);
        Instantiate(FinalBossPrefab, SpawnLocation.transform.position, Quaternion.identity);
    }
}
