using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button abilityButton1;
    [SerializeField] private Button abilityButton2;
    [SerializeField] private Button abilityButton3;

    [Header("Settings")]
    [SerializeField] private float[] abilityCooldownDurations = { 1f, 0.5f, 3f };

    [Header("Visual")]
    [SerializeField] private Image[] abilityFeedbackPanels;

    private bool[] isAbilityOnCooldown = { false, false, false };


    private void Start()
    {
        abilityButton1.onClick.AddListener(() => ActivateAbility(0, abilityButton1));
        abilityButton2.onClick.AddListener(() => ActivateAbility(1, abilityButton2));
        abilityButton3.onClick.AddListener(() => ActivateAbility(2, abilityButton3));
    }

    private void ActivateAbility(int abilityIndex, Button button)
    {
        if (isAbilityOnCooldown[abilityIndex]) return;

        StartCoroutine(ApplyCooldown(abilityIndex, button, abilityCooldownDurations[abilityIndex]));
        UpdateAbilityVisual(abilityIndex);
    }

    private void UpdateAbilityVisual(int index)
    {
        Color targetColor;
        switch (index)
        {
            case 0:
                targetColor = Color.blue;
                break;
            case 1:
                targetColor = Color.black;
                break;
            case 2:
                targetColor = Color.green;
                break;
            default:
                targetColor = Color.white;
                break;
        }

        abilityFeedbackPanels[index].color = targetColor;
    }

    private IEnumerator ApplyCooldown(int abilityIndex, Button button, float duration)
    {
        isAbilityOnCooldown[abilityIndex] = true;
        button.interactable = false;

        yield return new WaitForSeconds(duration);

        button.interactable = true;
        abilityFeedbackPanels[abilityIndex].color = Color.white;
        isAbilityOnCooldown[abilityIndex] = false;
    }
}
