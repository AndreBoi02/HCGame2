using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dice : MonoBehaviour
{
    Move move;
    public int diceNum;
    public int box2Move = 1;
    public int addNum = 1;
    bool moving = false;

    [SerializeField] private TMP_Text text;

    private void Start()
    {
        move = FindObjectOfType<Move>();
    }

    private void MovePlayer()
    {
        if (moving && diceNum > 0)
        {
            addNum++;
            box2Move++;
            move.Move2(box2Move);
            diceNum--;
            if (diceNum == 0)
            {
                moving = false;
                CancelInvoke("MovePlayer"); // Detiene la repetición de la función MovePlayer
            }
        }
    }

    public void Roll()
    {
        addNum = 0;
        moving = true;
        diceNum = Random.Range(1, 7);
        text.text = "" + diceNum;
        InvokeRepeating("MovePlayer", 0.5f, 0.5f); // Llama a la función MovePlayer cada 0.5 segundos
    }
}
