using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class FruitController : MonoBehaviour
{
    [SerializeField] private GameObject fruit;
    public static float fruitScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.collider.CompareTag("Player"))
            {
                fruitScore++;
                GameObject.Find("fruitScore").GetComponent<TMP_Text>().text = ": " + fruitScore;
                //AudioManager.instance.PlaySFX("CollectCoin");
                Destroy(gameObject);
            }
        }
    }

}
