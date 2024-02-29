using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Boxes boxes;
    [SerializeField] private float speed;
    private Vector2 dir;
    public bool destinyReach = false;
    private int targetBox;

    private void Start()
    {
        boxes = FindObjectOfType<Boxes>();
    }

    private void Update()
    {
        if (!destinyReach && Vector2.Distance(transform.position, boxes.boxTestList[targetBox].transform.position) > 0.1f)
        {
            dir = (boxes.boxTestList[targetBox].transform.position - transform.position).normalized;
            transform.Translate(dir * speed * Time.deltaTime);
        }
        else
        {
            destinyReach = true;
            if (targetBox == boxes.boxTestList.Count - 1) // Si el jugador ha llegado a la última casilla
            {
                boxes.NextLevel(); // Avanza al siguiente nivel
            }
        }
    }

    public void Move2(int i)
    {
        destinyReach = false;
        if (i > boxes.boxTestList.Count - 1)
        {
            return;
        }
        targetBox = i;
    }

    public void MoveToStart(Vector2 startPos)
    {
        transform.position = startPos; // Mueve al jugador a la posición de inicio
    }
}
