using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BlocksGenerator : MonoBehaviour
{
    public List<GameObject> blocks = new List<GameObject>();
    public GameObject cube;
    public GameObject grass;
    private GameObject _firstBlock;
    private GameObject _newBlock;
    private GameObject _spawnBlock;
    private GameObject _firstSpawn;

    public Transform spawnR;
    public Transform spawnL;
    public Transform spawnU;

    private SpawnPoint _spawnPoint;

    private int _blocksNumber;
    private int _linesNumber;

    private void Start()
    {
        _blocksNumber = 0;
        _linesNumber = 0;
        
        _firstSpawn = GameObject.FindGameObjectWithTag("SpawnPoint");
    }

    private void Update()
    {
        if (_firstSpawn.GetComponent<SpawnPoint>().isFull == false)
        {            
            _firstSpawn.GetComponent<SpawnPoint>().isFull = true;
            _newBlock = Instantiate(grass, _firstSpawn.transform.position, Quaternion.identity);
            _newBlock.name = "Grass" + _blocksNumber;
            spawnL = _newBlock.transform.Find("Spawn Point Left");

            _blocksNumber++;
            
            blocks.Add(_newBlock);
            _newBlock.transform.parent = cube.transform;
            
            _firstBlock = _newBlock;
            _spawnBlock = _newBlock;
        }
        
        else
        {
                if (_linesNumber < 100)
                {
                    if (spawnL.GetComponent<SpawnPoint>().isFull == false && blocks.Count % 10 != 0)
                    {
                    
                        spawnL.GetComponent<SpawnPoint>().isFull = true;
                        _newBlock = Instantiate(grass, spawnL.transform.position, Quaternion.identity);
                        spawnL = _newBlock.transform.Find("Spawn Point Left");
                        _newBlock.name = "Grass " + _blocksNumber;
        
                        _blocksNumber++;
                    
                        blocks.Add(_newBlock);
                        _newBlock.transform.parent = cube.transform;
                    }
                }
                
                if (blocks.Count % 10 == 0 && blocks.Count % 100 != 0)
                {
                    spawnL.GetComponent<SpawnPoint>().isFull = true;
                    _firstBlock = Instantiate(grass, _firstBlock.transform.Find("Spawn Point Right").transform.position, Quaternion.identity);
                    spawnL = _firstBlock.transform.Find("Spawn Point Left");
                    _firstBlock.name = "Grass " + _blocksNumber;

                    _linesNumber++;
                    _blocksNumber++;
                    
                    blocks.Add(_firstBlock);
                    _firstBlock.transform.parent = cube.transform;
                }

                if (blocks.Count % 100 == 0 & blocks.Count < 999)
                {
                    _newBlock.transform.Find("Spawn Point Right").GetComponent<SpawnPoint>().isFull = true;
                    spawnU = _spawnBlock.transform.Find("Spawn Point Up");

                    _newBlock = Instantiate(grass, spawnU.transform.position, Quaternion.identity);
                    _newBlock.name = "Grass " + _blocksNumber;
                    spawnL = _newBlock.transform.Find("Spawn Point Left");

                    _firstBlock = _newBlock;
                    _spawnBlock = _newBlock;
                    
                    _newBlock.transform.parent = cube.transform;
                    blocks.Add(_firstBlock);
                    
                    _blocksNumber++;
                }
        }
    }
}
