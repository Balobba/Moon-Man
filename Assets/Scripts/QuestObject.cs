using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour {

    public int questNumber;
    public QuestManager theQM;
    public bool isItemQuest;
    public string targetItem;

	// Use this for initialization
	void Start () {
        /*
        //TEMPORARY SOLUTION OF QUESTS
        for(int i = 0; i<theQM.quests.Length; i++)
        {
            theQM.quests[i].gameObject.SetActive(true);
            theQM.quests[i].StartQuest();
        }*/
		
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
