using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    private readonly string Horizontal = "Horizontal";
    private readonly string Jump = "Jump";
    private readonly string Vertical = "Vertical";
    private readonly string MouseX = "Mouse X";
    private readonly string MouseY = "Mouse Y";
    
    [SerializeField] private float _speed;
    [SerializeField] private float _mouseSensiviti;
    [SerializeField] private Camera _camera;
    
    private float rotationXCamera;
    private float minRotatinCamer;
    private float maxRotatinCamer;
    private float rotationYPlayer;
    
    private void Start()
    {
        rotationXCamera = 0f;
        minRotatinCamer = -60f;
        maxRotatinCamer = 60f;
        rotationYPlayer = 0f;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    private void Update()
    {
        Move();
        MoveCamera();

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            
            if (Physics.Raycast(transform.position, transform.forward, out hit, 1.5f))
            {
                Door door = hit.collider.GetComponent<Door>();
                
                if (door != null)
                    door.OpenCloseDoor();
            }
        }
    }

    private void MoveCamera()
    {
        float mouseX = Input.GetAxis(MouseX) * _mouseSensiviti * Time.deltaTime;
        float mouseY = Input.GetAxis(MouseY) * _mouseSensiviti * Time.deltaTime;
        
        rotationYPlayer += mouseX;
        rotationXCamera -= mouseY;
        rotationXCamera = Mathf.Clamp(rotationXCamera, minRotatinCamer, maxRotatinCamer);
        
        transform.localRotation = Quaternion.Euler(0f, rotationYPlayer, 0f);
        _camera.transform.localRotation = Quaternion.Euler(rotationXCamera, 0f, 0f);
    }
    
    private void Move()
    {
        float directionX = Input.GetAxis(Horizontal);
        float directionY = Input.GetAxis(Jump);
        float directionZ = Input.GetAxis(Vertical);
        
        if (directionX != 0f || directionY != 0f || directionZ != 0f)
        {
            Vector3 direction = new Vector3(directionX, directionY, directionZ); 
            transform.Translate(Time.deltaTime * _speed * direction);
        }
    }
}
