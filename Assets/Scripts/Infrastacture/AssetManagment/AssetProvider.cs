using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine;

namespace CastleWarriors.Infastructure.AssetManagment
{
    public class AssetProvider : IAssetProvider
    {
        private readonly Dictionary<string, AsyncOperationHandle> _completed = new();
        private readonly Dictionary<string, List<AsyncOperationHandle>> _handles = new();

        public GameObject Instantiate(string path)
    => Instantiate(path, Vector3.zero, Quaternion.identity, null);

        public GameObject Instantiate(string path, Vector3 at)
            => Instantiate(path, at, Quaternion.identity, null);

        public GameObject Instantiate(string path, Vector3 at, Quaternion rotation)
            => Instantiate(path, at, rotation, null);

        public GameObject Instantiate(string path, Vector3 at, Quaternion rotation, Transform parent)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            if (prefab)
            {
                return Object.Instantiate(prefab, at, rotation, parent);
            }

            Debug.LogError(@"Wrong path: """ + path + @"""");
            return null;
        }

        public async Task<T> Load<T>(AssetReference assetReference) where T : class
        {
            if (_completed.TryGetValue(assetReference.AssetGUID, out AsyncOperationHandle result))
            {
                return (T)result.Result;
            }

            AsyncOperationHandle<T> asyncOperationHandle = Addressables.LoadAssetAsync<T>(assetReference);

            asyncOperationHandle.Completed += h =>
            {
                if (_completed.ContainsKey(assetReference.AssetGUID))
                {
                    _completed.Add(assetReference.AssetGUID, h);
                }
            };

            AddHandle(assetReference, asyncOperationHandle);

            return await asyncOperationHandle.Task;
        }

        public void CleanUp()
        {
            foreach (var handleList in _handles.Values)
            {
                foreach (var resourceHandle in handleList)
                {
                    Addressables.Release(resourceHandle);
                }
            }
            _handles.Clear();
            _completed.Clear();
        }

        private void AddHandle<T>(AssetReference assetReference, AsyncOperationHandle<T> asyncOperationHandle) where T : class
        {
            if (!_handles.TryGetValue(assetReference.AssetGUID, out List<AsyncOperationHandle> resourceHandle))
            {
                resourceHandle = new();
                _handles[assetReference.AssetGUID] = resourceHandle;
            }
            resourceHandle.Add(asyncOperationHandle);
        }
    }
}
