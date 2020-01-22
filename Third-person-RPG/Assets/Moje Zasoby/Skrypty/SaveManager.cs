using UnityEngine;
using System.Collections;

public class SaveManager : MonoBehaviour 
{
	public GameObject saveDialogUI;

	// Use this for initialization
	void Start () 
	{
		HideSaveDialogUI ();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void ShowSaveDialogUI()
	{
		saveDialogUI.SetActive (true);

		Time.timeScale = 0;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}


	public void HideSaveDialogUI()
	{
		saveDialogUI.SetActive (false);

		Time.timeScale = 1;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	public void SaveGame()
	{
		//Wyczysc wszystko
		PlayerPrefs.DeleteAll ();

		//Zapisz dane na poziomie gry
		PlayerPrefs.SetString ("level_name", Application.loadedLevelName);

		//Zapisz dane gracza
		GameObject player = GameObject.FindWithTag("Player");

		PlayerPrefs.SetFloat ("player_posX", player.transform.position.x);
		PlayerPrefs.SetFloat ("player_posY", player.transform.position.y);
		PlayerPrefs.SetFloat ("player_posZ", player.transform.position.z);

		PlayerPrefs.SetFloat ("player_rotX", player.transform.rotation.x);
		PlayerPrefs.SetFloat ("player_rotY", player.transform.rotation.y);
		PlayerPrefs.SetFloat ("player_rotZ", player.transform.rotation.z);

		PlayerAttribute playerStat = player.GetComponent<PlayerAttribute> ();

		PlayerPrefs.SetFloat ("player_level", playerStat.level);
		PlayerPrefs.SetFloat ("player_healthPoint", playerStat.healthPoint);
		PlayerPrefs.SetFloat ("player_manaPoint", playerStat.manaPoint);
		PlayerPrefs.SetFloat ("player_attackDamage", playerStat.attackDamage);
		PlayerPrefs.SetFloat ("player_specialAttackDamage", playerStat.specialAttackDamage);
		PlayerPrefs.SetFloat ("player_defense", playerStat.defense);

		//Zapis danych kamery gracza
		GameObject gameCamera = GameObject.FindWithTag("MainCamera");

		PlayerPrefs.SetFloat ("camera_posX", gameCamera.transform.position.z);
		PlayerPrefs.SetFloat ("camera_posY", gameCamera.transform.position.y);
		PlayerPrefs.SetFloat ("camera_posZ", gameCamera.transform.position.z);
		
		PlayerPrefs.SetFloat ("camera_rotX", gameCamera.transform.rotation.x);
		PlayerPrefs.SetFloat ("camera_rotY", gameCamera.transform.rotation.y);
		PlayerPrefs.SetFloat ("camera_rotZ", gameCamera.transform.rotation.z);

		//Zapis danych potowrow

		GameObject [] allMonsters = GameObject.FindGameObjectsWithTag("Monster");

		foreach (GameObject monster in allMonsters) 
		{
			PlayerPrefs.SetInt("monster" + monster.GetInstanceID() + "_alive", 1);

			PlayerPrefs.SetFloat("monster" + monster.GetInstanceID() + "_posX", monster.transform.position.x);
			PlayerPrefs.SetFloat("monster" + monster.GetInstanceID() + "_posY", monster.transform.position.y);
			PlayerPrefs.SetFloat("monster" + monster.GetInstanceID() + "_posZ", monster.transform.position.z);

			PlayerPrefs.SetFloat("monster" + monster.GetInstanceID() + "_rotX", monster.transform.rotation.x);
			PlayerPrefs.SetFloat("monster" + monster.GetInstanceID() + "_rotY", monster.transform.rotation.y);
			PlayerPrefs.SetFloat("monster" + monster.GetInstanceID() + "_rotZ", monster.transform.rotation.z);

			EnemyAI enemyStat = monster.GetComponent<EnemyAI>();

			PlayerPrefs.SetFloat ("monster" + monster.GetInstanceID() + "_healthPoint", enemyStat.healthPoint);

		}

		//Zapis danych przedmiotow/ulepszen

		GameObject [] allItems = GameObject.FindGameObjectsWithTag("Item");

		foreach (GameObject item in allItems) 
		{
			PlayerPrefs.SetInt("item" + item.GetInstanceID() + "_exist", 1);
		}

		HideSaveDialogUI();

	}


	public void LoadGame()
	{
		//Wczytaj dane gracza
		GameObject player = GameObject.FindWithTag ("Player");

		Vector3 playerPos = new Vector3 ();
		playerPos.x = PlayerPrefs.GetFloat ("player+posX", 0);
		playerPos.y = PlayerPrefs.GetFloat ("player+posY", 0);
		playerPos.z = PlayerPrefs.GetFloat ("player+posZ", 0);

		player.transform.position = playerPos;

		Quaternion playerRot = new Quaternion ();
		playerRot.x = PlayerPrefs.GetFloat ("player_rotX", 0);
		playerRot.y = PlayerPrefs.GetFloat ("player_rotY", 0);
		playerRot.z = PlayerPrefs.GetFloat ("player_rotZ", 0);

		player.transform.rotation = playerRot;

		PlayerAttribute playerStat = player.GetComponent<PlayerAttribute> ();

		playerStat.level = PlayerPrefs.GetInt ("player_level", 0);
		playerStat.healthPoint = PlayerPrefs.GetFloat ("player_healthPoint", 0);
		playerStat.manaPoint = PlayerPrefs.GetFloat ("player_manaPoint", 0);
		playerStat.attackDamage = PlayerPrefs.GetFloat ("player_attackDamage", 0);
		playerStat.specialAttackDamage = PlayerPrefs.GetFloat ("player_specialAttackDamage", 0);
		playerStat.defense = PlayerPrefs.GetFloat ("player_defense", 0);

		//Wczytaj dane kamery gracza
		GameObject gameCamera = GameObject.FindWithTag("MainCamera");

		Vector3 cameraPos = new Vector3 ();
		cameraPos.x = PlayerPrefs.GetFloat ("camera_posX", 0);
		cameraPos.y = PlayerPrefs.GetFloat ("camera_posY", 0);
		cameraPos.z = PlayerPrefs.GetFloat ("camera_posZ", 0);

		gameCamera.transform.position = cameraPos;

		Quaternion cameraRot = new Quaternion ();
		cameraRot.x = PlayerPrefs.GetFloat ("camera_rotX", 0);
		cameraRot.y = PlayerPrefs.GetFloat ("camera_rotY", 0);
		cameraRot.z = PlayerPrefs.GetFloat ("camera_rotZ", 0);

		gameCamera.transform.rotation = cameraRot;

		//Wczytaj dane potworow
		GameObject[] allMonsters = GameObject.FindGameObjectsWithTag("Monster");

		foreach (GameObject monster in allMonsters) 
		{
			if(PlayerPrefs.GetInt("monster" + monster.GetInstanceID() + "_alive", 0) == 0)
			{
				//Martwy potwor
				Destroy(monster);
			}
			else
			{
				Vector3 monsterPos = new Vector3();
				monsterPos.x = PlayerPrefs.GetFloat("monster" + monster.GetInstanceID() + "_posX", 0);
				monsterPos.y = PlayerPrefs.GetFloat("monster" + monster.GetInstanceID() + "_posY", 0);
				monsterPos.z = PlayerPrefs.GetFloat("monster" + monster.GetInstanceID() + "_posZ", 0);

				Quaternion monsterRot = new Quaternion();
				monsterRot.x = PlayerPrefs.GetFloat("monster" + monster.GetInstanceID() + "_rotX", 0);
				monsterRot.y = PlayerPrefs.GetFloat("monster" + monster.GetInstanceID() + "_rotY", 0);
				monsterRot.z = PlayerPrefs.GetFloat("monster" + monster.GetInstanceID() + "_rotZ", 0);

				EnemyAI enemyStat = monster.GetComponent<EnemyAI>();

				enemyStat.healthPoint = PlayerPrefs.GetFloat("monster" + monster.GetInstanceID() + "_healthPoint", 0);
			}
		}

		//Wczytanie danych z przedmiotow/ulepszen

		GameObject[] allItems = GameObject.FindGameObjectsWithTag("Item");

		foreach (GameObject item in allItems) 
		{
			if(PlayerPrefs.GetInt("item" + item.GetInstanceID() + "_exist", 0) == 0)
			{
				Destroy(item);
			}
		}
		
	}


}
