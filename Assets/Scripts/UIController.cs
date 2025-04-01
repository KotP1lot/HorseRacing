using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject _start;
    [SerializeField] ResultView _end;
    public void HideUI() 
    {
        _start.SetActive(false);
    }
    public void SetResults(int place) 
    {
        _end.gameObject.SetActive(true);
        _end.SetWinner(place);
    }
}
