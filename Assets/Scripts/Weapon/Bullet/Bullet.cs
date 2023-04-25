using System;
using UnityEngine;

namespace Weapon.Bullet
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;
        [SerializeField] private float damage = 10f;

        private Vector3 _direction;
        public float Damage => damage;

        public void Init(Vector3 target)
        {
            _direction = new Vector3(target.x, transform.position.y, target.z);
        }

        private void Update()
        {
            transform.Translate(_direction * (speed * Time.deltaTime));
        }

        private void OnCollisionEnter(Collision other)
        {
            //if(other.gameObject.GetComponent<Player.Player>())
            gameObject.SetActive(false);
        }
    }
}
   
