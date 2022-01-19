using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    Transform anteriorFrame;
    Animator animator;
    AnimatorControllerParameter[] Parametros;
    SpriteRenderer sprite;
    Transform EsteFrame;
    //Todo esto es feisimo, pero meda pereza modificarlo para k quede bonito, kys
    float Este;
    float anteriorX;
    float anteriorY;
    float anteriorAnteriorX;
    float anteriorAnteriorY;
    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
        Parametros=animator.parameters;
        sprite = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    void PonerParametrosEnFlaso()
    {
        sprite.flipX = false;
        foreach (AnimatorControllerParameter parameter in animator.parameters)
        {
            if (parameter.name != "ListoParaPegar")
            {
                animator.SetBool(parameter.name, false);
            }
        }
    }
    public void ControlarAnimaciones()
    {

        if (anteriorFrame != null)
        {
            anteriorAnteriorX = anteriorX;
            anteriorAnteriorY = anteriorY;
        }
        anteriorFrame = EsteFrame;
        if (anteriorFrame != null)
        {
            anteriorX = anteriorFrame.position.x;
            anteriorY = anteriorFrame.position.y;
        }
        EsteFrame = transform;
        Este = EsteFrame.position.x;
        if (anteriorFrame != null)
        {
            if (!animator.GetBool("ListoParaPegar"))
            {
                PonerParametrosEnFlaso();
                if (EsteFrame.position.x - anteriorAnteriorX > 0)
                {
                    if (EsteFrame.position.y - anteriorAnteriorY > 0)
                    {
                        animator.SetBool("Detras", true);
                    }
                    else
                    {
                        sprite.flipX = true;
                        animator.SetBool("Frente", true);
                    }
                }
                else
                {
                    if (EsteFrame.position.y - anteriorAnteriorY > 0)
                    {
                        animator.SetBool("Detras", true);
                        sprite.flipX = true;
                    }
                    else
                    {
                        animator.SetBool("Frente", true);
                    }
                }
            } 
        }
        else
        {
            if (transform.position.y - GameObject.FindGameObjectWithTag("Base").transform.position.y > 0)
            {
                GetComponent<Animator>().SetBool("Frente", true);
            }
            else
            {
                GetComponent<Animator>().SetBool("Detras", true);
            }
        }
    }
}
