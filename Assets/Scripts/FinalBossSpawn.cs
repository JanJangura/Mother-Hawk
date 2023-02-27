using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossSpawn : MonoBehaviour
{
    public RandomSpawner RS;
    public GameObject minionScript;
    public GameObject FinalBossPrefab;
    public Transform SpawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        disableScript();
        Instantiate(FinalBossPrefab, SpawnLocation.transform.position, Quaternion.identity);
    }

    void disableScript()
    {
        RS.kill = true;
        minionScript.GetComponent<RandomSpawner>().enabled = false; // by start this turns off this script
    }
}
