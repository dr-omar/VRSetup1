using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; // include so we can load new scenes
using UnityEngine.UI;

public class MenuButtonLoadLevel : MonoBehaviour {

	public Toggle toggler;

	public void loadLevel(string levelToLoad)
	{
		//if (toggler.isOn) {
			//SceneManager.LoadScene(levelToLoad + "VR");
		//}
		//else {
			SceneManager.LoadScene(levelToLoad);
		//}
		
	}
}
