using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour {

    public int questNumber;
    private QuestManager theQM;
    public string itemName;

    public GameObject itemCollectEffect;

    public GameObject greenLight;
    public GameObject redLight;
    public GameObject greenLightDoor;
    public GameObject redLightDoor;

    // Use this for initialization
    void Start () {
        theQM = FindObjectOfType<QuestManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("INNE I TRIGGER");
        if(other.gameObject.tag == "Player")
        {
            if (!theQM.questCompleted[questNumber])
            {
                if (theQM.quests[questNumber].gameObject.activeSelf)
                {
                    theQM.itemCollected = itemName;
                    gameObject.SetActive(false);
                    Debug.Log("PLOCKADE UPP ITEM");

                    Instantiate(itemCollectEffect, transform.position, transform.rotation);//particle effect when picking up item

                    //Colors in spaceship that indicated successful retreat of item
                    greenLight.gameObject.SetActive(true);
                    greenLightDoor.gameObject.SetActive(true);
                    redLight.gameObject.SetActive(false);
                    redLightDoor.gameObject.SetActive(false);



                }
            }

        }

    }
}
