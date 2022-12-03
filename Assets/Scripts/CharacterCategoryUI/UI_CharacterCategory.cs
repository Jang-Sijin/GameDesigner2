using System;
using UnityEngine;
using UnityEngine.UI;

public class UI_CharacterCategory : MonoBehaviour
{
    [SerializeField] private Image _characterFullImage;
    [SerializeField] private UI_CharacterContentSlot _characterContentSlot;

    private void OnValidate()
    {
        _characterContentSlot = GetComponentInChildren<UI_CharacterContentSlot>();
    }

    private void Start()
    {
        Initialized();
    }

    private void Initialized()
    {
        // _characterContentSlot 초기화
        _characterContentSlot.Init();

        // DB character Sheet 마지막 행의 Full 2D 이미지를 _characterFullImage에 불러온다.
        string charFullImageName = DBManager.Instance.DB.characterSheet[DBManager.Instance.DB.characterSheet.Count - 1].characterFull2DImageName;
        _characterFullImage.sprite = Resources.Load<Sprite>(Define.CharacterFull2DFolderPath + charFullImageName) as Sprite;
    }
}
