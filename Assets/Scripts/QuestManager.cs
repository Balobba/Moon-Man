using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

    public QuestObject[] quests; //An array of all questobjects
    public bool[] questCompleted;

    public string itemCollected;//A string to identify collected items (for quests)

	// Use this for initialization
	void Start () {
        questCompleted = new bool[quests.Length];
	}
	
	// Update is called once per frame
	void Update () {
		
        if(questCompleted.Length == quests.Length)
        {
            Debug.Log("GRATTIS PIERRE DU VANN!");

        }


	}
}
