using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float count;
    [SerializeField] private float counter;
    [SerializeField] private float dir;
    void Update()
    {
        count += Time.deltaTime;
        if (count >= counter)
        {
            dir *= -1;
            count = 0;
        }

        Move2(dir);
    }

    void Move2(float mult)
    {
        transform.Translate(Vector2.right * (speed * mult) * Time.deltaTime);

        //else if (transform.position.x > Screen.width)
        //{
        //    transform.position = new Vector2(transform.position.x - speed, transform.position.y) * Time.deltaTime;
        //}
    }
}
