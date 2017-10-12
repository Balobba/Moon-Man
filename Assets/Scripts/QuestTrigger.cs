using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour { //This is a script that checks if quests are triggered, and sets the quests active


    private QuestManager theQM;
    public int questNumber;
    public bool startQuest;
    public bool endQuest;


	// Use this for initialization
	void Start () {
        theQM = FindObjectOfType<QuestManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (!theQM.questCompleted[questNumber])//if the quest is not already completed
            {
                if (startQuest && !theQM.quests[questNumber].gameObject.activeSelf) //checks if the quest is already active
                {
                    theQM.quests[questNumber].gameObject.SetActive(true);
                    theQM.quests[questNumber].StartQuest();
                    Debug.Log("STARTADE QUEST: " + questNumber);

                }

                if(endQuest && theQM.quests[questNumber].gameObject.activeSelf)
                {
                    Debug.Log("AVSLUTADE QUEST: " + questNumber);
                    theQM.quests[questNumber].gameObject.SetActive(false);
                    theQM.quests[questNumber].EndQuest();

                }

            }
            
        }
    }

}
