using UnityEngine;
using System.Collections;
using UnityEngine.UI;    
public class ChangeColor : MonoBehaviour {
	ColorBlock colorblock = ColorBlock.defaultColorBlock;
	void Update(){
		if(OnClickChangeColor.flag==1){
			if(OnClickChangeColor.myColor == 1){ //green
				colorblock.normalColor = Color.green;
				OnClickChangeColor.flag=0;
			}
			else if(OnClickChangeColor.myColor == 2){ //red
				colorblock.normalColor =  Color.red;
				OnClickChangeColor.flag=0;
			}
			else if(OnClickChangeColor.myColor == 3){ //blue
				colorblock.normalColor =  Color.blue;
				OnClickChangeColor.flag=0;
			}
			else if(OnClickChangeColor.myColor == 4){ //orange
				colorblock.normalColor = new Color(255,165,0);
				OnClickChangeColor.flag=0;
			}
			else if(OnClickChangeColor.myColor == 5){ //yellow
				colorblock.normalColor =  Color.yellow;
				OnClickChangeColor.flag=0;
			}
			else if(OnClickChangeColor.myColor == 6){ //white
				colorblock.normalColor =  Color.white;
				OnClickChangeColor.flag=0;
			}
			GetComponent<Button>().colors = colorblock;
		}
	}
}