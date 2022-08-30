using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //singleton
    public static PlayerManager instance;
    public static PlayerManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerManager>();
            }
            return instance;
        }
    }
    public List<int> playerNumber = new List<int>();
    public string[] playerNames = new string[]{
    "Abus","Argai Ronso","Auda Guado","Balgerda","Basik Ronso","Berrik","Bickson","Biggs","Blappa",
    "Botta","Datto","Deim","Doram","Durren","Eigaar","Gazna Ronso","Giera Guado","Graav","Irga Ronso","Isken",
    "Jassu","Judda","Jumal","Keepa","Kiyuri","Kulukan","Kyou","Lakkam","Larbeight",
    "Letty","Linna","Mep","Mifurey","Miyu","Naida","Nav Guado","Nedus","Nimrook","Nizarut","Noy Guado","Nuvy Ronso",
    "Pah Guado","Raudy","Ropp","Shaami","Shuu","Svanda","Tatts","Vilucha","Vuroja","Wedge","Yuma Guado","Zalitz",
    "Zamzi Ronso","Zazi Guado","Zev Ronso"
    };
}
