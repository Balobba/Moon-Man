using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour { //This script is to check if each quest item is active or has been completed

    public int questNumber;
    public QuestManager theQM;
    public bool isItemQuest;
    public string targetItem;

	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
        if (isItemQuest)
        {
            if(theQM.itemCollected == targetItem)
            {
                theQM.itemCollected = null;
                EndQuest();

            }
        }

	}

    public void StartQuest()
    {
        Debug.Log("startade quest");

    }


    public void EndQuest()
    {
        Debug.Log("avslutade quest!");
        theQM.questCompleted[questNumber] = true;
        gameObject.SetActive(false);

    }

}
