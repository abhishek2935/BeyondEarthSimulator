using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator
{
    ShapeSettings settings;
    INoiseFilter[] noiseFilter;
    public MinMax elevMinMax;
    

    public void UpdateSettings(ShapeSettings settings)
    {
        this.settings = settings;
        noiseFilter = new INoiseFilter[settings.noiseLayers.Length];
        for (int i = 0; i < noiseFilter.Length; i++)
        {
            noiseFilter[i] = NoiseFilterFact.CreateNoiseFilter(settings.noiseLayers[i].noiseSettings);
        }

        elevMinMax = new MinMax();
    }
    public Vector3 CalculatePointOnPlanet(Vector3 pointOnUnitSphere)
    {
        float firstlayerval = 0;
        float elevation = 0;

        if (noiseFilter.Length > 0)
        {
            firstlayerval = noiseFilter[0].Evaluate(pointOnUnitSphere);

            if (settings.noiseLayers[0].enabled)
            {
                elevation = firstlayerval;
            }
        }

        for (int i = 1; i < noiseFilter.Length; i++)
        {
            if (settings.noiseLayers[i].enabled)
            {
                float mask = (settings.noiseLayers[i].firstAsMask) ? firstlayerval : 1;
                elevation += noiseFilter[i].Evaluate(pointOnUnitSphere) * mask;
            }
        }
        elevation = settings.planetRadius * (1 + elevation);
        elevMinMax.AddValue(elevation);
        return pointOnUnitSphere * elevation; // off script
    }

}
 