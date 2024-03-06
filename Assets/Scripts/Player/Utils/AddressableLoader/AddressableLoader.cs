using Cysharp.Threading.Tasks;
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
    }
}
