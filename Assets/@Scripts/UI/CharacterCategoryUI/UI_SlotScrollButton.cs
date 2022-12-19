using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SlotScrollButton : MonoBehaviour
{
    private Scrollbar scrollbarHorizontal;
    private Button rightScrollButton;
    private Button middleScrollButton;
    private Button leftScrollButton;
    void Start()
    {
        Init();
    }

    void Init()
    {
        scrollbarHorizontal = transform.Find("Scrollbar Horizontal").GetComponent<Scrollbar>();
        
        rightScrollButton = GameObject.Find("RightScroll_Button").gameObject.GetComponent<Button>();
        middleScrollButton = GameObject.Find("MiddleScroll_Button").gameObject.GetComponent<Button>();
        leftScrollButton = GameObject.Find("LeftScroll_Button").gameObject.GetComponent<Button>();
        
        
        // AddListener 이벤트 등록
        rightScrollButton.GetComponent<Button>().onClick.AddListener(OnClickRightScrollButton);
        middleScrollButton.GetComponent<Button>().onClick.AddListener(OnClickMiddleScrollButton);
        leftScrollButton.GetComponent<Button>().onClick.AddListener(OnClickLeftScrollButton);
    }

    public void OnClickRightScrollButton()
    {
        scrollbarHorizontal.value = 1f;
    }
    
    public void OnClickMiddleScrollButton()
    {
        scrollbarHorizontal.value = 0.5f;
    }
    
    public void OnClickLeftScrollButton()
    {
        scrollbarHorizontal.value = 0f;
    }
}
