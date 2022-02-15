using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class TopGenerator : MonoBehaviour
{
    private BlocksGenerator _blocksGenerator;

    public List<GameObject> hangingBlocks = new List<GameObject>();
    public List<GameObject> _cornersList = new List<GameObject>();
    public List<GameObject> _newCornerList = new();
    
    public GameObject grass;
    private GameObject cube;
    private GameObject newGrass;

    private bool _startTopGen;
    private bool _startCornersGen;
    private bool _startHanging;
    
    private bool _cornerBlocks;

    private int _corners;
    
    private Random _random = new Random();

    void Start()
    {
        _blocksGenerator = GameObject.FindGameObjectWithTag("GameController").GetComponent<BlocksGenerator>();
        cube = GameObject.FindGameObjectWithTag("Cube");
    }

    private void Update()
    {
        if (_startTopGen == false && _blocksGenerator.blocks.Count == 1000)
        {
            StartCoroutine(TopGen());
            _startTopGen = true;
        }

        if (hangingBlocks.Count == 40 && _startCornersGen == false)
        {
            CornersGen();
            _startCornersGen = true;
        }

        if (hangingBlocks.Count == 44 && !_startHanging)
        {
            Invoke("HangingGen", 1f);
            _startHanging = true;
        }
    }

    IEnumerator TopGen()
    {
        yield return new WaitForSeconds(0.1f);
        foreach (var block in _blocksGenerator.blocks)
        {
            var isTop = block.GetComponent<Block>().isTop;
            var inBox = block.GetComponent<Block>().inBox;

            var spawnF = block.transform.Find("Spawn Point Forward");
            var spawnB = block.transform.Find("Spawn Point Back");
            var spawnL = block.transform.Find("Spawn Point Left");
            var spawnR = block.transform.Find("Spawn Point Right");
            
            if (isTop && inBox)
            {
                if (spawnR.GetComponent<SpawnPoint>().isReallyFull == false &&
                    spawnF.GetComponent<SpawnPoint>().isReallyFull == false)
                {
                    newGrass = Instantiate(grass, spawnR.transform.position, Quaternion.identity);
                    spawnR.GetComponent<SpawnPoint>().isReallyFull = true;
                    newGrass.GetComponent<Block>().inBox = false;
                    hangingBlocks.Add(newGrass);
                    newGrass.name = "Hanging " + hangingBlocks.Count;
                    newGrass.transform.parent = cube.transform;
                    newGrass.GetComponent<Block>().hangingBlock = true;

                    newGrass = Instantiate(grass, spawnF.transform.position, Quaternion.identity);
                    spawnF.GetComponent<SpawnPoint>().isReallyFull = true;
                    newGrass.GetComponent<Block>().inBox = false;
                    hangingBlocks.Add(newGrass);
                    newGrass.name = "Hanging " + hangingBlocks.Count;
                    newGrass.transform.parent = cube.transform;
                    newGrass.GetComponent<Block>().hangingBlock = true;
                }
                else if (spawnL.GetComponent<SpawnPoint>().isReallyFull == false &&
                         spawnB.GetComponent<SpawnPoint>().isReallyFull == false)
                {
                    newGrass = Instantiate(grass, spawnB.transform.position, Quaternion.identity);
                    spawnB.GetComponent<SpawnPoint>().isReallyFull = true;
                    newGrass.GetComponent<Block>().inBox = false;
                    hangingBlocks.Add(newGrass);
                    newGrass.name = "Hanging " + hangingBlocks.Count;
                    newGrass.transform.parent = cube.transform;
                    newGrass.GetComponent<Block>().hangingBlock = true;

                    newGrass = Instantiate(grass, spawnL.transform.position, Quaternion.identity);
                    spawnL.GetComponent<SpawnPoint>().isReallyFull = true;
                    newGrass.GetComponent<Block>().inBox = false;
                    hangingBlocks.Add(newGrass);
                    newGrass.name = "Hanging " + hangingBlocks.Count;
                    newGrass.transform.parent = cube.transform;
                    newGrass.GetComponent<Block>().hangingBlock = true;
                }
                else if (spawnR.GetComponent<SpawnPoint>().isReallyFull == false &&
                         spawnB.GetComponent<SpawnPoint>().isReallyFull == false)
                {
                    newGrass = Instantiate(grass, spawnR.transform.position, Quaternion.identity);
                    spawnR.GetComponent<SpawnPoint>().isReallyFull = true;
                    newGrass.GetComponent<Block>().inBox = false;
                    hangingBlocks.Add(newGrass);
                    newGrass.name = "Hanging " + hangingBlocks.Count;
                    newGrass.transform.parent = cube.transform;
                    newGrass.GetComponent<Block>().hangingBlock = true;

                    newGrass = Instantiate(grass, spawnB.transform.position, Quaternion.identity);
                    spawnB.GetComponent<SpawnPoint>().isReallyFull = true;
                    newGrass.GetComponent<Block>().inBox = false;
                    hangingBlocks.Add(newGrass);
                    newGrass.name = "Hanging " + hangingBlocks.Count;
                    newGrass.transform.parent = cube.transform;
                    newGrass.GetComponent<Block>().hangingBlock = true;
                }
                else if (spawnL.GetComponent<SpawnPoint>().isReallyFull == false &&
                         spawnF.GetComponent<SpawnPoint>().isReallyFull == false)
                {
                    newGrass = Instantiate(grass, spawnL.transform.position, Quaternion.identity);
                    spawnL.GetComponent<SpawnPoint>().isReallyFull = true;
                    newGrass.GetComponent<Block>().inBox = false;
                    hangingBlocks.Add(newGrass);
                    newGrass.name = "Hanging " + hangingBlocks.Count;
                    newGrass.transform.parent = cube.transform;
                    newGrass.GetComponent<Block>().hangingBlock = true;

                    newGrass = Instantiate(grass, spawnF.transform.position, Quaternion.identity);
                    spawnF.GetComponent<SpawnPoint>().isReallyFull = true;
                    newGrass.GetComponent<Block>().inBox = false;
                    hangingBlocks.Add(newGrass);
                    newGrass.name = "Hanging " + hangingBlocks.Count;
                    newGrass.transform.parent = cube.transform;
                    newGrass.GetComponent<Block>().hangingBlock = true;
                }


                else if (spawnF.GetComponent<SpawnPoint>().isReallyFull == false)
                {
                    newGrass = Instantiate(grass, spawnF.transform.position, Quaternion.identity);

                    spawnF.GetComponent<SpawnPoint>().isReallyFull = true;
                    newGrass.GetComponent<Block>().inBox = false;

                    hangingBlocks.Add(newGrass);
                    newGrass.name = "Hanging " + hangingBlocks.Count;
                    newGrass.transform.parent = cube.transform;
                    newGrass.GetComponent<Block>().hangingBlock = true;
                }
                else if (spawnB.GetComponent<SpawnPoint>().isReallyFull == false)
                {
                    newGrass = Instantiate(grass, spawnB.transform.position, Quaternion.identity);

                    spawnB.GetComponent<SpawnPoint>().isReallyFull = true;
                    newGrass.GetComponent<Block>().inBox = false;

                    hangingBlocks.Add(newGrass);
                    newGrass.name = "Hanging " + hangingBlocks.Count;
                    newGrass.transform.parent = cube.transform;
                    newGrass.GetComponent<Block>().hangingBlock = true;
                }
                else if (spawnR.GetComponent<SpawnPoint>().isReallyFull == false)
                {
                    newGrass = Instantiate(grass, spawnR.transform.position, Quaternion.identity);

                    spawnR.GetComponent<SpawnPoint>().isReallyFull = true;
                    newGrass.GetComponent<Block>().inBox = false;

                    hangingBlocks.Add(newGrass);
                    newGrass.name = "Hanging " + hangingBlocks.Count;
                    newGrass.transform.parent = cube.transform;
                    newGrass.GetComponent<Block>().hangingBlock = true;
                }
                else if (spawnL.GetComponent<SpawnPoint>().isReallyFull == false)
                {
                    newGrass = Instantiate(grass, spawnL.transform.position, Quaternion.identity);

                    spawnL.GetComponent<SpawnPoint>().isReallyFull = true;
                    newGrass.GetComponent<Block>().inBox = false;

                    hangingBlocks.Add(newGrass);
                    newGrass.name = "Hanging " + hangingBlocks.Count;
                    newGrass.transform.parent = cube.transform;
                    newGrass.GetComponent<Block>().hangingBlock = true;
                }
            }
        }
    }

    void CornersGen()
    {
        foreach (var block in hangingBlocks)
        {
            var spawnPoints = block.GetComponent<Block>().spawns;
            if (block.GetComponent<Block>().hangingBlock)
            {
                foreach (var point in spawnPoints)
                {
                    var spawnScript = point.GetComponent<SpawnPoint>();

                    if (point.gameObject.name != "Spawn Point Down" && spawnScript.colliders == 1)
                    {
                        spawnScript.isHangingCorner = true;
                    }

                    if (spawnScript.isHangingCorner && !spawnScript.isReallyFull)
                    {
                        newGrass = Instantiate(grass, point.transform.position, Quaternion.identity);
                        _corners++;
                        spawnScript.isReallyFull = true;
                        newGrass.name = "Corner " + _corners;
                        newGrass.transform.parent = cube.transform;
                        _cornersList.Add(newGrass);
                    }
                }
            }
        }

        int removeCorners = 0;
        int newCornerName = 0;
        
        var corner1 = new Vector3(0, 0, 0);
        var corner2 = new Vector3(0, 0, 0);
        
        foreach (var corner in _cornersList)
        {
            if (removeCorners < 1)
            {
                corner1 = corner.transform.position;
                corner2 = corner1;
                removeCorners++;
                _newCornerList.Add(corner);
                corner.name = "Corner " + newCornerName;
                newCornerName++;
            }
            else
            {
                corner1 = corner.transform.position;
                if (corner1 != corner2)
                {
                    _newCornerList.Add(corner);
                    corner.name = "Corner " + newCornerName;
                    newCornerName++;
                }
                else
                {
                    Destroy(corner);
                }
        
                corner2 = corner1;
                removeCorners++;
            }
        }
        
        _cornersList.Clear();
        hangingBlocks.AddRange(_newCornerList);
            
    }

    void HangingGen()
    {
        int name = 0;
        
        foreach (var block in hangingBlocks)
        {
            
            var spawns = block.GetComponent<Block>().spawns;
            int depth = _random.Next(2, 11);
            GameObject spawnD = block.transform.Find("Spawn Point Down").gameObject;
            
            for (int i = 0; i < depth; i++)
            {
                newGrass = Instantiate(grass, spawnD.transform.position, Quaternion.identity);
                newGrass.transform.parent = cube.transform;
                name++;
                newGrass.name = "Hanging " + name;
                spawnD = newGrass.transform.Find("Spawn Point Down").gameObject;
            }
        }
    }
}
