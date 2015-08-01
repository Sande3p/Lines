﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class debugMenuController : MonoBehaviour 
{
    public bool active;
    public int pointsChange;
    public int blocksChange;

    private Text addPoints;
    private Text subtractPoints;
    private Text removeBlocks;

    void Awake()
    {
        if (pointsChange <= 0 || blocksChange <= 0) Debug.LogError("Debug menu - to small pointsChange/blocksChange value.");
        else
        {
            addPoints = gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
            subtractPoints = gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
            removeBlocks = gameObject.transform.GetChild(7).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();

            addPoints.text = "Add " + pointsChange.ToString() + " points";
            subtractPoints.text = "Subtract " + pointsChange.ToString() + " points";
            removeBlocks.text = "Remove " + blocksChange.ToString() + " blocks";
        }
    }

    public void setActive(bool status)
    {
        active = status;
        gameObject.SetActive(status);
    }

    public void button_addPoints()
    {
        Debug.LogWarning("Debug menu - add " + pointsChange.ToString() + " points.");
        arenaManager.points += pointsChange;
        arenaManager.updatePoints();
    }

    public void button_subtractPoints()
    {
        Debug.LogWarning("Debug menu - subtract " + pointsChange.ToString() + " points.");
        arenaManager.points -= pointsChange;
        arenaManager.updatePoints();
    }

    public void button_resetPoints()
    {
        Debug.LogWarning("Debug menu - reset points.");
        arenaManager.points = 0;
        arenaManager.updatePoints();
    }

    public void button_randColors()
    {
        Debug.LogWarning("Debug menu - rand new colors.");
        Manager.nextBlocks.randNewColors();
    }

    public void button_pushBlocks()
    {
        Debug.LogWarning("Debug menu - push new blocks.");
        Manager.blocks.blocksToCreate = 5;
        setActive(false);
    }

    public void button_removeOneBlock()
    {
        Debug.LogWarning("Debug menu - remove 1 block.");
        Manager.blocks.destroyBlock(1);
        setActive(false);
    }

    public void button_removeBlocksValue()
    {
        Debug.LogWarning("Debug menu - remove " + blocksChange.ToString() + " blocks.");
        Manager.blocks.destroyBlock(blocksChange);
        setActive(false);
    }

    public void button_removeAllBlocks()
    {
        Debug.LogWarning("Debug menu - remove all block.");
        Manager.blocks.destroyAllBlocks();
        setActive(false);
    }

    public void button_deletePlayerprefs()
    {
        Debug.LogWarning("Debug menu - delete playerprefs.");
        PlayerPrefs.DeleteAll();
    }

    public void button_closeDebug()
    {
        Debug.LogWarning("Debug menu - close debug menu.");
        setActive(false);
    }
}
