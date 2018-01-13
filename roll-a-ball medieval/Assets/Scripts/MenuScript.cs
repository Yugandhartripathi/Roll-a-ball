using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartGame() {
		SceneManager.LoadScene ("second round");
		}

	public void GetHelp() {
		SceneManager.LoadScene ("Help");
	}

	public void Endgame() {
		Application.Quit ();
	}

	public void BacktoMenu() {
		SceneManager.LoadScene ("Menu");
	}
}


