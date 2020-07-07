using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ChroiceButton : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    private RawImage rawImage;
    public GameObject ChoicePanel;
    // Start is called before the first frame update
    void Start()
    {

        //获取场景中对应的组件
        videoPlayer = this.GetComponent<VideoPlayer>();
        rawImage = this.GetComponent<RawImage>();
        videoPlayer.loopPointReached += EndVideoEvent;
        ChoicePanel.SetActive(false);
    }

    void OnEnable()
    {
        
    }


    // Update is called once per frame

    void Update()
    {

        //如果videoPlayer没有对应的视频texture，则返回
        if (videoPlayer.texture == null)
        {

            return;

        }

        //把VideoPlayerd的视频渲染到UGUI的RawImage

        rawImage.texture = videoPlayer.texture;

    }


    void EndVideoEvent(VideoPlayer video)
    {
        //在视频结束时会调用这个函数
        ChoicePanel.SetActive(true);
    }


    //切换选项
    public void VideoSwitchButtonClicked(VideoClip clip_to_play)
    {
        //播放音频
        videoPlayer.clip = clip_to_play;
        videoPlayer.Play();
        ChoicePanel.SetActive(false);
    }


    //暂停video
    public void VideoPause()
    {
        videoPlayer.Pause();
    }


    //播放video
    public void VideoPlay()
    {
        videoPlayer.Play();
    }

}
