using UnityEngine;

namespace Weapon
{
    public class Weapon : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public Transform firePoint;
        public float fireRate = 0.5f;
        private float nextFireTime;

       private void Update()
        {
            if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
            {
                nextFireTime = Time.time + fireRate;
                Shoot();
            }
        }

       public void Shoot()
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Bullet.Bullet bulletComponent = bullet.GetComponent<Bullet.Bullet>();
        }
    }
}