using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Auxiliar
{
    public static void RotacionAsistida(GameObject rotado, Vector3 objetivo)
    {
        Vector3 direccion = objetivo - rotado.transform.position;

        rotado.transform.rotation = Quaternion.identity;
        Debug.Log(Mathf.Atan2(direccion.x, direccion.y));
        rotado.transform.Rotate(Vector3.forward, Mathf.Rad2Deg * Mathf.Atan2(direccion.y, direccion.x));
    }
    public static void RotacionAsistidaDirecta(GameObject rotado, Vector3 direccion)
    {
        rotado.transform.rotation = Quaternion.identity;
        Debug.Log(Mathf.Atan2(direccion.x, direccion.y));
        rotado.transform.Rotate(Vector3.forward, Mathf.Rad2Deg * Mathf.Atan2(direccion.y, direccion.x));
    }
}
