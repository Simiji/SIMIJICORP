using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomTrigger : MonoBehaviour
{
    [Flags]
    public enum TriggerInteraction
    {
        None = 0,
        Enter = 1,
        Exit = 2,
        Stay = 4
    }

    [System.Serializable]
    public class Entry
    {
        public bool RequireTag;
        /*[ShowIf("RequireTag")] */
        public string RequiredTag;
        public bool RequireLayer;
        /*[ShowIf("RequireLayer")] */
        public LayerMask RequiredLayer;

        public UnityEvent<Collider> OnEnter = new UnityEvent<Collider>();
        public UnityEvent<Collider> OnStay = new UnityEvent<Collider>();
        public UnityEvent<Collider> OnExit = new UnityEvent<Collider>();
    }

    public List<Entry> Entries = new List<Entry>();
    public bool TriggerExitOnDestroyOrDisable;

    private bool _isInteracting = false;
    public bool IsInteracting => _isInteracting;

    public void OnTriggerEnter(Collider other)
    {
        Entries.ForEach(entry => ProcessCollision(other, entry, TriggerInteraction.Enter));
    }
    public void OnTriggerExit(Collider other)
    {
        Entries.ForEach(entry => ProcessCollision(other, entry, TriggerInteraction.Exit));
    }
    public void OnTriggerStay(Collider other)
    {
        Entries.ForEach(entry => ProcessCollision(other, entry, TriggerInteraction.Stay));
    }

    private void OnDestroy()
    {
        if (TriggerExitOnDestroyOrDisable)
        {
            Entries.ForEach(entry => entry.OnExit?.Invoke(null));
        }
    }

    private void OnDisable()
    {
        if (TriggerExitOnDestroyOrDisable)
        {
            Entries.ForEach(entry => entry.OnExit?.Invoke(null));
        }
    }

    private void ProcessCollision(Collider other, Entry entry, TriggerInteraction interaction)
    {
        if ((other.gameObject.layer == entry.RequiredLayer && entry.RequireLayer) || (other.CompareTag(entry.RequiredTag) && entry.RequireTag))
        {
            switch (interaction)
            {
                case TriggerInteraction.None:
                    break;
                case TriggerInteraction.Enter:
                    entry.OnEnter?.Invoke(other);
                    break;
                case TriggerInteraction.Exit:
                    _isInteracting = false;
                    entry.OnExit?.Invoke(other);
                    break;
                case TriggerInteraction.Stay:
                    _isInteracting = true;
                    entry.OnStay?.Invoke(other);
                    break;
                default:
                    break;
            }
        }
    }
}
