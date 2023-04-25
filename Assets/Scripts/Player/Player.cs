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
        [SerializeField] private float _rotationSpeed = 0f;

        private Weapon.Weapon _weapon;
        private Health _health;
       

        private void Awake()
        {
            _weapon = GetComponentInChildren<Weapon.Weapon>();
            _health = FindObjectOfType<Health>();
        }

        private void Start()
        {
            _health.Init(_healthOnStart);
        }

        private void Update()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            // float Rotation = Input.GetAxis("Rotation");

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