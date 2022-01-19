using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
	public float velocidad;
    float TiempoDeVida = 1;
    // Update is called once per frame
    void Update()
    {
		transform.position += (Vector3.up * Mathf.Sin(transform.eulerAngles.z * Mathf.PI / 180) + Vector3.right * Mathf.Cos(transform.eulerAngles.z * Mathf.PI / 180)) * velocidad;
        TiempoDeVida -= Time.deltaTime;
        if (TiempoDeVida <= 0)
        {
            Destroy(gameObject);
        }
	}
}
