using System.Collections.Generic;
using UnityEngine;

public class VideoEditorManager : MonoBehaviour
{
    [SerializeField] List<GameObject> clipList = new();
    [SerializeField] List<GameObject> placementList = new();
    [SerializeField] List<Transform> clipSpawnPos = new();
    List<Transform> clipSpawnChecks = new();

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
}
