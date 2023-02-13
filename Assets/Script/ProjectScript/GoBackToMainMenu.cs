using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackToMainMenu : MonoBehaviour
{
    void OnCollisionEnter(Collision newCollision)
	{
		// only do stuff if hit by a projectile
        Debug.Log ("AAAAAAAAAAAAAAA");
		if (newCollision.gameObject.tag == "Projectile") {
            Destroy (newCollision.gameObject);
			SceneManager.LoadScene("MainMenu");;
		}
	}
}
