using DG.Tweening;
using UnityEngine;

public class UI_SelectSortingDotween : MonoBehaviour
{
    private RectTransform _rectTransform;
    private Transform _particleGameObject;

    private Vector2 canvasSize;

    void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _particleGameObject = GameObject.Find("FlowerParticle").GetComponent<Transform>();
        canvasSize = GameObject.Find("@UI_Root").gameObject.GetComponent<Canvas>().renderingDisplaySize;
    }


    public void OnOpenUI()
    {
        Vector2 GetcanvasSize = canvasSize;
        GetcanvasSize.x *= -1;
        GetcanvasSize.y = 0;
        
        // 1. 정렬 UI Active 활성화
        _rectTransform.gameObject.SetActive(true);
        
        // 2. 정렬 UI 오른쪽으로 이동 (열기)
        // Vector2 vector2 = new Vector2(-1920, 0);
        _rectTransform.anchoredPosition = GetcanvasSize;
        _rectTransform.DOAnchorPosX(0, 1f).SetEase(Ease.OutQuad);
        
        // 3. 파티클 오브젝트 Z축 이동
        _particleGameObject.transform.DOMoveZ(-20, 2f).SetEase(Ease.OutQuad);
    }

    public void OnCloseUI()
    {
        Vector2 GetcanvasSize = canvasSize;
        GetcanvasSize.y = 0;
        
        // 1. 정렬 UI 오른쪽으로 이동 (닫기)
        _rectTransform.DOAnchorPosX(GetcanvasSize.x, 1f).SetEase(Ease.OutQuad).OnComplete(() => { _rectTransform.gameObject.SetActive(false); });
        
        // 2. 파티클 오브젝트 Z축 이동
        _particleGameObject.transform.DOMoveZ(0, 2f).SetEase(Ease.OutQuad);
    }
}
