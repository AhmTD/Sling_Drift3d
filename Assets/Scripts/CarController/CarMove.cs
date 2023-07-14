using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : Movement
{

    private void Update()
    {
        Move();
    }
    protected override void Move()
    {
        transform.Translate(transform.forward * (Time.deltaTime * speed), Space.World);
    }
}
