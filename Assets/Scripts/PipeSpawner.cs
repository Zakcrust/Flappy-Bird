﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private Bird bird;
    [SerializeField] private float spawnInterval = 1;
    [SerializeField] private Pipe pipeUp,pipeDown;
    [SerializeField] Point point;
    [SerializeField] private float holeSize = 1f;
    [SerializeField] private float maxMinOffset = 1f;
    private Coroutine CR_Spawn;
    // Start is called before the first frame update
    void Start()
    {
        StartSpawn();
    }


    void StartSpawn()
    {
        if (CR_Spawn == null)
        {
            CR_Spawn = StartCoroutine(IeSpawn());
        }
    }

    void StopSpawn()
    {
        if (CR_Spawn != null)
        {
            StopCoroutine(CR_Spawn);
        }
    }

    void SpawnPipe()
    {
        Pipe newPipeUp = Instantiate(pipeUp,transform.position,Quaternion.Euler(0,0,180));
        newPipeUp.gameObject.SetActive(true);

        Pipe newPipeDown = Instantiate(pipeDown,transform.position,Quaternion.identity);
        newPipeDown.gameObject.SetActive(true);

        Point newPoint = Instantiate(point,transform.position,Quaternion.identity);
        newPoint.gameObject.SetActive(true);
        newPoint.setSize(holeSize);

        newPipeUp.transform.position += Vector3.up * (holeSize / 2);
        newPipeDown.transform.position += Vector3.down * (holeSize / 2);

        // float y = maxMinOffset * Mathf.Sin(Time.time);

        float y = maxMinOffset * Mathf.Cos(Time.time);

        newPipeUp.transform.position += Vector3.up * y;
        newPipeDown.transform.position += Vector3.up * y;
        newPoint.transform.position += Vector3.up * y;
    }
    
    IEnumerator IeSpawn()
    {
        while(true)
        {
            if(bird.IsDead())
            {
                StopSpawn();
            }

            SpawnPipe();

            randomSpawnInterval();
            
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void randomSpawnInterval()
    {
        spawnInterval = Random.Range(2.0f,4.0f);
    }

}
