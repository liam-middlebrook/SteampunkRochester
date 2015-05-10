﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TestManager : MonoBehaviour {
	
	TwineImporter Twine;
	bool wasClicked;
	List<Interactable> interactables;
	//EmotionManager eM;
	TimeManager tM;
	//Inventory inv;
	string currentLevel;
	
	// Use this for initialization
	void Start () {
		/*GameObject testInteractable = new GameObject("BlackBox");
		testInteractable.AddComponent<SpriteRenderer> ();
		test = testInteractable.AddComponent<Interactable> ();
		test.SetName ("test", "test");*/
		Twine = GameObject.Find ("TwineImporter").GetComponent<TwineImporter> ();
		currentLevel = transform.parent.gameObject.name;
		//eM = new EmotionManager();
		tM = GameObject.Find("SystemManager").GetComponent<TimeManager>();
		//inv = new Inventory();
		//find interactables
		interactables = new List<Interactable>();
		var gs = GameObject.FindObjectsOfType<GameObject>();
		foreach(GameObject obj in gs)
		{
			var script = obj.GetComponent<Interactable>();
			if(script != null)
			{
				Debug.Log(script);
				interactables.Add(script);
			}
		}
	}

	void OnGUI()
	{
		Rect r = new Rect(0,0,Screen.width/10, Screen.height/10);
		r.x += r.width;
		r.y += r.height;
		if(GUI.Button(r, "Leave"))
		{
			Debug.Log(currentLevel);
			if(currentLevel == "Party_Night")
			{
				Object.Destroy(transform.parent.gameObject);
				Instantiate(Resources.Load("Prefabs/Locations/Canal_Day") as GameObject);
				currentLevel = "Canal_Day";
			}
			else if(currentLevel == "Canal_Day(Clone)")
			{
				//Destory current level
				Object.Destroy(transform.parent.gameObject);

				//load editor office
				Instantiate(Resources.Load("Prefabs/locations/Editor_Office_Day") as GameObject);
				currentLevel = "EditorOffice_First";
			}
			//otherwise, go back to map screen.
			else{
				Object.Destroy(transform.parent.gameObject);
				MarkerBhv.m_map.SetActive(true);
				MarkerBhv.mapUI.SetActive(true);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(tM.getDay() >= 2)
		{
			Object.Destroy(transform.parent.gameObject);
			Instantiate(Resources.Load("Prefabs/locations/EditorOffice_Final")as GameObject);
		}
		//Debug.Log (test.selected);
		/*foreach(Interactable test in interactables)
		{
			if (test.selected) 
			{
				if(!wasClicked)
				{
					if(Input.GetMouseButtonUp(0))
					{
						wasClicked = true;
					}
				}
				else if(Input.GetMouseButtonDown(0)){
					//Debug.Log ("you clicked the left mouse button");

					test.Progress();
				}
			}
		}*/
	}

	/*void OnMouseDown(){
		Debug.Log (test.selected);
		if(test.selected)
		{
			test.Progress();
		}
	}*/
}
