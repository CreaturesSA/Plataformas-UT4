using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.UI.Image;

public class EnemyMovement : MonoBehaviour
{
    public float enemySpeed;

    private Rigidbody2D enemyRig;
    private bool goRight, goLeft;
   
    // Start is called before the first frame update
    void Start()
    {
        goLeft = true;
        enemyRig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        ////Dibujamos la línea
        //Vector2 origin = new Vector2((transform.position.x - offset), transform.position.y + offset);
        //Vector2 target = new Vector2(transform.position.x + lineLenght, transform.position.y + offset);
        //Debug.DrawLine(origin, target, Color.black);

        //RaycastHit2D raycast = Physics2D.Raycast(origin, Vector2.up, lineLenght);


        ////Detectamos colisiones con el Raycast
        //if (raycast.collider == null)
        //{

        //}
        //else if (raycast.collider.CompareTag("Player"))
        //{
        //    {
        //        SetAnimation("Hitted");
        //        enemyScore++;
        //        GameObject.Find("EnemyScore").GetComponent<TMP_Text>().text = ": " + enemyScore;
        //        //AudioManager.instance.PlaySFX("CollectCoin");
        //        Destroy(gameObject);
        //    }
        //}

        if (goLeft)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            enemyRig.velocity = (-transform.right * enemySpeed) +
            (transform.up * enemyRig.velocity.y);
        }
        else if (goRight)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            enemyRig.velocity = (transform.right * enemySpeed) +
            (transform.up * enemyRig.velocity.y);
        }

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
                }
                else if (goRight)
                {
                    goRight = false;
                    goLeft = true;
                }
            }
        }
    }
}
