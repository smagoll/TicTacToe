using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

public class MiniGameLauncher : MonoBehaviour
{
    [SerializeField]
    private Transform _parent;
    
    [Inject]
    private DiContainer _container;

    public async UniTask<MiniGameOutcome> Launch(string address)
    {
        var prefab = await Addressables.LoadAssetAsync<GameObject>(address);

        var instance = _container.InstantiatePrefab(prefab);
        
        instance.transform.SetParent(_parent);
        instance.transform.localPosition = Vector3.zero;

        var miniGame = instance.GetComponent<IMiniGame>();

        return await miniGame.Play();
    }
}