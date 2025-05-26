using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipSelection : MonoBehaviour
{
    VideoEditorManager _videoEditorManager;

    void Start()
    {
        _videoEditorManager = GameObject.Find("Managers").transform.GetChild(2).GetComponent<VideoEditorManager>();
    }

    public void ClipSelected()
    {
        _videoEditorManager.selectedClip = gameObject;
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
