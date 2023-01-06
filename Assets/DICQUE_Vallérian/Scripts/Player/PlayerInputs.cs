using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    public Vector2 Inputs => _inputs;
    private Vector2 _inputs;

    private void Update()
    {
        GetInputs();
    }

    private void GetInputs()
    {
        float xx = Input.GetAxisRaw("Horizontal");
        float yy = Input.GetAxisRaw("Vertical");
        _inputs = new Vector2(xx, yy);
    }
}