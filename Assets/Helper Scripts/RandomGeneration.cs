using UnityEngine;
using System.Collections;
using UnityEngine.UI;    
using System;
using System.Linq;  
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
public class RandomGeneration : MonoBehaviour {
	public int Level;
	char[] delimiterChars = {' '};
	public static List<string> RandomGeneratedColors = new List<string>();
	string[] words;
	Process myProcess;
	string RandomGenerated;
	
	public void Click(int l)
	{
		Level=l;
		Generate(Level);
	}
	void Generate(int level){
		int seed=UnityEngine.Random.Range(1,10);
		int n=1;
		int hardness=1;
		if(Level==0){ //easy
			hardness=5;
		}
		else if(Level==1){//Moderate
			hardness=10;
		}
		else if(Level==2){
			hardness=15;
		}
		try {
		 myProcess = new Process();
         myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
         myProcess.StartInfo.CreateNoWindow = true;
         myProcess.StartInfo.UseShellExecute = false;
		 myProcess.StartInfo.RedirectStandardOutput = true;
         myProcess.StartInfo.FileName = "C:\\Users\\sam\\Desktop\\Test\\rubik3Sticker.generator";
         myProcess.EnableRaisingEvents = true;
		 myProcess.StartInfo.WorkingDirectory = "C:\\Users\\sam\\Desktop\\Test";
		 myProcess.StartInfo.Arguments = seed.ToString()+" "+n.ToString()+" "+hardness.ToString();
		 myProcess.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
        {
            if (!String.IsNullOrEmpty(e.Data))
            {
				RandomGenerated+=e.Data;
            }
        });
        myProcess.Start();
		myProcess.BeginOutputReadLine();
         } catch (Exception e){
             print(e);        
         }
		 myProcess.WaitForExit();
		 words = RandomGenerated.Split(delimiterChars);
		 foreach (string s in words){
			RandomGeneratedColors.Add(s);
        }
		Globals.RandomGeneratedFlag=true;
		Globals.ManualInputFlag=false;
		Globals.LoadFlag=false;
	}
}
