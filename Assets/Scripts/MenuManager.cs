using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuManager : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void loadScene(string str)
    {
        SceneManager.LoadScene(str, LoadSceneMode.Single);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void setVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void createObject(GameObject sampleObject)
    {
        Vector3 vecteur = new Vector3(0, 0, -1);
        bool test = true;
        while (test)
        {
            test = false;
            foreach (GameObject objet in GameObject.FindGameObjectsWithTag("object"))
            {
                if (vecteur == objet.transform.position && objet != gameObject)
                {
                    vecteur.x = (Mathf.Round(vecteur.x * 0.125f) / 0.125f) + (objet.transform.localScale.x*8f);
                    test = true;
                }
            }
        }
        GameObject objectCreated = Instantiate(sampleObject, vecteur, Quaternion.Euler(-90f, 0f, 0f));

    }
}
