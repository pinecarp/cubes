using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private BlocksGenerator _blocksGenerator;

    private Transform spawnU;
    private Transform spawnD;
    private Transform spawnR;
    private Transform spawnL;
    private Transform spawnF;
    private Transform spawnB;
    
    public List<Transform> spawns = new List<Transform>();

    public bool isTop;


    private void Start()
    {
        _blocksGenerator = GameObject.FindGameObjectWithTag("GameController").GetComponent<BlocksGenerator>();
        
        spawnU = transform.Find("Spawn Point Up");
        spawnD = transform.Find("Spawn Point Down");
        spawnR = transform.Find("Spawn Point Right");
        spawnL = transform.Find("Spawn Point Left");
        spawnF = transform.Find("Spawn Point Forward");
        spawnB = transform.Find("Spawn Point Back");
        
        spawns.Add(spawnU);
        spawns.Add(spawnD);
        spawns.Add(spawnR);
        spawns.Add(spawnL);
        spawns.Add(spawnF);
        spawns.Add(spawnB);
    }

    private void Update()
    {
        for (int i = 0; i < spawns.Count; i++)
        {

        }
    }
}
