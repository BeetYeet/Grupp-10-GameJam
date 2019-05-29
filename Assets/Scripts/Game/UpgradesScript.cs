using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpgradesScript : MonoBehaviour
{

    public Sprite[] sprites;

    List<upgradeProfile> upgrades = new List<upgradeProfile>();

    public Text[] texts;
    public Image[] images;

    int[] ids;
    float[] values;

    private void Awake()
    {
        ids = new int[texts.Length];
        values = new float[texts.Length];

        for (int i = 0; i < sprites.Length; i++)
        {
            upgrades.Add(new upgradeProfile());
            upgrades[i].create(sprites[i], i);
        }

    }

    private void OnEnable()
    {
        bool x = true;
        for (int i = 0; i < upgrades.Count; i++)
        {
            if (upgrades[i].uses == 0)
                upgrades.RemoveAt(i);
            x = false;
        }
        if (x)
        {
            gameObject.SetActive(false);
            return;
        }

        Time.timeScale = 0.01f;
        for (int i = 0; i < texts.Length; i++)
        {
            int rand = Random.Range(0, upgrades.Count);
            ids[i] = rand;
            values[i] = upgrades[rand].Value();
            if (rand == 0)
            {
                texts[i].text = upgrades[rand].name +
                    (int)(100 * values[i] / GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().movementSpeed) + "%";

            }
            else if (rand == 1)
            {
                texts[i].text = upgrades[rand].name +
                    (int)(100 * values[i] / GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAim>().cannonCooldown) + "%";

            }
            else if (rand == 2)
            {
                texts[i].text = upgrades[rand].name +
                    (int)(100 * values[i] / GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAim>().range) + "%";

            }
            else if (rand == 3)
            {
                texts[i].text = upgrades[rand].name;
            }
            else
                texts[i].text = upgrades[rand].name + values[i];
            images[i].sprite = upgrades[rand].image;
        }
    }

    public void ButtonInput(int buttonNum)
    {
        upgrades[ids[buttonNum]].uses--;

        switch (ids[buttonNum])
        {
            case 0:
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().movementSpeed += values[buttonNum];
                break;
            case 1:
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAim>().cannonCooldown += values[buttonNum];
                break;
            case 2:
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAim>().range += values[buttonNum];
                break;
            case 3:
                {
                    bool l = true;
                    PlayerAim pa = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAim>();
                    pa.cannons.ForEach((x) =>
                    {
                        if (!x.gameObject.activeSelf)
                        {
                            l = false;
                            x.gameObject.SetActive(true);
                            Time.timeScale = 1f;
                            gameObject.SetActive(false);
                            return;
                        }
                    });
                    if (l)
                    {
                        upgrades[ids[buttonNum]].uses = 0;
                        OnEnable();
                        return;
                    }
                }
                break;

            default:
                break;
        }
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
}
public class upgradeProfile
{
    public int id = 0;
    public int uses = -1;
    public string name = "upgrade";
    public Sprite image;
    public float max { private get; set; }
    public float min { private get; set; }
    public float value { get; private set; }

    public float Value() => value = Random.Range(min, max);

    public float ValueInt() => value = (int)(Random.Range(min, max) + 0.5f);

    public void create(Sprite sprite, int ID = -1)
    {
        if (ID == -1)
            ID = id;

        id = ID;
        image = sprite;

        switch (ID)
        {
            case 0:
                max = 0.35f;
                min = 0.1f;
                name = "Increes speed by ";
                Value();
                break;
            case 1:
                max = 0.25f;
                min = 0.05f;
                name = "Increes reload time by ";
                Value();
                break;
            case 2:
                uses = 100;
                max = 0.25f;
                min = 0.05f;
                name = "Increes range by ";
                Value();
                break;
            case 3:
                uses = 4;
                max = 1;
                min = 1;
                name = "Add a cannon";
                ValueInt();
                break;

            default:
                break;
        }

    }

}
