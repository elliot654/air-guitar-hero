using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.IO;
using System.Timers;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace MyKinect
{
    public partial class Form1 : Form
    {
        private KinectSensor sensor; //make global so it can be called to start and stop 
        Bitmap bmap;
        Pen bonePen = new Pen(Color.Cyan, 7);
        int i=0;
        Skeleton[] skeletons;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) //runs when project starts
        {
            helloc();
            sensor = KinectSensor.KinectSensors[0]; //use the 1st sensor on the list of connected sensors only have 1 but projects can run with several
            sensor.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30); //kinect starts sending rgb camera data
            sensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);//kinect starts sending depth camera data
            sensor.SkeletonStream.Enable();
            sensor.AllFramesReady += AllFramesReady; //whenever a color frame is ready run frameready method to get another frame
            sensor.Start(); //start the sensor running 
            var aTimer = new System.Timers.Timer(1000);
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 200;
            aTimer.Enabled = true;

        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            //helloc();
            outpt(skeletons);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)//runs when you close the window
        {
            sensor.Stop();//stops the sensor streams. Errors if it keeps sending data to an imageview you closed 
        }

        void AllFramesReady(object sender, AllFramesReadyEventArgs e)
        {
            ColorFrameReady(e);
            SkeletonFrameReady(e);
            //rtbStats.Text = i.ToString();
            //DepthFrameReady(e);
            //outpt(skeletons);
            //IndexFrameReady(e);
            i++;
        }

        void ColorFrameReady(AllFramesReadyEventArgs e)
        {
            ColorImageFrame ColorFrame = e.OpenColorImageFrame();//gets the new frame
            if (ColorFrame != null)
            {
                bmap = ColorToBitmap(ColorFrame); //converts the new frame to an image
                //bmap.Save(i.ToString(), ImageFormat.Bmp);
                video.Image = bmap;//displays the image
                //bmap.Save(("colour\\colour"+i.ToString() + ".bmp"), ImageFormat.Bmp);
            }                   
        }

        void SkeletonFrameReady(AllFramesReadyEventArgs e)
        {
            SkeletonFrame sFrame = e.OpenSkeletonFrame();
            if (sFrame != null)
            {
                skeletons = new Skeleton[sFrame.SkeletonArrayLength];
                sFrame.CopySkeletonDataTo(skeletons);
                DrawSkeleton(bmap, skeletons);
            }
        }
        void outpt(Skeleton[] skeletons)
        {
            //var fileStream = File.Create(i.ToString());
            if (skeletons != null)
            {
                foreach (Skeleton s in skeletons)
               {
                    if (s != null)
                    {
                        if (s.TrackingState == SkeletonTrackingState.Tracked)
                        {
                            Joint j = s.Joints[JointType.Head];
                            String JointString = (j.Position.X + ", " + j.Position.Y + ", ");
                            j = s.Joints[JointType.ShoulderCenter];
                            JointString += (j.Position.X + ", " + j.Position.Y + ", ");
                            j = s.Joints[JointType.Spine];
                            JointString += (j.Position.X + ", " + j.Position.Y + ", ");
                            j = s.Joints[JointType.ShoulderLeft];
                            JointString += (j.Position.X + ", " + j.Position.Y + ", ");
                            j = s.Joints[JointType.ElbowLeft];
                            JointString += (j.Position.X + ", " + j.Position.Y + ", ");
                            j = s.Joints[JointType.WristLeft];
                            JointString += (j.Position.X + ", " + j.Position.Y + ", ");
                            j = s.Joints[JointType.HandLeft];
                            JointString += (j.Position.X + ", " + j.Position.Y + ", ");
                            j = s.Joints[JointType.ShoulderRight];
                            JointString += (j.Position.X + ", " + j.Position.Y + ", ");
                            j = s.Joints[JointType.ElbowRight];
                            JointString += (j.Position.X + ", " + j.Position.Y + ", ");
                            j = s.Joints[JointType.WristRight];
                            JointString += (j.Position.X + ", " + j.Position.Y + ", ");
                            j = s.Joints[JointType.HandRight];
                            JointString += (j.Position.X + ", " + j.Position.Y + ", ");
                            j = s.Joints[JointType.HipCenter];
                            JointString += (j.Position.X + ", " + j.Position.Y + ", ");
                            j = s.Joints[JointType.HipLeft];
                            JointString += (j.Position.X + ", " + j.Position.Y + ", ");
                            j = s.Joints[JointType.KneeLeft];
                            JointString += (j.Position.X + ", " + j.Position.Y + ", ");
                            j = s.Joints[JointType.AnkleLeft];
                            JointString += (j.Position.X + ", " + j.Position.Y + ", ");
                            j = s.Joints[JointType.FootLeft];
                            JointString += (j.Position.X + ", " + j.Position.Y + ", ");
                            j = s.Joints[JointType.HipRight];
                            JointString += (j.Position.X + ", " + j.Position.Y + ", ");
                            j = s.Joints[JointType.KneeRight];
                            JointString += (j.Position.X + ", " + j.Position.Y + ", ");
                            j = s.Joints[JointType.AnkleRight];
                            JointString += (j.Position.X + ", " + j.Position.Y + ", ");
                            j = s.Joints[JointType.FootRight];
                            JointString += (j.Position.X + ", " + j.Position.Y + ", ");
                            System.IO.File.WriteAllText(("skeleton\\skeleton" + i.ToString() + ".csv"), JointString);
                        }
                    }
                    
                }
            }
            
        }

        void DrawSkeleton(Bitmap bmap, Skeleton[] skeletons)
        {
            Rectangle myRectangle = new Rectangle(2, 2, 630, 460);
            Region region = new Region(myRectangle);
            Graphics g = Graphics.FromImage(bmap);
            g.SetClip(region, CombineMode.Replace);

            //Bitmap bitmap = new Bitmap(Convert.ToInt32(1024), Convert.ToInt32(1024), System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g2 = Graphics.FromImage(bmap);

            foreach (Skeleton s in skeletons)
            {
                if (s.TrackingState == SkeletonTrackingState.Tracked)
                {                   
                    //spine
                    DrawBone(JointType.Head,JointType.ShoulderCenter,s, g);
                    DrawBone(JointType.ShoulderCenter,JointType.Spine,s, g);
                    DrawBone(JointType.Spine,JointType.HipCenter,s, g);
                    //left leg
                    DrawBone(JointType.HipCenter,JointType.HipLeft,s, g);
                    DrawBone(JointType.HipLeft,JointType.KneeLeft,s, g);
                    DrawBone(JointType.KneeLeft,JointType.AnkleLeft,s, g);
                    DrawBone(JointType.AnkleLeft,JointType.FootLeft,s, g);
                    //Right Leg
                    DrawBone(JointType.HipCenter,JointType.HipRight,s, g);
                    DrawBone(JointType.HipRight,JointType.KneeRight,s, g);
                    DrawBone(JointType.KneeRight,JointType.AnkleRight,s, g);
                    DrawBone(JointType.AnkleRight,JointType.FootRight,s, g);
                    //Left Arm
                    DrawBone(JointType.ShoulderCenter,JointType.ShoulderLeft,s, g);
                    DrawBone(JointType.ShoulderLeft,JointType.ElbowLeft,s, g);
                    DrawBone(JointType.ElbowLeft,JointType.WristLeft,s, g);
                    DrawBone(JointType.WristLeft,JointType.HandLeft,s, g);
                    //Right Arm
                    DrawBone(JointType.ShoulderCenter,JointType.ShoulderRight,s, g);
                    DrawBone(JointType.ShoulderRight,JointType.ElbowRight, s, g);
                    DrawBone(JointType.ElbowRight,JointType.WristRight,s, g);
                    DrawBone(JointType.WristRight,JointType.HandRight, s, g);
                }
            }
            //convert g to bitmap
            
            bmap.Save(("skel\\skel"+i.ToString()+".bmp"), ImageFormat.Bmp);
        }
        
        Point GetJoint(JointType j, Skeleton s)
        {
            SkeletonPoint Sloc = s.Joints[j].Position;      
            ColorImagePoint Cloc = sensor.CoordinateMapper.MapSkeletonPointToColorPoint(Sloc, ColorImageFormat.RgbResolution640x480Fps30);
            return new Point(Cloc.X, Cloc.Y);
        }

        void DrawBone(JointType j1,JointType j2,Skeleton s,Graphics g)
        {
            Point p1 = GetJoint(j1, s);
            Point p2 = GetJoint(j2, s);
            g.DrawLine(bonePen, p1, p2);
        }

        void DepthFrameReady(AllFramesReadyEventArgs e)
        {
            DepthImageFrame DepthFrame = e.OpenDepthImageFrame();//gets the new frame
            if (DepthFrame != null)
            {
                Bitmap bmap = DepthToBitmap(DepthFrame); //converts the new frame to an image
                video2.Image = bmap;//displays the image
                bmap.Save(("depth\\depth" + i.ToString() + ".bmp"), ImageFormat.Bmp);
            }
        }

        void IndexFrameReady(AllFramesReadyEventArgs e)
        {
            DepthImageFrame imageFrame = e.OpenDepthImageFrame();
            if (imageFrame != null)
            {
                short[] pixeldata = new short[imageFrame.PixelDataLength];
                imageFrame.CopyPixelDataTo(pixeldata);
                int[] depth = new int[imageFrame.Width * imageFrame.Height];
                int[] player = new int[imageFrame.Width * imageFrame.Height];
                int[] playercoded = new int[imageFrame.PixelDataLength];
                for (int i = 0; i < depth.Length; i++)
                {
                    player[i] = pixeldata[i] & DepthImageFrame.PlayerIndexBitmask;
                    depth[i] = ((ushort)pixeldata[i]) >>DepthImageFrame.PlayerIndexBitmaskWidth;
                    playercoded[i] = 0;
                    if ((player[i] & 0x01) == 0x01)
                        playercoded[i] |= 0xFF0000;
                    if ((player[i] & 0x02) == 0x02)
                        playercoded[i] |= 0x00FF00;
                    if ((player[i] & 0x04) == 0x04)
                        playercoded[i] |= 0x0000FF;
                }
                video3.Image = IndexToBitmap(playercoded, imageFrame.Width, imageFrame.Height);
            }
         }

        Bitmap IndexToBitmap(int[] array,int w, int h)
        {
            Bitmap bmap = new Bitmap(w,h,PixelFormat.Format32bppRgb);
            BitmapData bmapdata = bmap.LockBits(new Rectangle(0, 0, w, h),ImageLockMode.WriteOnly,bmap.PixelFormat);
            IntPtr ptr = bmapdata.Scan0;
            Marshal.Copy(array,0,ptr,array.Length);
            bmap.UnlockBits(bmapdata);
            return bmap;
        }


        Bitmap ColorToBitmap(ColorImageFrame Image)
        {
            byte[] pixeldata = new byte[Image.PixelDataLength];
            Image.CopyPixelDataTo(pixeldata);
            Bitmap bmap = new Bitmap(Image.Width,Image.Height,PixelFormat.Format32bppRgb);
            BitmapData bmapdata = bmap.LockBits(new Rectangle(0, 0,Image.Width, Image.Height),ImageLockMode.WriteOnly,bmap.PixelFormat);
            IntPtr ptr = bmapdata.Scan0;
            Marshal.Copy(pixeldata, 0, ptr,Image.PixelDataLength);
            bmap.UnlockBits(bmapdata);
            return bmap;
        }

        Bitmap DepthToBitmap(DepthImageFrame Image)
        {
            short[] pixeldata = new short[Image.PixelDataLength];
            Image.CopyPixelDataTo(pixeldata);
            Bitmap bmap = new Bitmap(Image.Width, Image.Height, PixelFormat.Format16bppRgb565);
            BitmapData bmapdata = bmap.LockBits(new Rectangle(0, 0, Image.Width, Image.Height), ImageLockMode.WriteOnly, bmap.PixelFormat);
            IntPtr ptr = bmapdata.Scan0;
            Marshal.Copy(pixeldata, 0, ptr, Image.PixelDataLength);
            bmap.UnlockBits(bmapdata);
            return bmap;
        }

        //new processy thing for c++ goes here-ish 
        void helloc()
        {
            Process process = new Process();
            process.StartInfo.FileName = "C:/Users/elliot/Documents/Visual Studio 2015/Projects/opencv8/Release/opencv8.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            rtbHead.Text=output;
            process.WaitForExit();
        }
    }
}
