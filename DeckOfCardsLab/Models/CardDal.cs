
using Newtonsoft.Json;
using System.Net;

namespace DeckOfCardsLab.Models
{
    public class CardDal
    {  
       
        int draw = 5;
        string deckID = "qlwmxm09111f";
        string PileName = "hand";
        public Deck DrawCards()
        {
            string url = $"https://deckofcardsapi.com/api/deck/{deckID}/draw/?count={draw}"; 
            
            HttpWebRequest request = WebRequest.CreateHttp(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());
            string result = rd.ReadToEnd();

            Deck c = JsonConvert.DeserializeObject<Deck>(result);

            return c;
            
        }
        public Deck ViewHand()
        {
            string url = $"https://deckofcardsapi.com/api/deck/{deckID}/list/";
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string result = rd.ReadToEnd();
            Deck d = JsonConvert.DeserializeObject<Deck>(result);
            return d;
        }

    }
}
