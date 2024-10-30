using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class GameEvent : using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "GameEvent", order = 0)]
public class GameEvent : ScriptableObject 
{
    public List<GameEventListener> listeners = new List<GameEventListener>();

    //Raise events when they are triggered by various means (This is what tells listeners that the event has happened)
    public void Raise(Component sender, object data)
    {
        for (int i = 0; i < listeners.Count; i++){
            listeners[i].OnEventRaised(sender, data);
        }
    }

    //Manage listeners
    public void RegisterListener(GameEventListener listener)
    {
        if(!listeners.Contains(listener))
            listeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener)
    {
        if(listeners.Contains(listener))
            listeners.Remove(listener);
    }

}
