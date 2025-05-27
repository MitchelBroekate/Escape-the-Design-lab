using UnityEngine;
using UnityEngine.Video;

public class ClipSelection : MonoBehaviour
{
    VideoEditorManager _videoEditorManager;

    [SerializeField]
    VideoPlayer videoPlayer;

    void Start()
    {
        _videoEditorManager = GameObject.Find("Managers").transform.GetChild(2).GetComponent<VideoEditorManager>();
    }

    public void ClipSelected()
    {
        _videoEditorManager.selectedClip = gameObject;
        videoPlayer.Play();
    }
}
