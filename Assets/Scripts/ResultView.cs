using TMPro;
using UnityEngine;

public class ResultView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _textMeshPro;
    public void SetWinner(int place)
    {
        _textMeshPro.text = place == 0 ?
            "Congrats!\r\nYour horse is a winner!" :
            $"You'll be lucky next time!\r\nYour horse took {place + 1}d place";
    }
}
