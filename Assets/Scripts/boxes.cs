using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct BoxeData
{
    public Transform Position;
    public int BoxNum;
    public int SpecialBox;
    public Sprite BoxSprite;

    public BoxeData(Transform pos, int boxNum, int specialBox, Sprite boxSprite)
    {
        Position = pos;
        BoxNum = boxNum;
        SpecialBox = specialBox;
        BoxSprite = boxSprite;
    }
}

public class Boxes : MonoBehaviour
{
    List<BoxeData> boxes = new List<BoxeData>();

    public int lvl = 1;

    float sizeX;
    float sizeY;
    (float, float) rangeX = (3,10);
    (float, float) rangeY = (3,10);

    public void Start()
    {
        generateBoxes();
    }

    private void Update()
    {
        
    }

    void generateBoxes()
    {
        setDifficulty();
        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeY; j++)
            {

            }
        }
    }

    void setDifficulty()
    {
        if (lvl % 5 == 0 && rangeX.Item1 <= 10 && rangeY.Item1 <= 10)
        {
            rangeX.Item1++;
            rangeY.Item1++;
        }

        sizeX = Random.Range(rangeX.Item1, rangeX.Item2+1);
        sizeY = Random.Range(rangeY.Item1, rangeY.Item2+1);
    }
}
