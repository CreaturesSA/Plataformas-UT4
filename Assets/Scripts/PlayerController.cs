using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed, jumpForce, lineLenght, offset;

    private Rigidbody2D rig;

    [SerializeField] private bool isJumping = false;
    // Start is called before the first frame update
    void Start()
    {
        //Camera.main.transform.SetParent(transform);
        //Camera.main.transform.position = transform.position + (Vector3.up) + (transform.forward * -10);
        rig = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        rig.velocity = (transform.right * speed * Input.GetAxis("Horizontal")) +
        (transform.up * rig.velocity.y);

        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if (Input.GetButtonDown("Fire1") && !isJumping)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            AudioManager.instance.PlaySFX("Jump");
        }

        //Dibujamos la l�nea
        Vector2 origin = new Vector2(transform.position.x, transform.position.y - offset);
        Vector2 target = new Vector2(transform.position.x, transform.position.y - offset - lineLenght);
        Debug.DrawLine(origin, target, Color.black);

        //Hacemos el Raycast
        RaycastHit2D raycast = Physics2D.Raycast(origin, Vector2.down, lineLenght);

        //Detectamos colisiones con el Raycast
        if (raycast.collider == null)
        {
            isJumping = true;
        }
        else
        {
            isJumping = false;
        }


        // ------------------------------------------------------------------------------------------
        // APLICACI�N AL JUEGO DE PLATAFORMAS QUE UTILIZA RAYCAST PARA DETECTAR QUE EST� EN EL SUELO
        // ------------------------------------------------------------------------------------------
        // Si el raycast no toca con nada el personaje est� en el aire
        if (raycast.collider == null)
        {
            SetAnimation("Jump");
        }
        else
        {
            // Si est� sobre una superficie pero se mueve lateralmente
            if (GetComponent<Rigidbody2D>().velocity.x != 0) SetAnimation("Run");
            else SetAnimation("Idle"); // Si est� sobre una superficie pero no se mueve
        }
    }


    // -----------------------------------------------------------------------------
    // M�todo que desactiva todos los par�metros del Animator y activa uno concreto
    // -----------------------------------------------------------------------------
    void SetAnimation(string name)
    {

        // Obtenemos todos los par�metros del Animator
        AnimatorControllerParameter[] parametros = GetComponent<Animator>().parameters;

        // Recorremos todos los par�metros y los ponemos a false
        foreach (var item in parametros) GetComponent<Animator>().SetBool(item.name, false);

        // Activamos el pasado por par�metro
        GetComponent<Animator>().SetBool(name, true);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision != null)
        {
            if (collision.collider.CompareTag("Enemy"))
            {
                AudioManager.instance.PlaySFX("Hit");
                AudioManager.instance.PlayMusic("LoseALife");
                SCManager.instance.LoadScene("GameOver");
            }
        }
    }

}



//if (Input.GetButtonDown("Jump"))
//    {
//        rig.AddForce(transform.up * jumpForce);
//    }
//anim.SetFloat("VelocityX", Mathf.Abs(rig.velocity.x));
//anim.SetFloat("VelocityY", rig.velocity.y);
