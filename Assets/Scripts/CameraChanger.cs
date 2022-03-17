using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    [SerializeField] private List<CinemachineVirtualCamera> _virtualCameras;
    private CinemachineVirtualCamera _currentCamera => _virtualCameras[_index];
    private Camera _camera;
    private int _index;

    private void Start() => _camera = Camera.main;

    public void ChangeCamera(int cameraIndex)
    {
        _currentCamera.Priority = 0;
        _index = cameraIndex;
        _currentCamera.Priority = 10;
    }
}