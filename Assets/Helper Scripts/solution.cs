using UnityEngine;
using System.Collections;
using System;
using System.IO;
using UnityEngine.UI;
using System.Timers;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections.Generic;

public class solution : MonoBehaviour {
	string Sol=(System.Environment.CurrentDirectory )+Path.DirectorySeparatorChar +"Sol.txt";
	public static GameObject LoadingMessagePanel;
	public string[]words;
	public string[]solMsgs;
	public string[]m;
	String b;
	string sub;
	public String msg,msg1,msg2;
	public GameObject myMSG;
	char first;
	 int i=0;
	 int j=1;
	int L=0;
	public int lines=0;
	void Start(){
		if (File.Exists (Sol))
			Application.LoadLevel ("soultion");
		Globals.EndOfSolution = GameObject.Find ("EndOfSolution");
		Globals.EndOfSolution.SetActive (false);
		myMSG = GameObject.Find ("Mymsg");

		lines = File.ReadAllLines (Sol).Length;
		solMsgs = new string[lines];

		using (StreamReader sr= new StreamReader (Sol)) {
			while ((b=sr.ReadLine())!= null) {
				L = b.Length - 1;
				first = b [0];
				sub = b.Substring (1, L);
		if (first == 'U') {
			msg1="Rotate the upper face ";

			if (sub == "CW")// right
				msg2="Clock Wise";
			if (sub == "CCW")// left
				msg2="Counter Clock Wise ";
			if (sub == "180")
				msg2="180 degree";
			msg = msg1 + msg2;

			solMsgs[i]=msg;
			i++;
		}
		if (first == 'D') {
			msg1="Rotate the Down face ";
			if (sub == "CW")// right
				msg2="Clock Wise";
			if (sub == "CCW")
				msg2 ="Counter Clock wise";
			if (sub == "180")
				msg2="180 degree";
			msg = msg1 + msg2;

			solMsgs[i]=msg;
			i++;
		}

		if (first == 'F') {
			msg1="Rotate the Front face ";
			if (sub == "CW")// right
				msg2="Clock Wise";
			if (sub == "CCW")
				msg2 ="Counter Clock wise";
			if (sub == "180")
				msg2="180 degree";
			msg = msg1 + msg2;
		
			solMsgs[i]=msg;
			i++;
		}
		if (first == 'R') {
			msg1="Rotate the Right face ";
			if (sub == "CW")
				msg2="Clock Wise";
			if (sub == "CCW")
				msg2 ="Counter Clock wise";
			if (sub == "180")
				msg2="180 degree";
			msg= msg1 + msg2;
				
		   solMsgs[i]=msg;
			i++;
		}
		if (first == 'L') {
			msg1="Rotate the Left face ";
			if (sub == "CW")
				msg2="Clock Wise";
			if (sub == "CCW")
				msg2 ="Counter Clock wise";
			if (sub == "180")
				msg2="180 degree";
			msg = msg1 + msg2;
			
			solMsgs[i]=msg;
			i++;
		}
		if (first == 'B') {
			msg1="Rotate the Back face ";
			if (sub == "CW")
				msg2="Clock Wise";
			if (sub == "CCW")
				msg2 ="Counter Clock wise ";
			if (sub == "180")
				msg2="180 degree";
			msg = msg1 + msg2;
		
			solMsgs[i]=msg;
			i++;
		} 
	       }// end of while 

			sr.Close();
		}// end of StreamReader
		myMSG.GetComponent<Text>().text = solMsgs [0];
	}// end of Start

	 public void nextStep() {
		myMSG.GetComponent<Text> ().text = solMsgs [j];
		j++;
		if (j == lines) {
			Globals.EndOfSolution.SetActive (true);
	
		}
	}

	public void hideMessage(){
		Globals.EndOfSolution.SetActive(false);
	}



}

