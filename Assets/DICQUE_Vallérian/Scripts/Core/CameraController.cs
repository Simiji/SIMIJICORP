using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _smoothTime = 0.3f;
    [SerializeField] private Vector3 _offset;

    [SerializeField] private Transform _offsetRoot;
    [SerializeField] private Transform _xRoot;
    [SerializeField] private Transform _yRoot;
    [SerializeField] private Transform _zRoot;
    [SerializeField] private Camera _cam;


    private Vector3 _velocity = Vector3.zero;

    #region Singleton
    public static CameraController Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    private void LateUpdate()
    {
        if (_target)
        {
            _offsetRoot.localPosition = _offset;
            transform.position = Vector3.SmoothDamp(transform.position, _target.position, ref _velocity, _smoothTime);
        }
    }
}
