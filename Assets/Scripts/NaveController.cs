using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveController : MonoBehaviour
{
    static bool arcade = false;

    [SerializeField] float velocidad;

    [SerializeField] bool player2;
    [HideInInspector] public KeyCode arriba, abajo, derecha, izquierda, disparo, b1, b2, b3, b4, b5, b6;

    [SerializeField] float superior, inferior, derecho, izquierdo;

    [SerializeField] Marcador marcador;
    
    [SerializeField] float iframesTime;
    bool iframes;
    [SerializeField] Habilidad.habilidades[] tiposHabilidades = new Habilidad.habilidades[6];
    Habilidad[] habilidades = new Habilidad[6];

    [SerializeField] float fireRate;
    float timerRate;


    private void Start()
    {
        if (arcade)
        {
            if (player2)
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
        else
        {
            if (!player2)
            {
                arriba = KeyCode.W;
                abajo = KeyCode.S;
                derecha = KeyCode.D;
                izquierda = KeyCode.A;
                disparo = KeyCode.Escape;
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
                disparo = KeyCode.Escape;
                b1 = KeyCode.Keypad4;
                b2 = KeyCode.Keypad5;
                b3 = KeyCode.Keypad6;
                b4 = KeyCode.Keypad1;
                b5 = KeyCode.Keypad2;
                b6 = KeyCode.Keypad3;
            }
        }

        for (int i = 0; i < tiposHabilidades.Length; i++)
        {
            switch (tiposHabilidades[i])
            {
                case Habilidad.habilidades.none:
                    break;
                case Habilidad.habilidades.tiroEscopeta:
                    habilidades[i] = new TiroEscopeta(this);
                    break;
                case Habilidad.habilidades.metralleta:
                    habilidades[i] = new Metralleta(this);
                    break;
                case Habilidad.habilidades.balasRacimo:
                    habilidades[i] = new BalasRacimo(this);
                    break;
                case Habilidad.habilidades.balasRencorosas:
                    habilidades[i] = new BalasRencorosas(this);
                    break;
                case Habilidad.habilidades.balasRepulsivas:
                    habilidades[i] = new RepulsorBalas(this);
                    break;
                case Habilidad.habilidades.disparoPerforante:
                    habilidades[i] = new DisparoPerforante(this);
                    break;
            }
        }

    }

    private void Update()
    {
        Movimiento();
        Disparo();
        Habilidades();
    }

    public void LimitarTop(int i)
    {
        superior = 6.67f - (1.33f * i);
    }
    void Movimiento()
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

    void Disparo()
    {
        timerRate += Time.deltaTime;
        if(timerRate>=fireRate)
        //if (Input.GetKeyDown(disparo))
        {
            Sonidero.instance.NewSound(Sonidero.audios.disparo);
            GameObject g = BalasManager.instance.NewBala();
            ShootController sc = g.GetComponent<ShootController>();

            g.transform.position = transform.position;
            g.transform.rotation = Quaternion.identity;
            sc.SetPlayer(player2);

            foreach (Habilidad h in habilidades) if (h != null) h.ChargeMana();

            timerRate = 0;
        }
    }

    void Habilidades()
    {
        if (Input.GetKeyDown(b1)) habilidades[0].Active();
        if (Input.GetKeyDown(b2)) habilidades[1].Active();
        if (Input.GetKeyDown(b3)) habilidades[2].Active();
        if (Input.GetKeyDown(b4)) habilidades[3].Active();
        if (Input.GetKeyDown(b5)) habilidades[4].Active();
        if (Input.GetKeyDown(b6)) habilidades[5].Active();

    }

    public void ReciveHit()
    {
        if (iframes) return;
        marcador.PerderVida();
        StartCoroutine(Iframes());
    }

    IEnumerator Iframes()
    {
        this.GetComponentInChildren<Animator>().SetBool("Damage", true);
        iframes = true;
        yield return new WaitForSeconds(iframesTime);
        iframes = false;
        this.GetComponentInChildren<Animator>().SetBool("Damage", false);

    }

    public bool Player2()
    {
        return player2;
    }

    public float GetCharge(int index)
    {
        return habilidades[index].Charge();
    }   

    public KeyCode Accion()
    {
        return disparo;
    }
}
