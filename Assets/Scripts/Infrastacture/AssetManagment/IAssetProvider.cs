using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CastleWarriors.Infastructure.AssetManagment
{
    public interface IAssetProvider
    {
        void CleanUp();
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 at);
        GameObject Instantiate(string path, Vector3 at, Quaternion rotation);
        GameObject Instantiate(string path, Vector3 at, Quaternion rotation, Transform parent);
        Task<T> Load<T>(AssetReference assetReference) where T : class;
    }
}