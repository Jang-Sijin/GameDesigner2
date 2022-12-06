using UnityEngine;

namespace JSJ_Library
{
    public class Managers : MonoBehaviour
    {
        public static Managers s_instance = null;
        public static Managers Instance
        {
            get { return s_instance; }
        }

        private DataManager _dataManager = new DataManager();
        public static DataManager DataManager
        {
            get { return Instance?._dataManager; }
        }

        public static void Init()
        {
            // @Managers 오브젝트가 존재하면 @Manager는 Init(초기화) 된 상태이다.
            if (s_instance != null)
                return;
            
            // @Managers 오브젝트를 찾고, @Managers 오브젝트가 없으면 생성한다.
            GameObject managers = GameObject.Find("@Managers");
            if (managers == null)
                managers = new GameObject {name = "@Managers"};

            // managers 오브젝트에 Managers 스크립트 컴포넌트를 추가한다.
            // 씬이 이동되어도 managers 오브젝트는 삭제되지 않도록 DontDestroyOnLoad 처리한다.
            s_instance = Utils.GetOrAddComponent<Managers>(managers);
            DontDestroyOnLoad(managers);
            
            // Managers에 등록된 여러 개의 Manager 객체들을 초기화한다.
            DataManager.Init();
        }
    }
}