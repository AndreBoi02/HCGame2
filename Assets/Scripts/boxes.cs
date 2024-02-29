using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct BoxeData
{
    public Transform Position;
    //This is the unique number every box has when is first generated
    public int BoxNum;
    //if special box is 1 then the box is a snake and if the sepcial box is 0 then is a ladder
    public int SpecialBox;
    //if the box is a special one then you will have to save into where does it goes
    public int Destination;
    public Sprite BoxSprite;

    public BoxeData(Transform pos, int boxNum, int specialBox, int destination ,Sprite boxSprite)
    {
        Position = pos;
        BoxNum = boxNum;
        SpecialBox = specialBox;
        Destination = destination;
        BoxSprite = boxSprite;
    }
}

public class Boxes : MonoBehaviour
{
    List<BoxeData> boxes = new List<BoxeData>();
    [SerializeField] private ObjectPooling objectPooling;
    [SerializeField] private Move move;
    [SerializeField] private Transform spawn;
    public List<GameObject> boxTestList;

    List<int> ladderPositions = new List<int>();
    List<int> snakePositions = new List<int>();

    private int lvl = 1;

    [SerializeField] private float sizeX;
    [SerializeField] private float sizeY;
    [SerializeField] private (float, float) rangeX = (5,10);
    [SerializeField] private (float, float) rangeY = (3,5);

    private void Awake()
    {
        boxTestList = new List<GameObject>();
    }

    public void Start()
    {
        generateBoxes();
        objectPooling = gameObject.GetComponent<ObjectPooling>();
        move = FindObjectOfType<Move>();
    }

    void generateBoxes()
    {
        int boxPos = 0;
        int dir = 1;
        setDifficulty();
        
        for (int i = 0; i < sizeY; i++)
        {
            for (int j = 0; j < sizeX; j++)
            {
                GameObject boxTest = objectPooling.RequestObject();
                boxTestList.Add(boxTest);
                boxTestList[boxPos].transform.position = new Vector2 (spawn.transform.position.x + (j*dir), 
                                                                      spawn.transform.position.y + i);
                boxPos++;
            }
            dir *= -1;
            if (dir > 0)
            {
                spawn.transform.position = new Vector2(-4.5f, spawn.transform.position.y);
            }
            else
            {
                spawn.transform.position = new Vector2(boxTestList[boxTestList.Count - 1].transform.position.x,
                                                       spawn.transform.position.y);
            }
        }
    }

    void turnOffBoxes()
    {
        for (int i = 0; i < boxTestList.Count - 1; i++)
        {
            objectPooling.DespawnObject(boxTestList[i]);
        }
        
    }

    void generateLadders()
    {
        
    }

    void generateSnakes()
    {
        
    }

    void setDifficulty()
    {
        if (lvl % 5 == 0 && rangeX.Item1 <= 10 && rangeY.Item1 <= 10)
        {
            rangeX.Item1++;
            rangeX.Item2++;
            rangeY.Item1++;
            rangeY.Item2++;
        }

        //sizeX = Random.Range(rangeX.Item1, rangeX.Item2+1);
        //sizeX = Mathf.Round(sizeX);
        //sizeY = Random.Range(rangeY.Item1, rangeY.Item2+1);
        //sizeY = Mathf.Round(sizeY);
    }

    public void NextLevel()
    {
        lvl++; // Incrementa el nivel
        turnOffBoxes();
        boxTestList.Clear(); // Limpia la lista de casillas
        generateBoxes(); // Genera un nuevo mapa
        move.MoveToStart(boxTestList[0].transform.position); // Mueve al jugador a la primera casilla
    }
}
