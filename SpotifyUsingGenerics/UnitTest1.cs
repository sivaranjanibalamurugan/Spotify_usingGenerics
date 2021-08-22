/*
 * Project = Checking the users details
 * Author  = Siva Ranjani B
 * Created Date = 18/08/2021
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System.Collections.Generic;
using System;
using System.Net;
using SpotifyUsingGenerics;

namespace SpotifyUsingGenerics
{
    [TestClass]
    public class TestSpotify
    {
        RestClient Client = null;
        RestClient Client1 = null;
        private string user_id = "2nfbc5cm2chh9oxvhvamcyjyz";
        private string playlist_id = "1qjNNR7NXJ5Yib6FksiSKV";
        private string my_Token = "null";

        [TestInitialize]
        public void SetUp()
        {
            Client = new RestClient("https://api.spotify.com/v1/users/" + user_id + "/playlists");
            Client1 = new RestClient("https://api.spotify.com/v1/playlists/" + playlist_id + "/tracks");
            my_Token = " Bearer BQCe5cMJqZAlYBsgKqYdYjou8AtiHMubIBoGLnVyk1nTdnuTjM9Sstkr6WIGWODEqqPB1JqVec0mmYh0ugW5XvMQwP5YGBqebqq4KSGSXG9e-S48nCIVJ-3HSJfEMkF5YUWn2_6N3xOPawHxA2HwR6qtJ4pb9vMaMeqAOrX_FNcBySG_mhBw47FXvjA5oJuJyRLo4eVY20-wi2HWejXfEI3LzJ9REoQoXfVPOGppM-fJMHHGEtGoi-ZDgHCIu6sI-MumD8lyEOq6hn3izs75QxZUOUgX5RY5sfzpz23r";
        }
        //method to create a playlist using GET webservices
        public  IRestResponse GetPlaylist()
        {
            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Token" + my_Token);
            IRestResponse response = Client.Execute(request);
            return response;
        }
        [TestMethod]
        public void TestGetPlaylistMethod()
        {
            IRestResponse response = GetPlaylist();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            if (response.IsSuccessful)
            {
                Console.WriteLine("StatusCode:" + response.StatusCode);
                Console.WriteLine("Response:" + response.Content);
            }
        }
        //method to create a playlist using POST webservices
        public IRestResponse CreatePlaylist()
        {
            string JsonData = "{" +
                                  "\"name\": \"My_playlist\"," +
                                  "\"description\": \"Generics-aug22\"," +
                                  "\"public\":\" false\"" +
                              "}";
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Token" + my_Token);
            request.AddJsonBody(JsonData);
            IRestResponse response = Client.Execute(request);
            return response;
        }
        [TestMethod]
        public void TestCreatePlaylistMethod()
        {
            IRestResponse response = CreatePlaylist();
            Assert.AreEqual(201, (int)response.StatusCode);
            if(response.IsSuccessful)
            {
                Console.WriteLine("StatusCode:" + response.StatusCode);
                Console.WriteLine("Response:" +  response.Content);
            }
        }
        //method to update a play list 
        public IRestResponse UpdatePlaylist()
        {
            string JsonData = "{" +
                                 "\"name\": \"Updated playllist now \"," +
                                 "\"description\": \"Generics-aug22\"," +
                                 "\"public\":\" false\"" +
                             "}";
            RestRequest request = new RestRequest(Method.PUT);
            request.AddHeader("Authorization", "Token" + my_Token);
            request.AddJsonBody(JsonData);
            IRestResponse response = Client.Execute(request);
            return response;
        }
        [TestMethod]
        public void TestUpdatePlaylistMethod()
        {
            IRestResponse response = UpdatePlaylist();
            Assert.AreEqual(201,204, (int)response.StatusCode);
            if(response.IsSuccessful)
            {
                Console.WriteLine("StatusCode:" + response.StatusCode);
                Console.WriteLine("Response:" + response.Content);
            }
        }
        //Delete method to delete a playlist 
        public IRestResponse DeletePlaylist()
        {
            RestRequest request = new RestRequest(Method.DELETE);
            request.AddHeader("Authorization", "Token" + my_Token);
            IRestResponse response = Client.Execute(request);
            return response;
        }
        [TestMethod]
        public void TestDeletePlaylistMethod()
        {
            IRestResponse response = DeletePlaylist();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            if (response.IsSuccessful)
            {
                Console.WriteLine("StatusCode:" + response.StatusCode);
                Console.WriteLine("Response:" + response.Content);
            }
        }
    }
}
