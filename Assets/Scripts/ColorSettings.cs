using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu()]
public class ColorSettings : ScriptableObject
{
    public Gradient gradient;
    public Material planetMaterial;

    [SerializeField] private Slider slider;

    // Method to update the gradient based on the slider's value
    public void UpdateGradient()
    {
        gradient.SetKeys(new GradientColorKey[] {
            new GradientColorKey(Color.red, 0f),
            new GradientColorKey(Color.blue, slider.value),
            new GradientColorKey(Color.green, 1f)
        }, gradient.alphaKeys);
    }

}
