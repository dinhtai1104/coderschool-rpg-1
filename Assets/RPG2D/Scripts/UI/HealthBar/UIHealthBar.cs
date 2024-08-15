using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    [SerializeField] private Image filledHp;

    public void SetFillHp(float percent)
    {
        filledHp.fillAmount = percent;
    }
}