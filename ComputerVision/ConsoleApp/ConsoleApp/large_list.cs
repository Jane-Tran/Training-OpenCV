/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class large_list
    {
        public struct TFL_PointXYZ
        {
            public float x;
            public float y;
            public float z;

            public TFL_PointXYZ(float xInital, float yInital, float zInital)
            {
                x = xInital;
                y = yInital;
                z = zInital;
            }
        };

        public struct TFL_PointCloud
        {
            public List<TFL_PointXYZ> PointCloud;
            public List<List<TFL_PointXYZ>> ListPointCloud;

            public TFL_PointCloud(List<TFL_PointXYZ> list_PointXYZs, List<List<TFL_PointXYZ>> list_list_PointXYZs)
            {
                PointCloud = list_PointXYZs;
                ListPointCloud = list_list_PointXYZs;
            }
        }

        public static Random _random = new Random();
        public static int size_pixel = 640 * 480;
        public static int index_frame_scan = 0;
         
        public static TFL_PointCloud list_frame_scan = new TFL_PointCloud();
        private static void Main(string[] args)
        {
            list_frame_scan.ListPointCloud = new List<List<TFL_PointXYZ>>();

            Thread th_one = new Thread(ThreadOne);
            Thread th_two = new Thread(ThreadTwo);

            th_one.Start();
            th_two.Start();

            // Chặn luồng tiếp tục cho tới khi các tiến trình th_one và th_two hoàn thành
            th_one.Join();
            th_two.Join();
        }
        private static void ThreadOne()
        {
            while (true)
            {
                List<TFL_PointXYZ> list_PointXYZ = new List<TFL_PointXYZ>();

                var watch = new System.Diagnostics.Stopwatch();
                watch.Start();

                Thread.Sleep(300);
                index_frame_scan++;
                for (int i = 0; i < size_pixel; i++)
                {
                    list_PointXYZ.Add(
                        new TFL_PointXYZ(
                            _random.Next(0, 255),
                            _random.Next(0, 255),
                            _random.Next(0, 255))
                        );
                }
                list_frame_scan.ListPointCloud.Add(list_PointXYZ);
                watch.Stop();
                //Console.WriteLine("Index Frame: " + index_frame_scan + $" *** time: {watch.ElapsedMilliseconds} ms");
            }
        }

        private static void ThreadTwo()
        {
            while (true)
            {
                Console.WriteLine("Count frame in list" + list_frame_scan.ListPointCloud.Count());
                Console.WriteLine("*************************************************************");

                for (int i = 0; i < list_frame_scan.ListPointCloud.Count(); i++)
                {
                    for (int j = 0; j < list_frame_scan.ListPointCloud[i].Count(); j++)
                    {
                        Console.WriteLine("Index pixel " + j + " x: " + list_frame_scan.ListPointCloud[i][j].x
                            + " y: " + list_frame_scan.ListPointCloud[i][j].y
                            + " z: " + list_frame_scan.ListPointCloud[i][j].z);
                    }
                    Console.WriteLine(list_frame_scan.ListPointCloud.Count());
                    list_frame_scan.ListPointCloud.RemoveAt(i);
                    Console.ReadLine();
                }
            }
            
        }
    }
}
*/