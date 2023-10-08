using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LightIntensitySliderValues : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _sliderText;
    [SerializeField] private ShapeSettings shapeSettings; // Reference to ShapeSettings
    [SerializeField] private ColorSettings colorSettings;
    [SerializeField] private Light directionalLight;
    public float lightminval = 0.1f;
    public float lightmaxval = 0.5f;

    void OnEnable()
    {
        _slider.minValue = lightminval;
        _slider.maxValue = lightmaxval;
        _slider.onValueChanged.AddListener(SetLightIntensity);    
    }

    void SetLightIntensity(float value)
    {
        directionalLight.intensity = 1 - value;
    }

}
