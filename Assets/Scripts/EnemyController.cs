using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.UI.Image;

public class EnemyController : MonoBehaviour
{
    public float enemySpeed, lineLenght, offset;

    private Rigidbody2D enemyRig;
    private bool goRight, goLeft;
    public static float enemyScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        goLeft = true;
        enemyRig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //Dibujamos la línea
        Vector2 origin = new Vector2(transform.position.x, transform.position.y + offset);
        Vector2 target = new Vector2(transform.position.x - offset + lineLenght, transform.position.y + offset);
        Debug.DrawLine(origin, target, Color.black);

        RaycastHit2D raycast = Physics2D.Raycast(origin, Vector2.up, lineLenght);


        //Detectamos colisiones con el Raycast
        if (raycast.collider == null)
        {

        }
        else if (raycast.collider.CompareTag("Player"))
        {
            {
                enemyScore++;
                GameObject.Find("EnemyScore").GetComponent<TMP_Text>().text = ": " + enemyScore;
                //AudioManager.instance.PlaySFX("CollectCoin");
                Destroy(gameObject);
            }
        }

        if (goLeft)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            enemyRig.velocity = (-transform.right * enemySpeed) +
            (transform.up * enemyRig.velocity.y);
        }
        else if (goRight)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            enemyRig.velocity = (transform.right * 3) +
            (transform.up * enemyRig.velocity.y);
        }


        //if (enemyRig.transform.position.x < 2.9)
        //{
        //    //Debug.Log("Yolo");
        //    GetComponent<SpriteRenderer>().flipX = true;
        //    enemyRig.velocity = (transform.right * enemySpeed) +
        //    (transform.up * enemyRig.velocity.y);

        //}
        //else if (enemyRig.transform.position.z > -3)
        //{
        //    GetComponent<SpriteRenderer>().flipX = true;
        //    enemyRig.velocity = (-transform.right * 3) +
        //                (transform.up * enemyRig.velocity.y);
        //}

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.collider.CompareTag("Wall"))
            {
                if (goLeft)
                {
                    goLeft = false;
                    goRight = true;
                    Debug.Log("Momo");

                }
                else if (goRight)
                {
                    goRight = false;
                    goLeft = true;
                    Debug.Log("Momo2");
                }
            }
        }
    }
}
