using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HijoPacman : MonoBehaviour
{

    public PacMan padre;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bala"))
        {
            if (collision.GetComponent<ShootController>())
            {
                if (collision.GetComponent<ShootController>().Player())
                {
                    padre.Cabrear(0);
                }
                else
                {
                    padre.Cabrear(1);
                }
            }
            if (collision.GetComponent<FatShootController>())
            {
                if (collision.GetComponent<FatShootController>().Player())
                {
                    padre.Cabrear(0);
                }
                else
                {
                    padre.Cabrear(1);
                }
            }
        }
    }
}
