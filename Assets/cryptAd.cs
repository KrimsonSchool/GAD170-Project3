using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cryptAd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void close()
    {
        gameObject.SetActive(false);
    }

    public void crypto()
    {
        Application.OpenURL("https://binance.com/");
        Application.OpenURL("https://crypto.com/");
        Application.OpenURL("https://swyftx.com/au/");
        Application.OpenURL("https://www.cointree.com/");
        Application.OpenURL("https://www.coinspot.com.au/");
        Application.OpenURL("https://www.coinbase.com/");
        Application.OpenURL("https://www.googleadservices.com/pagead/aclk?sa=L&ai=DChcSEwj0oaCus8v-AhVZc30KHabeBBMYABACGgJzZg&ohost=www.google.com&cid=CAESbeD2nM6Y12NcZdm5LcXOq-fEAJOMnxnSrjlwIdXRItHjmN8gzkSJo9sPeeM4fZgvCWP8aizMMovPDEyMfd6uCXo2tdEI-QLvkAbGu9TvNmkGKPIEoD9SSdmq5-N04McLmCBraAXsUSbPY45yrWg&sig=AOD64_1QRZtDQG4huYI9YdXxPywLdjBB-w&q&adurl&ved=2ahUKEwiZxpius8v-AhV9T2wGHTU4CJIQ0Qx6BAgGEAE");
        Application.OpenURL("https://www.google.com/search?q=buy+crypto&rlz=1C1GCEW_enAU1044AU1044&oq=buy+crypto&aqs=chrome.0.0i20i263i512l2j0i512l8.2528j0j4&sourceid=chrome&ie=UTF-8");
        Time.timeScale = 0;
        Application.Quit();
    }
}
