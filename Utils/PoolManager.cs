using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
{
    private Dictionary<string, ObjectPool<Component>> poolInstances = new Dictionary<string, ObjectPool<Component>>();
    public static PoolManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public T GetInstance<T>(T prefab) where T : Component
    {
        if (!poolInstances.TryGetValue(prefab.name, out ObjectPool<Component> pool))
        {
            pool = CreatePool(prefab);
            poolInstances.Add(prefab.name, pool);
        }
        return pool.Get() as T;
    }
    
    public T GetInstance<T>(T prefab,float time) where T : Component
    {
        var instance = GetInstance(prefab);
        UpdateService.Instance.ExecuteActionAfterSeconds(time, ()=> Dispose(instance));
        return instance;

    }
    
    private ObjectPool<Component> CreatePool(Component prefab)
    {
        ObjectPool<Component> pooledObject = new ObjectPool<Component>(() => CreateMonoBehaviour(prefab) , ActivateMonoBehaviour, DeactivateMonoBehaviour );
        return pooledObject;
    }
    
    private Component CreateMonoBehaviour(Component prefab)
    {
        Component go = Instantiate(prefab, transform);
        go.name = prefab.name;
        return go;
    }

    private void ActivateMonoBehaviour(Component go)
    {
        go.gameObject.SetActive(true);
    }

    private void DeactivateMonoBehaviour(Component go)
    {
        go.gameObject.SetActive(false);
    }

    public void Dispose(Component disposableBehaviour)
    {
        if (poolInstances.TryGetValue(disposableBehaviour.gameObject.name, out ObjectPool<Component> pool))
        {
            pool.Release(disposableBehaviour);
        }
    }

}
