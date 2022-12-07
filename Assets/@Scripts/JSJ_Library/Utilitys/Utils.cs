namespace JSJ_Library
{
    public class Utils
    {
        // parameter: GameObject, return: parameter GameObject의 T(제네릭 타입) 컴포넌트 반환
        public static T GetOrAddComponent<T>(UnityEngine.GameObject go) where T : UnityEngine.Component
        {
            T component = go.GetComponent<T>();
            if (component == null)
                component = go.AddComponent<T>();
            return component;
        }
        
        public static T FindChild<T>(UnityEngine.GameObject go, string name = null, bool recursive = false) where T : UnityEngine.Object
        {
            if (go == null)
                return null;

            if (recursive == false)
            {
                UnityEngine.Transform transform = go.transform.Find(name);
                if (transform != null)
                    return transform.GetComponent<T>();
            }
            else
            {
                foreach (T component in go.GetComponentsInChildren<T>())
                {
                    if (string.IsNullOrEmpty(name) || component.name == name)
                        return component;
                }
            }

            return null;
        }
        
        public static UnityEngine.GameObject FindChild(UnityEngine.GameObject go, string name = null, bool recursive = false)
        {
            UnityEngine.Transform transform = FindChild<UnityEngine.Transform>(go, name, recursive);
            if (transform != null)
                return transform.gameObject;
            return null;
        }
    }
}