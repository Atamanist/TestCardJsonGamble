using System;
using UnityEngine;

namespace Project.Core
{
    public class JsonReaderService<T>
    {
        [Serializable]
        private class Wrapper<T>
        {
            public T[] Items;
        }

        public T[] LoadFile(string name)
        {
            var json = Resources.Load<TextAsset>(name);
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>("{\"Items\":" + json.text + "}");
            return wrapper.Items;
        }
    }
}