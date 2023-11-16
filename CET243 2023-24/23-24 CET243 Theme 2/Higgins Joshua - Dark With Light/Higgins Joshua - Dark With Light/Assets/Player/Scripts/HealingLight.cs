using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingLight : MonoBehaviour
{
    [SerializeField]
    float rawHeal = 100f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player1")
        {
            Player1Health player1Health = collision.gameObject.GetComponent<Player1Health>();
            if (player1Health != null)
            {
                Debug.Log("Player 1 Feels Light!");

                if (player1Health.CurrentHealth < 100)
                {
                    float amountToHeal = 100 - player1Health.CurrentHealth;
                    player1Health.Touch(amountToHeal);
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player1")
        {
            Player1Health player1Health = collision.gameObject.GetComponent<Player1Health>();
            if (player1Health != null)
            {
                float remainingHeal = 100 - player1Health.CurrentHealth;
                if (remainingHeal > 0)
                {
                    float amountToHeal = Mathf.Min(rawHeal * Time.deltaTime, remainingHeal);
                    player1Health.Touch(amountToHeal);
                }
            }
        }
    }
}
