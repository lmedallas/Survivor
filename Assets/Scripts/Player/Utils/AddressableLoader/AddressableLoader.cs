using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Utils.AddressableLoader
{
    public class AddressableLoader
    {
        public static async UniTask<T> InstantiateAsync<T>(string StyleName)
        {
            var task = Addressables.InstantiateAsync(StyleName).Task.AsUniTask();
            var asset = await task;
            return asset.GetComponent<T>();
        }

        public static async UniTask<T> InstantiateAsync<T>(string StyleName, Transform Anchor)
        {
            var task = Addressables.InstantiateAsync(StyleName, Anchor).Task.AsUniTask();
            var asset = await task;
            return asset.GetComponent<T>();
        }
    }
}
