using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using JSJ_Library;
using Unity.VisualScripting;

public class UI_CharacterContentSlot : UI_Base
{
    private int _slotCount;
    private List<UI_CharacterSlot_Button> _characterSlots = new List<UI_CharacterSlot_Button>();

    public override bool Init()
    {
        if (base.Init() == false)
            return false;
        
        // characterSheet 총개수를 _slotCount에 저장한다.
        _slotCount = Managers.DataManager.ExcelData.characterSheet.Length;

        // characterSheet 총개수만큼 캐릭터 슬롯 프리팹을 가져온다. 
        for (int i = 0; i < _slotCount; ++i)
        {
            // 캐릭터 슬롯 프리팹 불러오기.
            GameObject loadSlotPrefab = Resources.Load(DefinePath.CharacterSlotPrefab) as GameObject;
            GameObject characterSlot = PrefabUtility.InstantiatePrefab(loadSlotPrefab) as GameObject;
            
            // 1.각각의 캐릭터 슬롯 프리팹을 해당 스크립트가 있는 오브젝트 하위로 이동
            // 2._characterSlots 리스트에 추가
            // 3.초기화 진행
            if (characterSlot != null)
            {
                characterSlot.transform.SetParent(this.transform);
                _characterSlots.Add(characterSlot.GetComponent<UI_CharacterSlot_Button>());
                _characterSlots[i].Initialization(i);
            }
        }

        return true;
    }

    public void OnClickSlotDefaultAscendButton()
    {
        GameObject[] childrens = new GameObject[this.transform.childCount];

        for (int i = 0; i < this.transform.childCount; i++)
        {
            childrens[i] = this.transform.GetChild(i).gameObject;
        }
        
        // 정렬
        childrens = childrens.OrderBy(slot => slot.GetComponent<UI_CharacterSlot_Button>().ID).ToArray();

        for (int i = 0; i < childrens.Length; i++)
        {
            childrens[i].transform.SetSiblingIndex(i);
        }
    }
    
    public void OnClickSlotDefaultDescendButton()
    {
        GameObject[] childrens = new GameObject[this.transform.childCount];

        for (int i = 0; i < this.transform.childCount; i++)
        {
            childrens[i] = this.transform.GetChild(i).gameObject;
        }
        
        // 정렬
        childrens = childrens.OrderByDescending(slot => slot.GetComponent<UI_CharacterSlot_Button>().ID).ToArray();

        for (int i = 0; i < childrens.Length; i++)
        {
            childrens[i].transform.SetSiblingIndex(i);
        }
    }

    public void OnClickSlotNameAscendSortButton()
    {
        GameObject[] childrens = new GameObject[this.transform.childCount];

        for (int i = 0; i < this.transform.childCount; i++)
        {
            childrens[i] = this.transform.GetChild(i).gameObject;
        }
        
        // 정렬
        childrens = childrens.OrderBy(slot => slot.GetComponent<UI_CharacterSlot_Button>().FullName).ToArray();

        for (int i = 0; i < childrens.Length; i++)
        {
            childrens[i].transform.SetSiblingIndex(i);
        }
    }

    public void OnClickSlotNameDescendSortButton()
    {
        GameObject[] childrens = new GameObject[this.transform.childCount];

        for (int i = 0; i < this.transform.childCount; i++)
        {
            childrens[i] = this.transform.GetChild(i).gameObject;
        }
        
        // 정렬
        childrens = childrens.OrderByDescending(slot => slot.GetComponent<UI_CharacterSlot_Button>().FullName).ToArray();

        for (int i = 0; i < childrens.Length; i++)
        {
            childrens[i].transform.SetSiblingIndex(i);
        }
    }
    
    public void OnClickSlotRankAscendSortButton()
    {
        GameObject[] childrens = new GameObject[this.transform.childCount];

        for (int i = 0; i < this.transform.childCount; i++)
        {
            childrens[i] = this.transform.GetChild(i).gameObject;
        }
        
        // 정렬
        childrens = childrens.OrderBy(slot => (int)slot.GetComponent<UI_CharacterSlot_Button>().RankID).ToArray();

        for (int i = 0; i < childrens.Length; i++)
        {
            childrens[i].transform.SetSiblingIndex(i);
        }
    }

    public void OnClickSlotRankDescendSortButton()
    {
        GameObject[] childrens = new GameObject[this.transform.childCount];

        for (int i = 0; i < this.transform.childCount; i++)
        {
            childrens[i] = this.transform.GetChild(i).gameObject;
        }
        
        // 정렬
        childrens = childrens.OrderByDescending(slot => (int)slot.GetComponent<UI_CharacterSlot_Button>().RankID).ToArray();

        for (int i = 0; i < childrens.Length; i++)
        {
            childrens[i].transform.SetSiblingIndex(i);
        }
    }
}
