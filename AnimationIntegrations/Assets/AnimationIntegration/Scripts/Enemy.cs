using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    public UnityEvent Died;
    public Animator Animator => _animator;
    public void Die()
    {
        Died.Invoke();
        _animator.enabled = false;
        Invoke(nameof(Hide), 1f);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
