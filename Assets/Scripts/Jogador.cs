using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Jogador : MonoBehaviour
{

    public Rigidbody2D rb;
    public float forcaPulo;
    public LayerMask layerChao;
    public float distanciaMinimaChao = 1;
    private bool estaNochao;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Pular");
            Pular();
        };
    }
    private void FixedUpdate()
    {
        estaNochao = Physics2D.Raycast(transform.position, UnityEngine.Vector2.down, distanciaMinimaChao, layerChao);
    }

    void Pular()
    {
        if (estaNochao)
        {
            rb.AddForce(UnityEngine.Vector2.up * forcaPulo);
        }
    }


}
