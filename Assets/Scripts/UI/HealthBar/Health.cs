using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Weapon.Bullet;

namespace UI.HealthBar
{
    public class Health : MonoBehaviour

    {
        [FormerlySerializedAs("_bulet")] public Bullet _bullet;
        private float _currentValueHealth;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out _bullet))
            {
                TakeDamage(5);
                Destroy(other.GameObject());
            }
        }

        public void TakeDamage(int damage)
        {
            _currentValueHealth -= damage;

            if (_currentValueHealth < 0)
            {
                _currentValueHealth = 0;
                //Fail;
            }
        }

        //private void fail()
       // {
        //    
       // }
       
       
    }
    
}