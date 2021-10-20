using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 MousePosition;
    Vector3 Direction;

    public float Speed = 10f;

    Rigidbody2D _Rigidbody;

    private void Start()
    {
        _Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //transform.Translate(Vector3.up * Speed * Time.deltaTime);
        _Rigidbody.velocity = new Vector2(_Rigidbody.velocity.y, Speed);
        if (Input.GetMouseButton(0))
        {
            MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Direction = (MousePosition - transform.position).normalized;
            _Rigidbody.velocity = new Vector2(Direction.x * Speed, _Rigidbody.velocity.y);
        }
        else
            _Rigidbody.velocity = new Vector2(0, Speed);
    }
}
