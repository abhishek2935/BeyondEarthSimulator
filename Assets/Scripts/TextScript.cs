using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TextScript : MonoBehaviour
{
    public Text textBox;
    public Button nextButton;
    public Button prevButton;
    public string fileName;
    public int columnNumber;

    private string[] rows;
    private int currentRow = 0;

    void Start()
    {
        LoadCSV();
        UpdateText();
        nextButton.onClick.AddListener(NextRow);
        prevButton.onClick.AddListener(PrevRow);
    }

    void LoadCSV()
    {
        string filePath = ("F:\\unity_project\\NASA's Habitable Exoplanet\\Assets\\StreamingAssets\\nasa_data_f.csv");
        rows = File.ReadAllLines(filePath);
    }

    void UpdateText()
    {
        string[] columns = rows[currentRow].Split(',');
        textBox.text = "Name:  "+columns[0] + "\n" + "Number of Suns:  " + columns[1] + "\n" + "Discovery Year:  " + columns[2] +"\n" + "Orbital Period (days):  " +columns[3] + "\n" + "Planet Radius(X Earth):  "+  columns[4] + "\n" + "Mass(X Earth) :  " + columns[5] + "\n" + "Temperature(K):  "  +columns[6];
    }

    void NextRow()
    {
        currentRow = (currentRow + 1) % rows.Length;
        UpdateText();
    }

    void PrevRow()
    {
        currentRow = (currentRow - 1 + rows.Length) % rows.Length;
        UpdateText();
    }
}