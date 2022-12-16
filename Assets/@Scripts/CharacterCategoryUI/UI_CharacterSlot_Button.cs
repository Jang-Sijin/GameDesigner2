using System;
using System.Collections.Generic;
using System.Linq;
using JSJ_Library;
using TMPro;
using Unity.VisualScripting;
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
    public string FullName;
    public RankCategory RankID;
    private const int abilitySize = 6;
    
    [SerializeField] private CharacterImageSlot _characterImageSlot;
    [SerializeField] private CharacterRankSlot _characterRankSlot;

    [SerializeField] private Image _fullCharacterImage;
    [SerializeField] private Image _attributeImage;
    [SerializeField] private Image _rankImage;
    [SerializeField] private Image[] _abilitys = new Image[abilitySize];
    [SerializeField] private TextMeshProUGUI _fullNameText;
    [SerializeField] private TextMeshProUGUI _attributeText;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _levelText;

    private void OnValidate()
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

        for (int i = 0; i < abilitySize; i++)
        {
            _abilitys[i] = GameObject.Find("Ability_Image" + $"{i+1}").GetComponent<Image>();
        }
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        //BindButton(typeof(Buttons));

        //GetButton((int) Buttons.Slot_Button).gameObject.BindEvent(() => { OnClickSlotButton(); });
        
        return true;
    }

    public void Initialization(int slotNumber)
    {
        ID = slotNumber;
        FullName = Managers.DataManager.ExcelData.characterSheet[ID].fullName;
        RankID = Managers.DataManager.ExcelData.characterSheet[ID].rankId;
        
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
        
        for (int i = 0; i < abilitySize; i++)
        {
            string abilityImageName = Managers.DataManager.ExcelData.abilitySheet.First(entity => Managers.DataManager.GetCharacterSheetAbilityId(ID, i+1) == entity.abilityId).imageName;
            // Debug.Log(abilityImageName);
            _abilitys[i].sprite =  Resources.Load<Sprite>($"{DefinePath.AbilityFolderPath + abilityImageName}") as Sprite;
            
            bool isActive = Managers.DataManager.GetCharacterSheetAbilityId(ID, i+1) != 0;
            _abilitys[i].gameObject.SetActive(isActive);
        }
    }
    #endregion
}