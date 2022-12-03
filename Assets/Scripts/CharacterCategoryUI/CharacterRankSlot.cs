using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CharacterRankSlot : MonoBehaviour
{
    private Image _slotCharacterRankImage;
    
    void Awake()
    {
        _slotCharacterRankImage = GetComponent<Image>();
    }

    public void Init(int slotNumber)
    {
        // DB에서 slotNumber번째 슬롯의 랭크ID를 가져온다.
        RankCategory characterRandId = DBManager.Instance.DB.characterSheet[slotNumber].rankId;
        // DB에서 characterSheet 랭크ID로 RankSheet 랭크의 이름을 가져온다.
        var rankImageName = DBManager.Instance.DB.rankSheet.Where(iter => iter.rankId == characterRandId).First().imageName;
        
        // Debug.Log($"{rankImageName}");
        // 랭크 이미지 가져오기.
        _slotCharacterRankImage.sprite = Resources.Load<Sprite>(Define.RankFolderPath + rankImageName) as Sprite;
    }
}
