using UnityEngine;

public class UI_CharacterSlot : MonoBehaviour
{
    [SerializeField] private CharacterImageSlot _characterImageSlot;
    [SerializeField] private CharacterRankSlot _characterRankSlot;
    
    void Start()
    {
        _characterImageSlot = GetComponentInChildren<CharacterImageSlot>(true);
        _characterRankSlot = GetComponentInChildren<CharacterRankSlot>(true);
    }

    public void Init(int slotNumber)
    {
        // 캐릭터 슬롯 이미지 초기화
        if(_characterImageSlot != null)
            _characterImageSlot.Init(slotNumber);
        
        // 캐릭터 슬롯 랭크 이미지 초기화
        if(_characterRankSlot != null)
            _characterRankSlot.Init(slotNumber);
    }
}