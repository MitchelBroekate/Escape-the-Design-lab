using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoEditorManager : MonoBehaviour
{
    [SerializeField] List<GameObject> clipList = new();
    [SerializeField] List<GameObject> placementList = new();
    [SerializeField] List<Transform> clipSpawnPos = new();
    List<Transform> clipSpawnChecks = new();
    List<GameObject> clipFinishedList = new();

    [SerializeField]
    Transform clipFinishedParent;

    public GameObject selectedClip;
    public int clipsPlaced = 0;

    //Clips get put in a random order.
    void Start()
    {
        SetClipSpawnPlacements();
    }

    void SetClipSpawnPlacements()
    {
        foreach (Transform spawnPos in clipSpawnPos)
        {
            clipSpawnChecks.Add(spawnPos);
        }

        foreach (GameObject clip in clipList)
        {
            int randomSpawnPos = Random.Range(0, clipSpawnChecks.Count);

            GameObject currentClip = Instantiate(clip, clipSpawnChecks[randomSpawnPos], false);

            clipSpawnChecks.RemoveAt(randomSpawnPos);
        }
    }

    public void CheckClipsPlaced()
    {
        if (clipsPlaced == 3)
        {
            //check if clips are in the right place
            foreach (Transform clipParent in clipSpawnPos)
            {
                ClipSelection currentClipValues = clipParent.GetChild(0).gameObject.GetComponent<ClipSelection>();

                //play video in order that was chosen

                PlayClipsInOrder();


                //if wrong reset vars
                if (currentClipValues.ClipPos != currentClipValues.ClipValue)
                {
                    clipsPlaced = 0;

                    foreach (Transform parentObject in clipSpawnPos)
                    {
                        Destroy(parentObject.GetChild(0).gameObject);
                    }

                    foreach (GameObject placementButton in placementList)
                    {
                        placementButton.gameObject.SetActive(true);
                    }

                    SetClipSpawnPlacements();

                    //Lose fx
                }
                else
                {
                    //wincondition
                    //win fx
                }
            }
        }
    }

    void PlayClipsInOrder()
    {
        foreach (Transform parent in clipSpawnPos)
        {
            ClipSelection currentClipSelection = parent.GetChild(0).gameObject.GetComponent<ClipSelection>();

            clipFinishedList.Insert(currentClipSelection.ClipValue, parent.GetChild(0).gameObject);
        }

        StartCoroutine(clipFinishedPlay());
    }

    IEnumerator clipFinishedPlay()
    {
        foreach (GameObject clips in clipFinishedList)
        {
            

            yield return new WaitForSeconds(1);    
        }
    }
}
