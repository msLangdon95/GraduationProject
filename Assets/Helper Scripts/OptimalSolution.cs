using UnityEngine;
using System.Collections;
using UnityEngine.UI;    
using System;
using System.Linq;  
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
public class OptimalSolution : MonoBehaviour {
	Process myProcess;
	String inputFilePath="C:\\Users\\sam\\Desktop\\Test\\input.txt";
	void Start(){
	try {
		 myProcess = new Process();
         myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
         myProcess.StartInfo.CreateNoWindow = true;
         myProcess.StartInfo.UseShellExecute = false;
		 myProcess.StartInfo.RedirectStandardOutput = true;
		 
		 myProcess.StartInfo.RedirectStandardInput = true;
		 String inputText = File.ReadAllText(inputFilePath);
		 StreamWriter myStreamWriter = myProcess.StandardInput;
		 myStreamWriter.Write(inputText);
		 
         myProcess.StartInfo.FileName = "C:\\Users\\sam\\Desktop\\Test\\rubik3Sticker.ida2";
         myProcess.EnableRaisingEvents = true;
		 myProcess.StartInfo.WorkingDirectory = "C:\\Users\\sam\\Desktop\\Test";
		 myProcess.StartInfo.Arguments = "corner.bin edge1.bin edge2.bin";
		 myProcess.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
        {
            if (!String.IsNullOrEmpty(e.Data))
            {
                print(e.Data);
				print ("here");
            }
        });
        myProcess.Start();
		myProcess.BeginOutputReadLine();
         } catch (Exception e){
             print(e);        
         }
		 myProcess.WaitForExit();
	}
}	
		