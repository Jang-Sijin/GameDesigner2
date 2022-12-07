using System.Collections;

public class CharacterInfoScene : BaseScene
{
    protected override bool Init()
    {
        if (base.Init() == false)
            return false;

        SceneType = Define.SceneType.CharacterInfoScene;
        
        StartCoroutine(CoWaitLoad());

        return true;
    }

    IEnumerator CoWaitLoad()
    {
        while (Managers.DataManager.IsLoaded() == false)
            yield return null;
    }
}