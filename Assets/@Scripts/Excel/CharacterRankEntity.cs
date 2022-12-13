[System.Serializable]
public class CharacterRankEntity
{
    public RankCategory rankId;
    public string imageName;
}

public enum RankCategory
{
    B = 0,
    A = 1,
    S = 2,
}
