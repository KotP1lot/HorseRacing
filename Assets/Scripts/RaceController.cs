using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceController : MonoBehaviour
{
    public static RaceController Instance;

    [SerializeField] CameraContoller _cameraContoller;
    [SerializeField] UIController _UIController;
    [SerializeField] List<Horse> _horses;
    [SerializeField] List<ParticleSystem> _particles;

    [SerializeField] List<Transform> _podiumPositions;
    private Horse _trackedHorse;
    private List<Horse> _queueFinish = new();
    private void Awake()
    {
        Instance = this;
    }

    public void SetTrackHorse(Horse horse)
    {
        if (_trackedHorse != null) return;

        _trackedHorse = horse;
        _cameraContoller.SetTarget(horse.transform);
        _UIController.HideUI();
        StartCoroutine("StartDelay");
    }
    private IEnumerator StartDelay() 
    {
        yield return new WaitForSeconds(4f);
        StartRace();
    }
    private void StartRace() 
    {
        _horses.ForEach(x=>x.Run());
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Horse horse))
        {
            horse.Stop();
            _queueFinish.Add(horse);
            if(_queueFinish.Count >= 4)
                FinishResults();
        }
    }
    private void FinishResults() 
    {
        var place = _queueFinish.FindIndex(x => x ==  _trackedHorse);
        _UIController.SetResults(place);
        _cameraContoller.MoveToPodium();
        for(int i = 0; i < 4; i++) 
        {
            _queueFinish[i].SetPositionOnPodium(_podiumPositions[i], i == 0);
        }
        StartCoroutine(ParticleDelay());
    }
    private IEnumerator ParticleDelay()
    {
        yield return new WaitForSeconds(2f);
        _particles.ForEach(x => x.Play());
    }
}
