using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class NextLevel : MonoBehaviour
{

  
        private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.collider.CompareTag("Player"))
            {
                if (FruitController.fruitScore == 3)
                {
                    SCManager.instance.LoadScene("Level2");
                }else if(EnemyController.enemyScore == 1)
                {
                    SCManager.instance.LoadScene("Level3");
                }
                
            }
        }
    }
}
