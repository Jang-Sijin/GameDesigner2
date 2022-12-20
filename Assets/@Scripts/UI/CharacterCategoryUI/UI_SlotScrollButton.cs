using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UI_SlotScrollButton : MonoBehaviour
{
    private Scrollbar _scrollbarHorizontal;
    private Button _rightScrollButton;
    private Button _middleScrollButton;
    private Button _leftScrollButton;

    private float durationTime = 1.5f;
    
    private float scrollMinValue = 0f;
    private float scrollMiddleValue = 0.5f;
    private float scrollMaxValue = 1f;
    
    void Start()
    {
        Init();
    }

    void Init()
    {
        _scrollbarHorizontal = transform.Find("Scrollbar Horizontal").GetComponent<Scrollbar>();
        
        _rightScrollButton = GameObject.Find("RightScroll_Button").gameObject.GetComponent<Button>();
        _middleScrollButton = GameObject.Find("MiddleScroll_Button").gameObject.GetComponent<Button>();
        _leftScrollButton = GameObject.Find("LeftScroll_Button").gameObject.GetComponent<Button>();
        
        
        // AddListener 이벤트 등록
        _rightScrollButton.GetComponent<Button>().onClick.AddListener(OnClickRightScrollButton);
        _middleScrollButton.GetComponent<Button>().onClick.AddListener(OnClickMiddleScrollButton);
        _leftScrollButton.GetComponent<Button>().onClick.AddListener(OnClickLeftScrollButton);
    }

    public void OnClickRightScrollButton()
    {
        DOTween.To(() => _scrollbarHorizontal.value, value => _scrollbarHorizontal.value = value, scrollMaxValue, durationTime).SetEase(Ease.OutQuad);
    }
    
    public void OnClickMiddleScrollButton()
    {
        DOTween.To(() => _scrollbarHorizontal.value, value => _scrollbarHorizontal.value = value, scrollMiddleValue, durationTime).SetEase(Ease.OutQuad);
    }
    
    public void OnClickLeftScrollButton()
    {
        DOTween.To(() => _scrollbarHorizontal.value, value => _scrollbarHorizontal.value = value, scrollMinValue, durationTime).SetEase(Ease.OutQuad);
    }
}
