using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoEditorManager : MonoBehaviour
{
    //select a clip and save it.
    [SerializeField]
    Transform clipParent;
    List<GameObject> videoClips = new();
    List<Vector3> ClipStartpos = new();
    List<Transform> clipPlacements = new();

    int clip1, clip2, clip3;

    GameObject _currentClip;

    void Start()
    {
        videoClips.Clear();

        for (int i = 0; i < clipParent.childCount; i++)
        {
            videoClips.Add(clipParent.GetChild(i).gameObject);
        }

        if (videoClips != null)
        {
            foreach (GameObject clip in videoClips)
            {
                ClipStartpos.Add(clip.transform.position);
            }
        }
        else
        {
            Debug.LogWarning("List videoClips is empty");
        }

    }

    public void ChangeSelectedClip(int currentClip)
    {
        _currentClip = videoClips[currentClip];
    }

    //place the selected clip on buttons position.
    public void PlaceSelectedClip(int currentPlacement)
    {
        if (_currentClip != null)
        {
            _currentClip.transform.position = clipPlacements[currentPlacement].position;
            clipPlacements[currentPlacement].gameObject.SetActive(false);

            _currentClip = null;
            _currentClip.GetComponent<Button>().enabled = false;

        }
    }

    //give clip objects random videos and corresponding value

    //if clip values are correct (show code piece).
    //reset buttons.
    //play video clip on selection.
    //reset video clip if deselected.
}
