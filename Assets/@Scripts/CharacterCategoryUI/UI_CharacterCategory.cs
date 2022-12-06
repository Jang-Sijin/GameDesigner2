using UnityEngine;
using UnityEngine.UI;
using JSJ_Library;

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
        
        string charFullImageName = Managers.DataManager.ExcelData.characterSheet[Managers.DataManager.ExcelData.characterSheet.Count - 1].characterFull2DImageName;
        _characterFullImage.sprite = Resources.Load<Sprite>(DefinePath.CharacterFull2DFolderPath + charFullImageName) as Sprite;
    }
}
