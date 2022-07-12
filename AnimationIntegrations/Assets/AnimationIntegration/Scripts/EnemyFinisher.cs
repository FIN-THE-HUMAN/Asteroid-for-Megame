using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(PlayerLookMouseTrace))]
public class EnemyFinisher : MonoBehaviour
{
    [SerializeField] private GameObject _sword;
    [SerializeField] private GameObject _automatic;
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Animation _finishAnimation;
    [SerializeField] private TMP_Text _finishText;
    private Enemy _target;
    private bool _canFinish;
    private PlayerLookMouseTrace _playerLookMouseTrace;
    private void Start()
    {
        _playerLookMouseTrace = GetComponent<PlayerLookMouseTrace>();
    }

    private void Update()
    {
        var colliders = Physics.OverlapSphere(transform.position, 4);

        if (colliders.Any(c => c.GetComponent<Enemy>()))
        {
            _finishText.enabled = true;
            _canFinish = true;
            _target = colliders.First(c => c.GetComponent<Enemy>()).GetComponent<Enemy>();
        }
        else
        {
            _finishText.enabled = false;
            _canFinish = false;
        }

        if(_canFinish && Input.GetKeyDown(KeyCode.Space))
        {

            transform.LookAt(_target.transform);
            StartCoroutine(MoveToTarget());

            Invoke(nameof(StopFinishing), 1f);

        }
    }

    IEnumerator MoveToTarget()
    {
        _playerMovement.CanMove = false;
        _playerLookMouseTrace.enabled = false;
        _animator.SetBool("isRunning", true);
        while ((transform.position - _target.transform.position).magnitude > 2)
        {
            yield return null;
            transform.position = Vector3.Lerp(transform.position, _target.transform.position, Time.deltaTime);
        }
        
        _animator.SetBool("isRunning", false);
        _animator.SetBool("CanFinish", true);
        _sword.SetActive(true);
        _automatic.SetActive(false);
    }

    private void StopFinishing()
    {
        _animator.SetBool("CanFinish", false);
        _sword.SetActive(false);
        _automatic.SetActive(true);
        _playerMovement.CanMove = true;
        _playerLookMouseTrace.enabled = true;
        _target.Die();
        _target = null;
    }
}
