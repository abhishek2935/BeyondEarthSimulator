using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleNoiseFilter: INoiseFilter
{
    NoiseSettings.SimpleNoiseSettings settings;
    Noise noise = new Noise();

    public SimpleNoiseFilter(NoiseSettings.SimpleNoiseSettings settings)
    {
        this.settings = settings;
    }

    public float Evaluate(Vector3 point) 
    {
        float noiseVal = 0;
        float freq = settings.baseRoughness;
        float amp = 1;

        for (int i = 0; i < settings.numLayers; i++)
        {
            float v = noise.Evaluate(point * freq + settings.centre);
            noiseVal += (v + 1) * .5f * amp;
            freq *= settings.roughness;
            amp *= settings.persistence;
        }

        noiseVal = Mathf.Max(0, noiseVal - settings.minVal);
        return noiseVal * settings.strength;
    }
}
