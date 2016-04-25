using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {
	public void LvlSelect(int level){
		SceneManager.LoadScene(level);
	}
	public void Exit(){
		Application.Quit();
	}
}
