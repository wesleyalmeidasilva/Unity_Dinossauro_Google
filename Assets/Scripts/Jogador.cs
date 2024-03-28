using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Jogador : MonoBehaviour
{

    public Rigidbody2D rb;
    public float forcaPulo;
    public LayerMask layerChao;
    public float distanciaMinimaChao = 1;
    private bool estaNochao;
    private float pontos;
    public float multiplicadorDePontos = 1;
    public TMP_Text pontosText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        pontos += Time.deltaTime * multiplicadorDePontos;

        pontosText.text = Mathf.FloorToInt(pontos).ToString();

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Pular");
            Pular();
        };
    }

    void Pular()
    {
        if (estaNochao)
        {
            rb.AddForce(UnityEngine.Vector2.up * forcaPulo);
        }
    }

    private void FixedUpdate()
    {
        estaNochao = Physics2D.Raycast(transform.position, UnityEngine.Vector2.down, distanciaMinimaChao, layerChao);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Inimigo"))
        {
            SceneManager.LoadScene(0);
        }
    }

}
