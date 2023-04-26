using System;
using UI.HealthBar;
using Unity.VisualScripting;
using UnityEngine;
using Weapon.Bullet;
using Zenject;

namespace Player
{
    public class Player : MonoBehaviour

    {
        [SerializeField] private float _healthOnStart = 100f;


        [Header("Settings rotate")] 
        [SerializeField] private float minRotateY = -60f;
        [SerializeField] private float maxRotateY = 60f;
        [SerializeField] private float _rotationSpeed = 3f;
        [SerializeField] private float _smoothTime = 0.1f;
        private Camera _camera;
        private float _mouseX;
        private float _mouseY;
        private float _currentRotationX;
        private float _currentRotationY;
        private float _velocityX;
        private float _velocityY;
        
        [Header("Settings move")]
        [SerializeField] private float _forwardSpeed = 0f;
        private CharacterController _character;
        private Vector3 _moveDirection = Vector3.zero;
        
        
        
        
        private Weapon.Weapon _weapon;
        private Health _health;
        

        private void Awake()
        {
            _camera = Camera.main;
            
            _character = GetComponent<CharacterController>();
            _weapon = GetComponentInChildren<Weapon.Weapon>();
            _health = FindObjectOfType<Health>();
        }

        private void Start()
        {
         //   _health.Init(_healthOnStart);
        }

        private void Update()
        {
            
            Rotation();
            Move();
            
            if (Input.GetMouseButtonDown(0))
            {
                _weapon.Shoot();
            }
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out Bullet bullet)) 
            {
                TakeDamage(bullet.Damage);
            }
        }
        

        private void Rotation()
        {
            _mouseX += Input.GetAxis("Mouse X") * _rotationSpeed;
            _mouseY += Input.GetAxis("Mouse Y") * _rotationSpeed;

            _mouseY = Mathf.Clamp(_mouseY, minRotateY,maxRotateY);

            _currentRotationX = Mathf.SmoothDamp(_currentRotationX, _mouseX , ref _velocityX, _smoothTime);
            _currentRotationY = Mathf.SmoothDamp(_currentRotationY, _mouseY , ref _velocityY, _smoothTime);
           
             
            _camera.transform.rotation = Quaternion.Euler(-_currentRotationY, _currentRotationX, 0);
            transform.rotation = Quaternion.Euler(0, _currentRotationX, 0);
        }
        
        private void Move()
        {
            var moveHorizontalX = Input.GetAxis("Horizontal");
            var moveVerticalZ = Input.GetAxis("Vertical");
            
            _moveDirection = new Vector3(moveHorizontalX, 0, moveVerticalZ);
            _moveDirection = transform.TransformDirection(_moveDirection);
            
            _character.Move(_moveDirection * (_forwardSpeed * Time.deltaTime));
        }

        private void TakeDamage(float damage)
        {
            _healthOnStart -= damage;
            _health.ShowHealth(_healthOnStart).Forget();
        }
    }
}