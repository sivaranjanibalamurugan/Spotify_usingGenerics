using RestSharp;
using System;
/*
 * Project = Checking the users details
 * Author  = Siva Ranjani B
 * Created Date = 21/08/2021
 */

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyUsingGenerics
{
    public class Utility
    { 
            //Method to get token 
            public static string GetToken()
            {
                string myToken = "Bearer BQD3WXPcRAGkQEbolmoQKr6kfUbHg1a0pbBJnZ96IhiZ1zx_UzAciP1eaLHkPZp9GMbjzMCXxa4OGP4VKxmkCi7zgZO2LxQz-X7gK0DJRFA7Vv3yeznvQIlKx8SqxuS2wyazuVXvkD41L1GhXmJUeYeVhUhiXXD5GkUb-EZZYEf6Oc-fPLyBHZ1tolFodd3nPLZcjyX8YZZ7vJIaCKKoUABQNXJcYyieF_FPiwZF73pMLcBkG9oEdL0bCEBrEZzV7ELJ9P021rMykL27M-3cTdXpLV2LLhVhiS248Aud";
                return myToken;
            }
            //RestRequest utility method
            public static IRestRequest RestRequestutility(string url)
            {

                IRestRequest restRequest = new RestRequest(url);

                restRequest.AddHeader("Authorization", "Token" + GetToken());

                return restRequest;
            }
            //SUccessful response method
            public static void Responsemessage(IRestResponse restResponse)
            {
                if (restResponse.IsSuccessful)
                {
                    Console.WriteLine("Statuscode:" + restResponse.StatusCode);
                    Console.WriteLine("Response:" + restResponse.Content);
                }
                Console.WriteLine(restResponse.ErrorMessage);
                Console.WriteLine(restResponse.ErrorException);
            }
    }
}


