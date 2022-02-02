using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class BlocksGenerator : MonoBehaviour
{
    public List<GameObject> blocks = new List<GameObject>();
    public GameObject cube;
    public GameObject grass;
    public GameObject stone;
    private GameObject _firstBlock;
    private GameObject _newBlock;
    private GameObject _spawnBlock;
    private GameObject _firstSpawn;


    public Transform spawnR;
    public Transform spawnF;
    public Transform spawnU;

    private SpawnPoint _spawnPoint;

    private int _blocksNumber;
    private int _linesNumber;
    private int random;

    private Random rand = new Random();

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
            random = rand.Next(1, 10);
            
            _firstSpawn.GetComponent<SpawnPoint>().isFull = true;
            
            if (random > 8)
                _newBlock = Instantiate(grass, _firstSpawn.transform.position, Quaternion.identity);
            else
            {
                _newBlock = Instantiate(stone, _firstSpawn.transform.position, Quaternion.identity);
            }
            
            _newBlock.name = "Block " + _blocksNumber;
            spawnF = _newBlock.transform.Find("Spawn Point Forward");

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
                    if (spawnF.GetComponent<SpawnPoint>().isFull == false && blocks.Count % 10 != 0)
                    {
                        random = rand.Next(1, 10);
                        spawnF.GetComponent<SpawnPoint>().isFull = true;

                        if ((_newBlock.CompareTag("Stone") && random < 5) || (blocks.Count < 200 && random < 9) || ((blocks.Count >= 200 && blocks.Count < 500) && random < 7) || ((blocks.Count >= 500 && blocks.Count < 700) && random < 6) || ((blocks.Count >= 700 && blocks.Count < 900) && random < 5))
                        {
                            _newBlock = Instantiate(stone, spawnF.transform.position, Quaternion.identity);
                        }
                        else
                        {
                            _newBlock = Instantiate(grass, spawnF.transform.position, Quaternion.identity);
                        }
                        
                        spawnF = _newBlock.transform.Find("Spawn Point Forward");
                        _newBlock.name = "Grass " + _blocksNumber;
        
                        _blocksNumber++;
                    
                        blocks.Add(_newBlock);
                        _newBlock.transform.parent = cube.transform;
                    }
                }
                
                if (blocks.Count % 10 == 0 && blocks.Count % 100 != 0)
                {
                    spawnF.GetComponent<SpawnPoint>().isFull = true;

                    if ((blocks.Count < 200 && random < 9) || ((blocks.Count >= 200 && blocks.Count < 500) && random < 7) || ((blocks.Count >= 500 && blocks.Count < 700) && random < 6) || ((blocks.Count >= 700 && blocks.Count < 900) && random < 5))
                    {
                        _firstBlock = Instantiate(stone, _firstBlock.transform.Find("Spawn Point Right").transform.position, Quaternion.identity);
                    }
                    else
                    {
                        _firstBlock = Instantiate(grass, _firstBlock.transform.Find("Spawn Point Right").transform.position, Quaternion.identity);
                    }
                    
                    spawnF = _firstBlock.transform.Find("Spawn Point Forward");
                    _firstBlock.name = "Grass " + _blocksNumber;

                    _linesNumber++;
                    _blocksNumber++;
                    
                    blocks.Add(_firstBlock);
                    _firstBlock.transform.parent = cube.transform;
                }

                if (blocks.Count % 100 == 0 && blocks.Count < 999)
                {
                    _newBlock.transform.Find("Spawn Point Right").GetComponent<SpawnPoint>().isFull = true;
                    spawnU = _spawnBlock.transform.Find("Spawn Point Up");
                    
                    if ((blocks.Count < 200 && random < 9) || ((blocks.Count >= 200 && blocks.Count < 500) && random < 7) || ((blocks.Count >= 500 && blocks.Count < 700) && random < 6) || ((blocks.Count >= 700 && blocks.Count < 900) && random < 5))
                    {
                        _newBlock = Instantiate(stone, spawnU.transform.position, Quaternion.identity);
                    }
                    else
                    {
                        _newBlock = Instantiate(grass, spawnU.transform.position, Quaternion.identity);
                    }

                    _newBlock.name = "Grass " + _blocksNumber;
                    spawnF = _newBlock.transform.Find("Spawn Point Forward");

                    _firstBlock = _newBlock;
                    _spawnBlock = _newBlock;
                    _blocksNumber++;
                    
                    blocks.Add(_firstBlock);
                    _newBlock.transform.parent = cube.transform;
                }
        }
        
        
        if (blocks.Count >= 900)
        {
            _newBlock.GetComponent<Block>().isTop = true;
            _firstBlock.GetComponent<Block>().isTop = true;
            _spawnBlock.GetComponent<Block>().isTop = true;
        }
    }
}
