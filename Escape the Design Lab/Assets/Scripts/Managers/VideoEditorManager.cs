using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoEditorManager : MonoBehaviour
{
    [SerializeField] List<GameObject> clipList = new();
    [SerializeField] List<Transform> clipSpawnPos = new();

    public GameObject selectedClip;
    public GameObject selectedPlacement;

    //Clips get put in a random order.
    void Start()
    {
        foreach (GameObject clip in clipList)
        {
            int randomSpawnPos = Random.Range(0, clipSpawnPos.Count);

            Instantiate(clip, clipSpawnPos[randomSpawnPos]);

            clipSpawnPos.RemoveAt(randomSpawnPos);
        }
    }
}
