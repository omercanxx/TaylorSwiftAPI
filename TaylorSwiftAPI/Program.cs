using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace TaylorSwiftAPI
{
    public class MusicModel
    {
        public string title { get; set; }
        public string artist { get; set; }
        public string url { get; set; }
        public string image { get; set; }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            List<MusicModel> GetApiData()
            {
                var apiUrl = "https://rallycoding.herokuapp.com/api/music_albums";

                Uri url = new Uri(apiUrl);
                WebClient client = new WebClient();
                client.Encoding = System.Text.Encoding.UTF8;

                string json = client.DownloadString(url);

                JavaScriptSerializer ser = new JavaScriptSerializer();
                List<MusicModel> jsonList = ser.Deserialize<List<MusicModel>>(json);

                return jsonList;
            }

            List<MusicModel> myList = GetApiData();

            foreach (var item in myList)
            {
                Console.WriteLine("artist: {0} \nimage: {1} \ntitle : {2} \nurl : {3}\n\n**********", item.artist, item.image, item.title, item.url);
            }
            Console.ReadLine();
        }
    }
}
