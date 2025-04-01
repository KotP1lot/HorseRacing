using Unity.Cinemachine;
using UnityEngine;

public class CameraContoller : MonoBehaviour
{
    [SerializeField] GameObject _chooseView;
    [SerializeField] GameObject _followView;
    [SerializeField] GameObject _cupView;

    public void SetTarget(Transform transform)
    {
        _chooseView.SetActive(false);
        
        _followView.SetActive(true);
        _followView.GetComponent<CinemachineCamera>().Target.TrackingTarget = transform;
    }
    public void MoveToPodium() 
    {
        _followView.SetActive(false);
        _cupView.SetActive(true);
    }
}
