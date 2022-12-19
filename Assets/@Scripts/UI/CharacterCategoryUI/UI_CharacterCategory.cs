using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using JSJ_Library;
using TMPro;

public class UI_CharacterCategory : UI_Scene
{
    enum Buttons
    {
        UI_CharacterSlot_Button
    }
    private const int abilitySize = 6;
    
    [SerializeField] private Image _characterFullImage;
    [SerializeField] private Image _attributeImage;
    [SerializeField] private Image _rankImage;
    [SerializeField] private Image[] _abilitys = new Image[abilitySize];
    [SerializeField] private TextMeshProUGUI _fullNameText;
    [SerializeField] private TextMeshProUGUI _attributeText;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private UI_CharacterContentSlot _characterContentSlot;

    private void OnValidate()
    {
        _characterContentSlot = GetComponentInChildren<UI_CharacterContentSlot>();
        _attributeImage = GameObject.Find("Attribute_Image").GetComponent<Image>();
        _rankImage = GameObject.Find("Rank_Image").GetComponent<Image>();
        _fullNameText = GameObject.Find("FullName_Text").GetComponent<TextMeshProUGUI>();
        _attributeText = GameObject.Find("Attribute_Text").GetComponent<TextMeshProUGUI>();
        _nameText = GameObject.Find("Name_Text").GetComponent<TextMeshProUGUI>();
        _levelText = GameObject.Find("Level_Text").GetComponent<TextMeshProUGUI>();
//
        for (int i = 0; i < abilitySize; i++)
        {
            _abilitys[i] = GameObject.Find("Ability_Image" + $"{i+1}").GetComponent<Image>();
        }
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;
        
        BindButton(typeof(Buttons));
        
        //GetButton((int)Buttons.UI_CharacterSlot_Button).gameObject.BindEvent(OnClickCharacterSlotButton);

        return true;
    }

    private void Start()
    {
        Initialized();
    }

    private void Initialized()
    {
        // _characterContentSlot 초기화
        _characterContentSlot.Init();
        
        // DB character Sheet 마지막 행의 데이터 리소스를 불러온다. (아스카)
        ShowLastSlotData();
    }
    
    private void ShowLastSlotData()
    {
        int lastSlotID = Managers.DataManager.ExcelData.characterSheet.Count - 1;
        
        string charFullImageName = Managers.DataManager.ExcelData.characterSheet[lastSlotID].characterFull2DImageName;
        _characterFullImage.sprite = Resources.Load<Sprite>(DefinePath.CharacterFull2DFolderPath + charFullImageName) as Sprite;
        
        string attributeImageName = Managers.DataManager.ExcelData.attributeSheet.First(entity => Managers.DataManager.ExcelData.characterSheet[lastSlotID].attributeId == entity.attributeId).imageName;
        _attributeImage.sprite = Resources.Load<Sprite>($"{DefinePath.AttributeFolderPath + attributeImageName}") as Sprite;
        
        string rankImageName = Managers.DataManager.ExcelData.rankSheet.First(entity => Managers.DataManager.ExcelData.characterSheet[lastSlotID].rankId == entity.rankId).imageName;
        _rankImage.sprite = Resources.Load<Sprite>($"{DefinePath.RankFolderPath + rankImageName}") as Sprite;
        
        _fullNameText.text = Managers.DataManager.ExcelData.characterSheet[lastSlotID].fullName;
        _attributeText.text = Managers.DataManager.ExcelData.attributeSheet.First(entity => Managers.DataManager.ExcelData.characterSheet[lastSlotID].attributeId == entity.attributeId).name;
        _nameText.text = Managers.DataManager.ExcelData.characterSheet[lastSlotID].name;
        _levelText.text = $"LV.1";
        
        for (int i = 0; i < abilitySize; i++)
        {
            string abilityImageName = Managers.DataManager.ExcelData.abilitySheet.First(entity => Managers.DataManager.GetCharacterSheetAbilityId(lastSlotID,i+1) == entity.abilityId).imageName;
            _abilitys[i].sprite =  Resources.Load<Sprite>($"{DefinePath.AbilityFolderPath + abilityImageName}") as Sprite;
            
            bool isActive = Managers.DataManager.GetCharacterSheetAbilityId(lastSlotID,i+1) != 0;
            _abilitys[i].gameObject.SetActive(isActive);
        }
    }

    #region EventHandler
    void OnClickCharacterSlotButton()
    {
        
    }
    #endregion
}
