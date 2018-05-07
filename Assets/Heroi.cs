using UnityEngine;
using System.Collections;

public class Heroi : MonoBehaviour
{
    Animator animator;
    float axis;
    Vector2 velocidade;
    bool ladoDireito = true;
    bool noChao = false;
    float chaoCheckRaio = 0.2f;

    public float MaxVelocidade = 10;

    public Transform ChaoCheck;
    public LayerMask OQueEChao;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        noChao = Physics2D.OverlapCircle(ChaoCheck.position, chaoCheckRaio, OQueEChao);
        animator.SetBool("NoChao", noChao);

        axis = Input.GetAxis("Horizontal");

        if (axis > 0 && !ladoDireito)
            Vire();
        if (axis < 0 && ladoDireito)
            Vire();

        velocidade = new Vector2(axis * MaxVelocidade, GetComponent<Rigidbody2D>().velocity.y);

        animator.SetFloat("Velocidade", Mathf.Abs(axis));

        GetComponent<Rigidbody2D>().velocity = velocidade;
        animator.SetFloat("VelocidadeVertical", GetComponent<Rigidbody2D>().velocity.y);

    }

    // Update is called once per frame
    void Update()
    {
        if (noChao && Input.GetButton("Jump"))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 30));
            animator.SetBool("NoChao", false);
        }

    }

    void Vire()
    {
        ladoDireito = !ladoDireito;

        Vector2 novoScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);

        transform.localScale = novoScale;
    }
}
