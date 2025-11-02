using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Required for Image component

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public int vidaDoJogador;
	private float horizontal;
	private float speed;
	private float jumpingPower;
	public float pearModifier;
	public bool gun;
	public int timer;
 


	[SerializeField] private Image imageSelector, timerBar;
	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private Transform groundCheck;
	[SerializeField] private LayerMask groundLayer;
	[SerializeField] private Sprite[] imageBox;
	[SerializeField] private GameObject gunModel;

	[SerializeField] private AtaqueJogador _ataqueDoJogador;

	void Start()
	{
		pearModifier = 1;
		speed = 4f;
		jumpingPower = 8f;
		vidaDoJogador = 4;
		gun = false;

		StartCoroutine(TimerUp());

	}

	// Update is called once per frame
	void Update()
	{
		horizontal = Input.GetAxisRaw("Horizontal");

		if (Input.GetButton("Jump")  && IsGrounded())
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
		}

		if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
		{
			rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
		}

		LifeUIUpdate();
	}


	public void LifeUIUpdate()
    {
        switch (vidaDoJogador)
        {
			case 0:
				imageSelector.sprite = imageBox[0];
				break;
			case 1:
				imageSelector.sprite = imageBox[1];
				break;
			case 2:
				imageSelector.sprite = imageBox[2];
				break;
			case 3:	
				imageSelector.sprite = imageBox[3];
				break;
			case 4:
				imageSelector.sprite = imageBox[4];
				break;
		}
    }
	private void FixedUpdate()
	{
		rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
	}

	private bool IsGrounded()
	{
		return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{


		if (other.gameObject.tag == "Inimigo")
		{
			vidaDoJogador--;
			Destroy(other.gameObject);
			 

			if (vidaDoJogador == 0)
			{
				SceneManager.LoadScene("GameOver");
			}

		}

		else if (other.gameObject.tag == "Orange")
		{

			Destroy(other.gameObject);
			if (4 > vidaDoJogador)
			{
				vidaDoJogador++;
				 
			}
		 

		}

		else if (other.gameObject.tag == "Lemon")
		{

				Destroy(other.gameObject);
			if(gun == false)
            {
				timer = 0;
				gun = true;
				gunModel.SetActive(true);
				StartCoroutine(AtirarOn());
            }
			else if(gun == true)
            {
				timer = 0;
            }

		}

		else if (other.gameObject.tag == "Pear")
		{

			Destroy(other.gameObject);
			pearModifier *= 1.2f;

		}

	}

	IEnumerator AtirarOn()
    {
		StartTimer();
        while (gun)
        {
			_ataqueDoJogador.DispararProjetil();
			yield return null;
		}

		yield return null;
	}

	IEnumerator TimerForGun()
    {
		while(timer != 10)
        {
			timer++;
			yield return new WaitForSeconds(1); 
        }

		gun = false;
		gunModel.SetActive(false);
	}

	IEnumerator TimerUp()
	{
		yield return new WaitForSeconds(0.1f);

		while (timerBar.fillAmount != 1)
		{
			timerBar.fillAmount = Mathf.Lerp(timerBar.fillAmount, timerBar.fillAmount += 0.01f, Time.deltaTime * pearModifier);
			yield return null;


		}


	}

	public void StartTimer()
    {
		StartCoroutine(TimerForGun());
	}

}

 

 



