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
    public string FullName;
    public RankCategory RankID;
    
    [SerializeField] private CharacterImageSlot _characterImageSlot;
    [SerializeField] private CharacterRankSlot _characterRankSlot;

    [SerializeField] private Image _fullCharacterImage;
    [SerializeField] private Image _attributeImage;
    [SerializeField] private Image _rankImage;
    [SerializeField] private Image _abilitys1;
    [SerializeField] private Image _abilitys2;
    [SerializeField] private Image _abilitys3;
    [SerializeField] private Image _abilitys4;
    [SerializeField] private Image _abilitys5;
    [SerializeField] private Image _abilitys6;
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
        
        _abilitys1 = GameObject.Find("Ability_Image1").GetComponent<Image>();
        _abilitys2 = GameObject.Find("Ability_Image2").GetComponent<Image>();
        _abilitys3 = GameObject.Find("Ability_Image3").GetComponent<Image>();
        _abilitys4 = GameObject.Find("Ability_Image4").GetComponent<Image>();
        _abilitys5 = GameObject.Find("Ability_Image5").GetComponent<Image>();
        _abilitys6 = GameObject.Find("Ability_Image6").GetComponent<Image>();
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

        string abilityImageName = Managers.DataManager.ExcelData.abilitySheet.First(entity => Managers.DataManager.ExcelData.characterSheet[ID].abilityId1 == entity.abilityId).imageName;
        _abilitys1.sprite =  Resources.Load<Sprite>($"{DefinePath.AbilityFolderPath + abilityImageName}") as Sprite;
        abilityImageName = Managers.DataManager.ExcelData.abilitySheet.First(entity => Managers.DataManager.ExcelData.characterSheet[ID].abilityId2 == entity.abilityId).imageName;
        _abilitys2.sprite =  Resources.Load<Sprite>($"{DefinePath.AbilityFolderPath + abilityImageName}") as Sprite;
        abilityImageName = Managers.DataManager.ExcelData.abilitySheet.First(entity => Managers.DataManager.ExcelData.characterSheet[ID].abilityId3 == entity.abilityId).imageName;
        _abilitys3.sprite =  Resources.Load<Sprite>($"{DefinePath.AbilityFolderPath + abilityImageName}") as Sprite;
        abilityImageName = Managers.DataManager.ExcelData.abilitySheet.First(entity => Managers.DataManager.ExcelData.characterSheet[ID].abilityId4 == entity.abilityId).imageName;
        _abilitys4.sprite =  Resources.Load<Sprite>($"{DefinePath.AbilityFolderPath + abilityImageName}") as Sprite;
        abilityImageName = Managers.DataManager.ExcelData.abilitySheet.First(entity => Managers.DataManager.ExcelData.characterSheet[ID].abilityId5 == entity.abilityId).imageName;
        _abilitys5.sprite =  Resources.Load<Sprite>($"{DefinePath.AbilityFolderPath + abilityImageName}") as Sprite;
        abilityImageName = Managers.DataManager.ExcelData.abilitySheet.First(entity => Managers.DataManager.ExcelData.characterSheet[ID].abilityId6 == entity.abilityId).imageName;
        _abilitys6.sprite =  Resources.Load<Sprite>($"{DefinePath.AbilityFolderPath + abilityImageName}") as Sprite;

        if (Managers.DataManager.ExcelData.characterSheet[ID].abilityId1 == 0)
        {
            _abilitys1.gameObject.SetActive(false);
        }
        else
        {
            _abilitys1.gameObject.SetActive(true);
        }
        
        if (Managers.DataManager.ExcelData.characterSheet[ID].abilityId2 == 0)
        {
            _abilitys2.gameObject.SetActive(false);
        }
        else
        {
            _abilitys2.gameObject.SetActive(true);
        }
        
        if (Managers.DataManager.ExcelData.characterSheet[ID].abilityId3 == 0)
        {
            _abilitys3.gameObject.SetActive(false);
        }
        else
        {
            _abilitys3.gameObject.SetActive(true);
        }
        
        if (Managers.DataManager.ExcelData.characterSheet[ID].abilityId4 == 0)
        {
            _abilitys4.gameObject.SetActive(false);
        }
        else
        {
            _abilitys4.gameObject.SetActive(true);
        }
        
        if (Managers.DataManager.ExcelData.characterSheet[ID].abilityId5 == 0)
        {
            _abilitys5.gameObject.SetActive(false);
        }
        else
        {
            _abilitys5.gameObject.SetActive(true);
        }
        
        if (Managers.DataManager.ExcelData.characterSheet[ID].abilityId6 == 0)
        {
            _abilitys6.gameObject.SetActive(false);
        }
        else
        {
            _abilitys6.gameObject.SetActive(true);
        }
    }
    #endregion
}