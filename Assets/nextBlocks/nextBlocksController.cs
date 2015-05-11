﻿using UnityEngine;
using System.Collections;

public class nextBlocksController : MonoBehaviour 
{
    public blockManager managerBlock;

    int[] colorIndex;
    GameObject[] block;
    blockManager.color[] col;

	void Start () 
    {
        block = new GameObject[4];
        col = new blockManager.color[4];
        colorIndex = new int[4];

        for (int i = 0; i < 4; ++i) block[i] = gameObject.transform.GetChild(i).gameObject;

        randNewColor();
	}

    void randNewColor()
    {
        for(int i = 0; i < 4; ++i)
        {
            colorIndex[i] = Random.Range(1, 4);

            switch(colorIndex[i])
            {
                case 1:
                    col[i] = blockManager.color.red;
                    block[i].GetComponent<MeshRenderer>().material.color = Color.red;
                    break;
                case 2:
                    col[i] = blockManager.color.green;
                    block[i].GetComponent<MeshRenderer>().material.color = Color.green;
                    break;
                case 3:
                    col[i] = blockManager.color.blue;
                    block[i].GetComponent<MeshRenderer>().material.color = Color.blue;
                    break;
            }
        }
    }

    public void push()
    {
        for (int i = 0; i < 5; ++i)
        {
            if (i < 4) managerBlock.createNewBlock(col[i]);
            else randNewColor();
        }
    }
	
	void Update () 
    {
        if (managerBlock.blockCount() < 4) push();

        // [[   TEST    ]]  -- rand new colors
        if (Input.GetKeyDown(KeyCode.S)) randNewColor();

        // [[   TEST    ]]  --  Create new blocks
        if (Input.GetKeyDown(KeyCode.A)) push();
	}
}
