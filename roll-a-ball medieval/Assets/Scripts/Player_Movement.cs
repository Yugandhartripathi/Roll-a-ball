using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour {

	public Text CountText;
	public int lives;
	public Text WinText;
	public Text timer;
	public Text lifes;
	public int score;
	public int speed;
	public int speed1;
	int cnt=1;
	int gemLife = 0;
	int gemScore = 0;
	int gemMain = 0;
	int geminvi=0;
	int hiddenlives;
	public Rigidbody myRB;
	public float HForce;
	public float VForce;
	public int checks;
	public Canvas PM;
	public GameObject particles;
	public GameObject portal;
	public GameObject portalstop;
	public Renderer rend;
	public Renderer rend1;
	public float time;


	// Use this for initialization
	void Start () {
		score = 0;	
		time = 0;
		checks = 0;
		speed = 10;
		speed1 = 10;
		lives = 10;
		hiddenlives = 0;
		SetCountText ();
		cnt = 1;
		PM = GetComponent<Canvas> ();
		rend = portal.GetComponent<Renderer>();
		rend.GetComponent<Renderer>().enabled = false;
		rend1 = portalstop.GetComponent<Renderer>();
		rend1.GetComponent<Renderer>().enabled = false;
		timer.text = "";
		lifes.text = "";
	}

	// Update is called once per frame
	void Update () {
		time = time + 1 * Time.deltaTime;
		TIMER ();
		if (lives == 0) {
			SceneManager.LoadScene ("LOSE");
		}

	}

	void FixedUpdate () {
		HForce = Input.GetAxis ("Horizontal");
		VForce = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (VForce, 0.0f, -HForce);
		myRB.AddForce (movement * speed);
		if (Input.GetKeyDown (KeyCode.Space) && cnt>0){
			myRB.velocity = new Vector3 (myRB.velocity.x, speed1, myRB.velocity.z);
			cnt--;
		}

	}
	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "ground" || other.gameObject.tag == "trapfloor" || other.gameObject.tag == "Finish") {
			cnt = 1;
		}
		if (other.gameObject.tag == "Finish" && (gemMain == 1)) {
			SceneManager.LoadScene ("WIN");
		}
	}

	void OnTriggerEnter(Collider other){
		

		if (other.gameObject.tag == "Token") {
			spawnParticles (other.transform.position);
			Destroy (other.gameObject);
			score++;
			SetCountText ();
		}
		if (other.gameObject.tag == "trapfloor") {
			Destroy (other.gameObject);
		}

		if (other.gameObject.tag == "livesgem") {
			gemLife = 1;
			Destroy (other.gameObject);
			lives += 5;
		}
		if (other.gameObject.tag == "invincible") {
			geminvi = 1;
			Destroy (other.gameObject);
			hiddenlives += 5;
		}
		if (other.gameObject.tag == "scoregem") {
			gemScore = 1;
			Destroy (other.gameObject);
			score += 5;
		}
		if (other.gameObject.tag == "death") {
			if (geminvi == 1 && hiddenlives > 0)
				hiddenlives--;
			else
				lives--;
		}
		if (other.gameObject.tag == "maingem") {
			gemMain = 1;
			if (gemLife == 1 && gemScore == 1) {
				rend.GetComponent<Renderer> ().enabled = true;
				rend1.GetComponent<Renderer> ().enabled = true;
			}
			Destroy (other.gameObject);
		}
		if (other.gameObject.tag == "Finish" && (gemMain == 1)) {
			SceneManager.LoadScene ("WIN");
		}
		if (other.gameObject.tag == "lava") {
			lives--;
		}


	}

	void SetCountText()
	{
		CountText.text = "Count: " + score;
	}

	void TIMER()
	{
		timer.text = "Time: " + time;
		lifes.text = "Lives left:" + lives;
	}
		
	public void Pause(){
		if (Time.timeScale == 0)
			Time.timeScale = 1;
		else
			Time.timeScale = 0;;
	}	
	void spawnParticles(Vector3 temppos)
	{
		Instantiate (particles, temppos, Quaternion.identity);
	}
}

