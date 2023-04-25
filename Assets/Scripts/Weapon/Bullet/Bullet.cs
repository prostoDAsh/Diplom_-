using UnityEngine;

namespace Weapon.Bullet
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] public float speed = 10f;
        [SerializeField] public float lifetime = 2f;

        void Start()
        {
            Destroy(gameObject, lifetime);
        }

        void Update()
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Enemy.Enemy>() != null)
            {
                Destroy(gameObject);
                other.GetComponent<Enemy.Enemy>().Die();
            }
        }
    }
}
   
