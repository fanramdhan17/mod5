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
            SayaTubeVideo video = new SayaTubeVideo("Tutorial Design By Contract – Fan");
            video.PrintVideoDetails();
            video.IncreasePlayCount(1);
            video.PrintVideoDetails();
        }
    }

    public class SayaTubeVideo
    {
        private int id;
        private String title;
        private int playCount;

        public SayaTubeVideo(String judul)
        {
            Random ids = new Random();
            this.title = judul;
            id = ids.Next(0, 100000);
            this.playCount = 0;
        }

        public void IncreasePlayCount(int i)
        {
            playCount = playCount + i;
        }

        public void PrintVideoDetails()
        {
            Console.WriteLine("id :"+id);
            Console.WriteLine("judul :"+title);
            Console.WriteLine("playCount :"+playCount);
        }

        internal int getPlayCount()
        {
            throw new NotImplementedException();
        }

        internal int GetTitle()
        {
            throw new NotImplementedException();
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
                total += video.getPlayCount();
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
