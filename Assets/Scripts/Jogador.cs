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
    public Animator animatorComponent;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        pontos += Time.deltaTime * multiplicadorDePontos;

        pontosText.text = Mathf.FloorToInt(pontos).ToString();

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            Pular();
        };

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Abaixar();
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            Levantar();
        }
    }

    void Pular()

    {
        if (estaNochao)
        {
            rb.AddForce(UnityEngine.Vector2.up * forcaPulo);
        }
    }

    void Abaixar()
    {
        animatorComponent.SetBool("Abaixado", true);
    }

    void Levantar()
    {
        animatorComponent.SetBool("Abaixado", false);
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
