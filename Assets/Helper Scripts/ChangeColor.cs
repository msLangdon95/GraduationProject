using UnityEngine;
using System.Collections;
using UnityEngine.UI;    
public class ChangeColor : MonoBehaviour {
	ColorBlock colorblock = ColorBlock.defaultColorBlock;
	void Update(){
		if(OnClickChangeColor.myColor == 1){ //green
			colorblock.normalColor = Color.green;
		}
		if(OnClickChangeColor.myColor == 2){ //red
			colorblock.normalColor =  Color.red;
		}
		if(OnClickChangeColor.myColor == 3){ //blue
			colorblock.normalColor =  Color.blue;
		}
		if(OnClickChangeColor.myColor == 4){ //orange
			colorblock.normalColor = new Color(255,165,0, 255);
		}
		if(OnClickChangeColor.myColor == 5){ //yellow
			colorblock.normalColor =  Color.yellow;
		}
		if(OnClickChangeColor.myColor == 6){ //white
			colorblock.normalColor =  Color.white;
		}
		GetComponent<Button>().colors = colorblock;
	}
}