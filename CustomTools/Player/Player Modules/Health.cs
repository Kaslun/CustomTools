using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Health : MonoBehaviour
    {
        public float health;
        public float maxHealth;

        [Range(0, 1)]
        public float currHealthPercentage;

        private void Update()
        {
            if (health <= 0)
            {
                //GameManager.GameOver();
            }
        }

        private void CalculateHealthBar(float currHP, float maxHP)
        {
            currHealthPercentage = currHP / maxHP;
        }

        public void AddHealth()
        {
            if (health < maxHealth)
                health++;
        }

        public void RemoveHealth()
        {
            if (health > 0)
                health--;
            else
                return;
            //GameManager.GameOver();
        }
    }
}
