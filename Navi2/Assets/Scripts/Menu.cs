using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

	public void GoToLevel1(){
		GameManager.Instance.GoToLevel("Level1");
	}
}
