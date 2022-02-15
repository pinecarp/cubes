using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject grass;
    private GameObject newGrass;
    public GameObject parentBlock;
    
    public bool isFull;
    public bool isReallyFull;
    public bool isHangingCorner;

    private BlocksGenerator _blocksGenerator;
    private TopGenerator _topGenerator;
    private Block block;

    public int colliders = 0;
    
    private void Start()
    {
        _blocksGenerator = GameObject.FindGameObjectWithTag("GameController").GetComponent<BlocksGenerator>();
        _topGenerator = GameObject.FindGameObjectWithTag("GameController").GetComponent<TopGenerator>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        colliders++;
        if (collider != null)
        {
            block = collider.GetComponent<Block>();
            if (block != null)
            {
                isReallyFull = true;
                block.nearestBlocks++;
            }
        }
    }
}
