using JSJ_Library;
using UnityEngine;
using UnityEngine.UI;

public class CharacterImageSlot : MonoBehaviour
{
    private Image _slotCharacterImage;
    
    void Awake()
    {
        _slotCharacterImage = GetComponent<Image>();
    }

    public void Init(int slotNumber)
    {
        // DB에서 slotNumber번째 슬롯의 캐릭터 슬롯 이미지 이름을 가져온다.
        string slot2DImageName = Managers.DataManager.ExcelData.characterSheet[slotNumber].slot2DImageName;
        // Debug.Log($"{slot2DImageName}");
        
        // 캐릭터 슬롯 이미지 가져오기.
        _slotCharacterImage.sprite = Resources.Load<Sprite>($"{DefinePath.Slot2DFolderPath + slot2DImageName}") as Sprite;
    }
}
