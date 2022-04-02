using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveController : MonoBehaviour
{
    [SerializeField] float velocidad;

    [SerializeField] bool player2;
    KeyCode arriba, abajo, derecha, izquierda, disparo, b1, b2, b3, b4, b5, b6;

    [SerializeField] float superior, inferior, derecho, izquierdo;

    private void Start()
    {
        if (!player2)
        {
            arriba = KeyCode.W;
            abajo = KeyCode.S;
            derecha = KeyCode.D;
            izquierda = KeyCode.A;
            disparo = KeyCode.Q;
            b1 = KeyCode.U;
            b2 = KeyCode.I;
            b3 = KeyCode.O;
            b4 = KeyCode.J;
            b5 = KeyCode.K;
            b6 = KeyCode.L;
        }
        else
        {
            float oldDerecho = derecho;
            derecho = -izquierdo;
            izquierdo = -oldDerecho;

            arriba = KeyCode.UpArrow;
            abajo = KeyCode.DownArrow;
            derecha = KeyCode.RightArrow;
            izquierda = KeyCode.LeftArrow;
            disparo = KeyCode.Return;
            b1 = KeyCode.Insert;
            b2 = KeyCode.Home;
            b3 = KeyCode.PageUp;
            b4 = KeyCode.Delete;
            b5 = KeyCode.End;
            b6 = KeyCode.PageDown;
        }
    }

    private void Update()
    {
        float x = transform.position.x, y = transform.position.y;
        if (Input.GetKey(arriba)) y += velocidad * Time.deltaTime;
        if (Input.GetKey(abajo)) y -= velocidad * Time.deltaTime;
        if (Input.GetKey(derecha)) x += velocidad * Time.deltaTime;
        if (Input.GetKey(izquierda)) x -= velocidad * Time.deltaTime;
        x = Mathf.Clamp(x, izquierdo, derecho);
        y = Mathf.Clamp(y, inferior, superior);
        transform.position = new Vector2(x, y);
    }
}
