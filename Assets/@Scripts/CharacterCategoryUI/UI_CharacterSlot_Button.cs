using System;
using System.Linq;
using JSJ_Library;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class UI_CharacterSlot_Button : UI_Base
{
    enum Buttons
    {
        Slot_Button
    }
    
    enum Images
    {
        Attribute_Image,
        Rank_Image
    }

    enum TextMeshPros
    {
        FullName_Text,
        Attribute_Text,
        Name_Text,
        Level_Text
    }

    public int ID;
    [SerializeField] private CharacterImageSlot _characterImageSlot;
    [SerializeField] private CharacterRankSlot _characterRankSlot;

    [SerializeField] private Image _fullCharacterImage;
    [SerializeField] private Image _attributeImage;
    [SerializeField] private Image _rankImage;
    [SerializeField] private TextMeshProUGUI _fullNameText;
    [SerializeField] private TextMeshProUGUI _attributeText;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _levelText;
    
    void Start()
    {
        _characterImageSlot = GetComponentInChildren<CharacterImageSlot>(true);
        _characterRankSlot = GetComponentInChildren<CharacterRankSlot>(true);

        _fullCharacterImage = GameObject.Find("UI_CharacterFull_Image").GetComponent<Image>(); 
        _attributeImage = GameObject.Find("Attribute_Image").GetComponent<Image>();
        _rankImage = GameObject.Find("Rank_Image").GetComponent<Image>();
        _fullNameText = GameObject.Find("FullName_Text").GetComponent<TextMeshProUGUI>();
        _attributeText = GameObject.Find("Attribute_Text").GetComponent<TextMeshProUGUI>();
        _nameText = GameObject.Find("Name_Text").GetComponent<TextMeshProUGUI>();
        _levelText = GameObject.Find("Level_Text").GetComponent<TextMeshProUGUI>();
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindButton(typeof(Buttons));

        GetButton((int)Buttons.Slot_Button).gameObject.BindEvent(() => { OnClickSlotButton(); });
        
        return true;
    }

    public void Initialization(int slotNumber)
    {
        ID = slotNumber;
        
        // 캐릭터 슬롯 이미지 초기화
        if(_characterImageSlot != null)
            _characterImageSlot.Init(slotNumber);
        
        // 캐릭터 슬롯 랭크 이미지 초기화
        if(_characterRankSlot != null)
            _characterRankSlot.Init(slotNumber);
        
    }
    
    #region EventHandler
    public void OnClickSlotButton()
    {
        string fullCharacterImageName = Managers.DataManager.ExcelData.characterSheet[ID].characterFull2DImageName;
        _fullCharacterImage.sprite = Resources.Load<Sprite>($"{DefinePath.CharacterFull2DFolderPath + fullCharacterImageName}") as Sprite;
        
        string attributeImageName = Managers.DataManager.ExcelData.attributeSheet.First(entity => Managers.DataManager.ExcelData.characterSheet[ID].attributeId == entity.attributeId).imageName;
        _attributeImage.sprite = Resources.Load<Sprite>($"{DefinePath.AttributeFolderPath + attributeImageName}") as Sprite;
        
        string rankImageName = Managers.DataManager.ExcelData.rankSheet.First(entity => Managers.DataManager.ExcelData.characterSheet[ID].rankId == entity.rankId).imageName;
        _rankImage.sprite = Resources.Load<Sprite>($"{DefinePath.RankFolderPath + rankImageName}") as Sprite;
        
        _fullNameText.text = Managers.DataManager.ExcelData.characterSheet[ID].fullName;
        _attributeText.text = Managers.DataManager.ExcelData.attributeSheet.First(entity => Managers.DataManager.ExcelData.characterSheet[ID].attributeId == entity.attributeId).name;
        _nameText.text = Managers.DataManager.ExcelData.characterSheet[ID].name;
        _levelText.text = $"LV.1";
    }
    #endregion
}