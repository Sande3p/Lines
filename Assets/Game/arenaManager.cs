﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class arenaManager : MonoBehaviour 
{
    public arenaBlockController[] arenaBlock;

    private arenaBlockController[,] arena;

    void Awake()
    {
        arenaBlock = new arenaBlockController[49];
        arena = new arenaBlockController[7, 7];

        for(int y = 0, i = 0; y < 7; ++y)
        {
            for(int x = 0; x < 7; ++x, ++i)
            {
                arenaBlock[i] = gameObject.transform.GetChild(i).gameObject.GetComponent<arenaBlockController>();
                arena[x,y] = gameObject.transform.GetChild(i).gameObject.GetComponent<arenaBlockController>();
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gameManager.endGame.active) gameManager.endGame.setActive(true);
        checkArenaHorizontal();
        checkArenaVertical();
    }

    private void checkArenaHorizontal()
    {
        for(int y = 0; y < 7; ++y)
        {
            for (int x = 1, i = 1; x < 8; ++x)
            {
                if (x < 7 && arena[x - 1, y].block != null && arena[x, y].block != null && (arena[x - 1, y].block.color == arena[x, y].block.color)) //If blocks match
                {
                    if (arena[x - 1, y].block.onPosition && arena[x, y].block.onPosition && !arena[x - 1, y].block.toDestroy && !arena[x, y].block.toDestroy) ++i;
                }
                else //If blocs are different
                {
                    if(i >= 3)
                    {
                        gameManager.addPoints(10 + ((i % 3) + 1) * 5);
                        for (int w = i; w > 0; --w) gameManager.block.destroyBlock(arena[x - w, y].block);
                    }
                    i = 1;
                }
            }
        }
    }

    private void checkArenaVertical()
    {
        for(int x = 0; x < 7; ++x)
        {
            for(int y = 1, i = 1; y < 8; ++y)
            {
                if (y < 7 && arena[x, y - 1].block != null && arena[x, y].block != null && (arena[x, y - 1].block.color == arena[x, y].block.color)) //If blocks match
                {
                    if (arena[x, y - 1].block.onPosition && arena[x, y].block.onPosition && !arena[x, y - 1].block.toDestroy && !arena[x, y].block.toDestroy) ++i;
                }
                else //If blocs are different
                {
                    if (i >= 3)
                    {
                        gameManager.addPoints(10 + ((i % 3) + 1) * 5);
                        for (int w = i; w > 0; --w) gameManager.block.destroyBlock(arena[x, y - w].block);
                    }
                    i = 1;
                }
            }
        }
    }
}