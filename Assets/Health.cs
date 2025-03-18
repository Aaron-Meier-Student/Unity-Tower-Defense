using UnityEngine;
using UnityEngine.Events;

namespace TowerDefense
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int currentHealth = 3;

        public UnityEvent OnTakeDamage = new UnityEvent();
        public UnityEvent OnZeroHealth = new UnityEvent();

        void TakeDamage(int damage)
        {
            currentHealth -= damage;
            ValueDisplay.OnValueChanged.Invoke(gameObject.name + "Health", currentHealth);
            OnTakeDamage.Invoke();

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                OnZeroHealth.Invoke();
                Destroy(gameObject);
            }
        }

        public static void TryDamage(GameObject target, int damage)
        {
            Health health = target.GetComponent<Health>();

            if (health)
            {
                health.TakeDamage(damage);
            }
        }
    }
}
