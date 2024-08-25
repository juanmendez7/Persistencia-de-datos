using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanastaController : MonoBehaviour
{
public float speed = 10f;
    public float xLimit = 8f; // Limite de movimiento en el eje X

    void Update()
    {
        float move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(0, 0, move);

        // Limitar el movimiento en el eje X
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -xLimit, xLimit);
        transform.position = pos;
    }
}
