using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class EnemyController : MonoBehaviour
{
    public float enemySpeed, lineLenght, offset;
    private Rigidbody2D enemyRig;
    // Start is called before the first frame update
    void Start()
    {
        enemyRig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //Dibujamos la línea
        Vector2 origin = new Vector2(transform.position.x - offset, transform.position.y);
        Vector2 target = new Vector2(transform.position.x - offset - lineLenght, transform.position.y);
        Debug.DrawLine(origin, target, Color.black);

        RaycastHit2D raycast = Physics2D.Raycast(origin, Vector2.left, lineLenght);

        //Detectamos colisiones con el Raycast
        if (raycast.collider == null)
        {
            //isJumping = true;
        }
        else
        {
            //Debug.Log("Tremendo");
            Debug.Log(raycast.collider.gameObject);
        }

        if (enemyRig.transform.position.x < 2.9)
        {
            Debug.Log("Yolo");
            GetComponent<SpriteRenderer>().flipX = true;
            enemyRig.velocity = (transform.right * enemySpeed) +
            (transform.up * enemyRig.velocity.y);
            
        }
        //else if (enemyRig.transform.position.z > -3)
        //{
        //    GetComponent<SpriteRenderer>().flipX = true;
        //    enemyRig.velocity = (-transform.right * 3) +
        //                (transform.up * enemyRig.velocity.y);
        //}

    }
}
