using UnityEngine;
using System.Collections;
using UnityEngine.UI;    
using System;
using System.Linq;  
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
public class LevelHardness : MonoBehaviour {
	public int Level;
	public string RandomGenerated;
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
		 Process myProcess = new Process();
         myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
         myProcess.StartInfo.CreateNoWindow = true;
         myProcess.StartInfo.UseShellExecute = false;
		 myProcess.StartInfo.RedirectStandardOutput = true;
         myProcess.StartInfo.FileName = "C:\\Users\\Sam\\Desktop\\Test\\rubik3Sticker.generator";
         myProcess.EnableRaisingEvents = true;
		 myProcess.StartInfo.WorkingDirectory = "C:\\Users\\Sam\\Desktop\\Test\\";
		 myProcess.StartInfo.Arguments = seed.ToString()+" "+n.ToString()+" "+hardness.ToString();
		  myProcess.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
        {
            if (!String.IsNullOrEmpty(e.Data))
            {
                print(e.Data);
				RandomGenerated+=e.Data;
            }
        });
        myProcess.Start();
		myProcess.BeginOutputReadLine();
         } catch (Exception e){
             print(e);        
         }
	}
}