using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int velocidade = 4;
    public int forcapulo = 8;
    public bool noChao;

    private Rigidbody rb;
    private AudioSource source;
    // Start is called before the first frame update

    void Start()
    {
        Debug.Log("START");
        TryGetComponent(out rb);
        TryGetComponent(out source);
    }

    private void OnCollisionEnter(Collision collision)
   {
        if(!noChao && collision.gameObject.tag == "chão")
        {
            noChao = true;
        }
    }

    
  

    // Update is called once per frame
    void Update()
    {
         Debug.Log("UPDATE"); 
         float h = Input.GetAxis("Horizontal"); // -1 esquerda, 0 nada, 1 direita
         float v = Input.GetAxis("Vertical"); // - 1 pra tr�s, 0 nada, 1 pra frente

         Vector3 direcao = new Vector3(h,0,v);
         rb.AddForce(direcao * velocidade * Time.deltaTime,ForceMode.Impulse);

         if(Input.GetKeyDown(KeyCode.Space) && noChao)
         {
             //pulo
          source.Play();
             rb.AddForce(Vector3.up * forcapulo, ForceMode.Impulse);
             noChao = false;
         }








 
         if (transform.position.y <= - 10)
         {
            //jogador caiu
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
         }
    } 
}
