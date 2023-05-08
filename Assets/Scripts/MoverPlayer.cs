using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPlayer : MonoBehaviour
{ 
    public Animator anim;
    public float velocidadMovimiento = 22f; //velocidad movimiento.
    public float velocidadRotacion = 250f; // velocidad rotación.
    public float x, y; // aquí guardo los controles.

    void Start()
    {
        anim = GetComponent<Animator>(); // obtengo el animator
    }

    void Update() // se ejecuta a medida voy jugando frame x frame.
    {
        x = Input.GetAxis("Horizontal"); // Guardamos controles.
        y = Input.GetAxis("Vertical");

        // Translate = movimiento // Rotate = Rotación
        this.transform.Rotate(new Vector3(0, x * velocidadRotacion* Time.deltaTime,0));
        this.transform.Translate(new Vector3(0,0,y * velocidadMovimiento * Time.deltaTime));
        
        // cambiar variable del animator según mis controles.
        anim.SetFloat("VerX", x);  
        anim.SetFloat("VerY", y);


        if (Input.GetKey("g"))
        {
            anim.SetBool("Other", true);
            anim.Play("Samba");            
        }

        if (Input.GetKey("h"))
        {   
            anim.SetBool("Other", true);
            anim.Play("Dancing");
        }
        if(x>0 || x<0 || y<0 || y>0)
        {
            anim.SetBool("Other", false);
        }
    }
}
