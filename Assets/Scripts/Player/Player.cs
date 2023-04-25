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
        [SerializeField] private float _forwardSpeed = 0f;
        [SerializeField] private float _rotationSpeed = 3f;
        [SerializeField] private Camera camera;
        

        private Weapon.Weapon _weapon;
        private Health _health;
        

        private void Awake()
        {
            _weapon = GetComponentInChildren<Weapon.Weapon>();
            _health = FindObjectOfType<Health>();
        }

        private void Start()
        {
         //   _health.Init(_healthOnStart);
        }

        private void Update()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            // float Rotation = Input.GetAxis("Rotation");

            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            
            transform.Rotate(0, mouseX * _rotationSpeed, 0);

            float currentPotationX = camera.transform.rotation.eulerAngles.x;
            float newRotationX = currentPotationX - mouseY * _rotationSpeed;
            newRotationX = Mathf.Clamp(newRotationX, -90, 90);
            camera.transform.rotation = Quaternion.Euler(newRotationX, 0, 0);
            
            Vector3 moveDirection = new Vector3(moveHorizontal, 0.0f, moveVertical);
            Vector3 newPosition = transform.position + moveDirection * _forwardSpeed * Time.deltaTime;
            // Quaternion newRotation = Quaternion.Euler(0, Rotation * _rotationSpeed * Time.deltaTime, 0); 
            

            //transform.rotation *= newRotation;
            transform.position = newPosition;


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

        private void TakeDamage(float damage)
        {
            _healthOnStart -= damage;
            _health.ShowHealth(_healthOnStart).Forget();
        }
    }
}