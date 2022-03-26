using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using modul5_1302204038;

namespace modul5_1302204038
{
    internal class Program
    { 
        static void Main(String[] args)
        {
            SayaTubeVideo test = new(null);
            test.printVideoDetails();

            SayaTubeVideo baru = new("Cara Mendownload RAM");
            baru.printVideoDetails();

            SayaTubeVideo saya = new("Tutorial Design By Contract – Fan");
            saya.printVideoDetails();

            for (int i = 0; i < 4; i++)
            {
                saya.increasePlayCount(123456789);
            }
            saya.printVideoDetails();
        }
    }

    public class SayaTubeVideo
    {
        private int id;
        private String title;
        private int playCount;

        public SayaTubeVideo(String judul)
        {
            Contract.Requires(title != null);
            Contract.Requires(title.Length < 200);
            Random ids = new Random();
            this.title = judul;
            id = ids.Next(0, 100000);
            this.playCount = 0;
        }

        public void IncreasePlayCount(int i)
        {
            try
            {
                if (i >= 10000000) throw new Exception("Melebihi limit angka");
                playCount = playCount + i;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public int GetPlaycount()
        {
            return playCount;
        }

        public string GetTitle()
        {
            return title;
        }

        public void PrintVideoDetails()
        {
            Console.WriteLine("id :"+id);
            Console.WriteLine("judul :"+title);
            Console.WriteLine("playCount :"+playCount);
        }
    }


    public class SayaTubeUser
    {
        private int id;
        private List<SayaTubeVideo> uploadedVideos;
        private String Username;

        public SayaTubeUser(String judul)
        {
            Random ids = new Random();
            id = ids.Next(0, 100000);
            this.Username = null;
            this.uploadedVideos = new List<SayaTubeVideo>();
        }

        public int GetTotalVideoPlayCount()
        {
            int total = 0;
            foreach (SayaTubeVideo video in this.uploadedVideos)
            {
                total += video.GetPlaycount();
            }
            return total;
        }

        public void AddVideo(SayaTubeVideo video)
        {
            uploadedVideos.Add(video);
        }

        public void printAllvideoplayCount()
        {
            for (int i = 0; i < uploadedVideos.Count; i++)
            {
                Console.WriteLine("username:" + Username);
                Console.WriteLine("video:" + (i + 1) + ":" + uploadedVideos[i]);
            }
        }
    }
}
