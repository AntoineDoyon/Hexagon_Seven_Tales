using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Move : MonoBehaviour
{

    #region Variables
    public static float m_ScrollSpeed = 80.0f;
    public static float m_RotateSpeed = 100.0f;
    public static float RotateAmound = 10.0f;
    [Range(0,100)]
    public float m_MinCameraHeight = 10.0f;

    public static int m_ScrollWidth = 10;

    public static float m_MaxCameraHeight = 40.0f;

    Camera m_Camera;
    #endregion

    private void Start()
    {
        m_Camera = GetComponent<Camera>();
    }

    private void Update()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        float _xMousePos = Input.mousePosition.x;
        float _yMousePos = Input.mousePosition.y;

        Vector3 _movement = new Vector3(0f, 0f, 0f);

        //horizontal movement 
        if (_xMousePos >= 0 && _xMousePos < m_ScrollWidth)
        {
            _movement.x -= m_ScrollSpeed;
        }
        else if (_xMousePos <= Screen.width && _xMousePos > Screen.width - m_ScrollWidth)
        {
            _movement.x += m_ScrollSpeed;
        }

        //vertical movement
        if (_yMousePos >= 0 && _yMousePos < m_ScrollWidth)
        {
            _movement.z -= m_ScrollSpeed;
        }
        else if (_yMousePos <= Screen.height && _yMousePos > Screen.height - m_ScrollWidth)
        {
            _movement.z += m_ScrollSpeed;
        }

        _movement = Camera.main.transform.TransformDirection(_movement);
        _movement.y = 0;


        //calculate camera position based on input
        Vector3 _origin = Camera.main.transform.position;
        Vector3 _destination = _origin;

        _destination += _movement;

        //limit away from ground movement to be between a minimum and max distance
        /*
        if (_destination.y > m_MaxCameraHeight)
        {
            _destination.y = m_MaxCameraHeight;
        }
        else if (_destination.y < m_MinCameraHeight)
        {
            _destination.y = m_MinCameraHeight;
        }
        */

        //update the camera position
        if (_destination != _origin)
        {
            Camera.main.transform.position = Vector3.MoveTowards(_origin, _destination, Time.deltaTime * m_ScrollSpeed);
            
        }
    }
}
