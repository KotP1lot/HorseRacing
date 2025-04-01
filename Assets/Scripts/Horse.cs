using System.Collections;
using UnityEngine;

public class Horse : MonoBehaviour
{
    private Animator _animator;
    private float _speed;
    private bool _isCanRun;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void Run()
    {
        _isCanRun = true;
        _animator.SetTrigger("Run");
        StartCoroutine(ChangeSpeedRoutine());
    }
    private IEnumerator ChangeSpeedRoutine()
    {
        while (true)
        {
            _speed = Random.Range(4f, 7f);
            yield return new WaitForSeconds(2f);
        }
    }
    public void Stop() 
    {
        _speed = 2f;
        _isCanRun = false;
        _animator.SetTrigger("Stop");
        StopAllCoroutines();
    }
    public void SetPositionOnPodium(Transform transform, bool isFirstPlace = false) 
    {
        this.transform.SetPositionAndRotation(transform.position, transform.rotation);
        if (isFirstPlace)
            _animator.SetTrigger("Rar");
    }
    private void Update()
    {
        if (!_isCanRun) return;
        transform.position = Vector3.Lerp(transform.position, transform.position + _speed * Vector3.forward, Time.deltaTime);
    }
    private void OnMouseDown()
    {
        _animator.SetTrigger("Rar");
        RaceController.Instance.SetTrackHorse(this);
    }
}
