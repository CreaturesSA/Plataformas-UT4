using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CollectableController : MonoBehaviour
{
    [SerializeField] private GameObject collectable;
    public static float score = 0;
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
                score++;
                GameObject.Find("Score").GetComponent<TMP_Text>().text = ": " + score;
                //AudioManager.instance.PlaySFX("CollectCoin");
                Destroy(gameObject);
            }
        }
    }

}
