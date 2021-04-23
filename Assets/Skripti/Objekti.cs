using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objekti : MonoBehaviour
{
    //GameObject, kas uzglabā visus velkamos objektus
    public GameObject atkritumuMasina;
    public GameObject atroMasina;
    public GameObject autobuss;
    public GameObject b2Masina;
    public GameObject cementaMas;
    public GameObject e46Masina;
    public GameObject eskavators;
    public GameObject policijasMas;
    public GameObject traktors1;
    public GameObject traktors2;
    public GameObject ugunsdzeseji;

    //Uzglabā velkamo objektu sāk. pozīcijas koordinātas (lai zinātu kur aizmest objektu, ja tas nolikts nepareizajā vietā)
    //Objekti paliek public, taču paslēpj no Inspector loga
    [HideInInspector]
    public Vector2 atkrKoord;
    [HideInInspector]
    public Vector2 atroKoord;
    [HideInInspector]
    public Vector2 bussKoord;
    [HideInInspector]
    public Vector2 b2Koord;
    [HideInInspector]
    public Vector2 cementKoord;
    [HideInInspector]
    public Vector2 e46Koord;
    [HideInInspector]
    public Vector2 eskavKoord;
    [HideInInspector]
    public Vector2 policKoord;
    [HideInInspector]
    public Vector2 trak1Koord;
    [HideInInspector]
    public Vector2 trak2Koord;
    [HideInInspector]
    public Vector2 ugunsKoord;

    //Uzglabās ainā esošo kanvu
    public Canvas kanva;
    //Uzglabās skaņas avotu, kurā atskaņot audio failu
    public AudioSource skanasAvots;
    //Masīvs, kas uzglabās visas skaņas
    public AudioClip[] skanaKoAtskanot;

    //Uzglabās objektu, kurš ir pēdējais pārvietotais
    [HideInInspector]
    public GameObject pedejaisVilktais = null;

    //Mainīgais atbild par to, vai objektsi r nolikts pareizi vai nepareizi
    [HideInInspector]
    public bool vaiIstajaVieta = false;


    //Funkcija nostrādā tiklīdz nospiesta play poga
    private void Awake()
    {
        atkrKoord = atkritumuMasina.GetComponent<RectTransform>().localPosition;
        atroKoord = atroMasina.GetComponent<RectTransform>().localPosition;
        bussKoord = autobuss.GetComponent<RectTransform>().localPosition;
        b2Koord = b2Masina.GetComponent<RectTransform>().localPosition;
        cementKoord = cementaMas.GetComponent<RectTransform>().localPosition;
        e46Koord = e46Masina.GetComponent<RectTransform>().localPosition;
        eskavKoord = eskavators.GetComponent<RectTransform>().localPosition;
        policKoord = policijasMas.GetComponent<RectTransform>().localPosition;
        trak1Koord = traktors1.GetComponent<RectTransform>().localPosition;
        trak2Koord = traktors2.GetComponent<RectTransform>().localPosition;
        ugunsKoord = ugunsdzeseji.GetComponent<RectTransform>().localPosition;
    }
}
