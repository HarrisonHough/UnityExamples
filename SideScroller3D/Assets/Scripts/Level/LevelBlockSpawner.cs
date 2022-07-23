using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: Level Block Spawner Class 
*/

public class LevelBlockSpawner : MonoBehaviour {

    public int numberOfLevelBlocks = 10;
    public LevelBlock[] levelBlocks;
    private GameObject attachPoint;

	// Use this for initialization
	void Start () {

        if (attachPoint == null)
            attachPoint = FindObjectOfType<AttachPoint>().gameObject;

        SpawnLevelBlocks(numberOfLevelBlocks);
    }

    void SpawnLevelBlocks(int numberToSpawn)
    {
        for (int i = 0; i < numberToSpawn; i++)
        {
                SpawnLevelBlock();
        }
    }

    void SpawnLevelBlock()
    {
        if (attachPoint == null) return;

        GameObject block = Instantiate(levelBlocks[Random.Range(0, levelBlocks.Length)].gameObject, attachPoint.transform.position, attachPoint.transform.rotation) as GameObject;
        attachPoint = block.GetComponent<LevelBlock>().GetAttachPoint().gameObject;
    }
}
