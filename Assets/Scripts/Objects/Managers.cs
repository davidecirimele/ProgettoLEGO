using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(PlayerManager))]
[RequireComponent (typeof(InventoryManager))]
[RequireComponent (typeof(AudioManager))]
public class Managers : MonoBehaviour
{
    public static PlayerManager Player { get; private set; }
    public static InventoryManager Inventory { get; private set; }
    public static AudioManager Audio{get; private set; }
    private List<IGameManager> _startSequence;

    private void Awake()
    {
        Player = GetComponent<PlayerManager>();
        Inventory = GetComponent<InventoryManager>();
        Audio = GetComponent<AudioManager>();

        _startSequence = new List<IGameManager>();
        _startSequence.Add(Player);
        _startSequence.Add(Inventory);
        _startSequence.Add(Audio);

        StartCoroutine(StartupManagers());
    }

    private IEnumerator StartupManagers()
    {
        foreach (IGameManager manager in _startSequence)
        {
            manager.Startup();
        }

        yield return null;

        int numModules = _startSequence.Count;
        int numready = 0;

        while (numready < numModules)
        {
            int lastReady = numready;
            numready = 0;
            foreach(IGameManager manager in _startSequence)
            {
                if (manager.status == ManagerStatus.Started) { numready++; }
            }

            if (numready > lastReady)
                Debug.Log("Progress: " + numready + "/" + numModules);
            yield return null;
        }
        Debug.Log("All managers started up");
    }
}
