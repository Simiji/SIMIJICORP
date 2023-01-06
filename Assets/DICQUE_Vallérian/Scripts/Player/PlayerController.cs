using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInputs), typeof(EntityMovement))]
public class PlayerController : MonoBehaviour
{
    private PlayerInputs _playerInputs;
    private EntityMovement _entityMovement;

    private void Start()
    {
        _playerInputs = GetComponent<PlayerInputs>();
        _entityMovement = GetComponent<EntityMovement>();
    }

    void Update()
    {
        Move();
    }
    private void Move()
    {
        Vector2 direction = _playerInputs.Inputs;

        _entityMovement.Move(direction, 5f);
    }
}
