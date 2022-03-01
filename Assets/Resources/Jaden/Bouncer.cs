using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : Tile
{

    //display net worth required, maybe when player in radius 
    //change sprite and collider-status depending if you can pass or not
    //stuff only checked when player in radius so it looks like theyre reacting to player 
    //are closed off by default 

    int netWorthRequired = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool checkNetWorth() {
        if(StockMarketTerminal.playerNetWorth >= netWorthRequired) {
            return true;
        }
        return false;
    }
}
