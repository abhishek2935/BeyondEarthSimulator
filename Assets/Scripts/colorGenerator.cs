using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorGenerator 
{
    ColorSettings settings;
    Texture2D texture;
    const int textureResolution = 50;


    public void updateSettings(ColorSettings settings)
    {
        this.settings = settings;
        if (texture == null)
        {
            texture = new Texture2D(textureResolution, 1);
        }
    }

    public void UpdateElevation(MinMax eleMinMax)
    {
        settings.planetMaterial.SetVector("eleMinMax", new Vector4(eleMinMax.Min, eleMinMax.Max)); // off script
    }

    public void UpdateColors()
    {
        Color[] colours = new Color[textureResolution];

        for (int i=0; i < textureResolution; i++)
        {
            colours[i] = settings.gradient.Evaluate(i / (textureResolution - 1f));

        }
        texture.SetPixels(colours);
        texture.Apply();
        settings.planetMaterial.SetTexture("_PlanetTexture" , texture);
    }

}
