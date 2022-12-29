using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EntityMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    public void Move(Vector2 direction, float speed)
    {
        Vector3 movement = new Vector3(direction.x, 0, direction.y);
        _rigidbody.velocity = movement * speed;
    }
}
