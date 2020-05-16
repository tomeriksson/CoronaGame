using UnityEngine.UI;
using UnityEngine;

public class ScoreCounting : MonoBehaviour
{
    public Text score;
    private int waves = 0;

    public void AddToScore() {
        waves++;
        score.text = waves.ToString();
    }
}
