using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchVictoryScreen : MonoBehaviour
{
    float timer = 5;
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(waiter());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(timer);
        SceneManager.LoadScene("VictoryScreen");
    }
}
