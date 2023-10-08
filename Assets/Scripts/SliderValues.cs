using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SliderValues : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _sliderText;
    [SerializeField] private ShapeSettings shapeSettings; // Reference to ShapeSettings
    //[SerializeField] private ColorSettings colorSettings;
    //[SerializeField] private Light directionalLight;
    private void Start()
    {
        _slider.onValueChanged.AddListener((v) =>
        {
            _sliderText.text = v.ToString("0.000");

            // Update the radius in the ShapeSettings
            shapeSettings.planetRadius = v;
            //colorSettings.UpdateGradient();
           // directionalLight.intensity = v;
        });
    }

    
}
