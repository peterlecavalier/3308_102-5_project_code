using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour {
	public  GameObject username;
	public GameObject password;
	public static string Username;
	private string Password;
	private String[] Lines;
	private string DecryptedPass;

	public void LoginButton(){
		bool UN = false;
		bool PW = false;
		if (Username != ""){
			UN=true;
		} else {
			Debug.LogWarning("Username Field Empty");
		}
		if (Password != ""){
			PW=true;
		} else {
			Debug.LogWarning("Password Field Empty");
		}
		if (UN == true&&PW == true){
            Username = username.GetComponent<InputField>().text;
            Password = password.GetComponent<InputField>().text;
            //username.GetComponent<InputField>().text = "";
			//password.GetComponent<InputField>().text = "";	
			print ("Login Sucessful");
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Tab)){
			if (username.GetComponent<InputField>().isFocused){
				password.GetComponent<InputField>().Select();
			}
		}
		if (Input.GetKeyDown(KeyCode.Return)){
			if (Password != ""&&Password != ""){
				LoginButton();
			}
		}
        Username = username.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
    }
}
