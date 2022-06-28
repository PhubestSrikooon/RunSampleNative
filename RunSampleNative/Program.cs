using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace RunSampleNative
{
    class Program
    {
        static void Main(string[] args)
        {

            string logFile = "Log.txt";
            string missedFilesList = "missedFiles.txt";
            string sampleFolder = "Sample";
            string[] fileList = { };
            List<string> missedList = new List<string>();
            Process[] processes;
            StreamWriter writer;
            Forms.monitor_process monitor_ProcessF = new Forms.monitor_process();
            double fileLength = 0;
            double missed = 0;
            double blocked = 0;
            double removed = 0;
            int allsec = 0;
            int sec = 0;
            int minute = 0;
            int hour = 0;
            double proactive = 0;
            double progress = 0;

            try
            {
                if (Directory.Exists(sampleFolder) && Directory.GetFiles(sampleFolder).Length > 0)
                {
                    fileLength = Directory.GetFiles(sampleFolder, "*.exe").Length;
                    fileList = Directory.GetFiles(sampleFolder, "*.exe");
                }
                else
                {
                    Console.WriteLine("Sorry 'Sample' folder doesn't exist or no file in the folder.");
                    Console.Write("Press any key to close..."); Console.ReadKey();
                    Environment.Exit(1);
                }
                if (File.Exists(logFile))
                {
                    File.Delete(logFile);
                }
            }
            catch
            {

            }

            void entryPoint()
            {
                Console.Clear();
                Console.WriteLine("RunSampleNative");
                Console.WriteLine($"All files : {fileLength.ToString()}");
                Console.Write("Real-time Protection turn on? ");
                string ready = Console.ReadLine();
                if (ready == "yes" || ready == "y")
                {
                    Console.WriteLine("Starting");
                    Thread.Sleep(500);
                    Console.Clear();

                    start_test();
                }
                else if (ready == "ap" || ready.ToLower() == "add process")
                {
                    DialogResult dnS = monitor_ProcessF.ShowDialog();
                    if (dnS == DialogResult.OK)
                    {
                        entryPoint();
                    }
                }
                else if (ready == "test")
                {
                    foreach (string p in monitor_ProcessF.selectedProcess)
                    {
                        Console.WriteLine(p);
                    }
                    Console.ReadKey();
                    entryPoint();
                }
                else
                {
                    Environment.Exit(1);
                }
            }

            entryPoint();

            void calculateProactiveScore()
            {
                proactive = Math.Round(((fileLength - missed)/fileLength) * 100, 2);
            }

            void WriteLog(string text,string file)
            {
                try
                {
                    if (File.Exists(file))
                    {
                        writer = File.AppendText(file);
                        writer.WriteLine(text);
                        writer.Close();
                    }
                    else
                    {
                        //File.Create(file);
                        writer = new StreamWriter(file);
                        writer.WriteLine(text);
                        writer.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine($"Something went wrong!\n{ex}");
                }
            }


            void start_test()
            {
                double index = 0;
                System.Timers.Timer timer = new System.Timers.Timer(1000);
                timer.Elapsed += (s,e) => {
                    sec++;
                    allsec++;
                    if (sec > 59)
                    {
                        minute++;
                        sec = 0;
                    }
                    if (minute > 59)
                    {
                        hour++;
                        minute = 0;
                    }
                };
                timer.Start();

                try
                {
                    foreach (string v in fileList)
                    {
                        calculateProactiveScore();
                        string processName = Path.GetFileName(v);
                        Process current_R;
                        if (File.Exists(v))
                        {
                            processes = Process.GetProcessesByName(processName);
                            index++;
                            progress = Convert.ToInt32((index / fileLength) * 100);
                            try
                            {
                                current_R = Process.Start(Path.GetFullPath(v));
                                missed++;
                                missedList.Add(processName);
                                WriteLog(processName,missedFilesList);
                                calculateProactiveScore();
                                Console.WriteLine($"{index}/{fileLength} {(progress)}% \n {processName} execute sucessfull.\n Antivirus missed: {missed} ,Blocked : {blocked} \n Proactive score : {proactive}%\n\n");
                                WriteLog($"{index}/{fileLength} {(progress)}% \n {processName} execute sucessfull.\n Antivirus missed: {missed} ,Blocked : {blocked} \n Proactive score : {proactive}%\n\n",logFile);
                            }
                            catch
                            {
                                if (!File.Exists(Path.GetFullPath(v)))
                                {
                                    removed++;
                                }
                                blocked++;
                                calculateProactiveScore();
                                Console.WriteLine($"{index}/{fileLength} {(progress)}% \n {processName} has blocked.\n Antivirus blocked sucessfully!: {blocked} ,Missed : {missed} \n Proactive score : {proactive}%\n\n");
                                WriteLog($"{index}/{fileLength} {(progress)}% \n {processName} has blocked.\n Antivirus blocked sucessfully!: {blocked} ,Missed : {missed} \n Proactive score : {proactive}%\n\n",logFile);
                            }
                        }
                        else
                        {
                            blocked++;
                            calculateProactiveScore();
                            Console.WriteLine($"{index}/{fileLength} {progress}% \n {processName} this file doesn't exist maybe it has already removed by antivirus?\n Blocked : {blocked} ,Missed : {missed} \n Proactive score : {proactive}%\n\n");
                            WriteLog($"{index}/{fileLength} {progress}% \n {processName} this file doesn't exist maybe it has already removed by antivirus?\n Blocked : {blocked} ,Missed : {missed} \n Proactive score : {proactive}%\n\n", logFile);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.ReadKey(); 
                }


                Console.WriteLine($"Missed Files : {missed}");
                WriteLog($"Missed Files : {missed}", logFile);
                foreach (string v in missedList.ToArray())
                {
                    Console.WriteLine(v);
                    WriteLog(v,logFile);
                }
                Console.WriteLine("\n\n\n");
                WriteLog("\n\n\n", logFile);

                calculateProactiveScore();
                double removalFile = Directory.GetFiles(sampleFolder,"*.exe").Length;
                double removalRate = (fileLength - removalFile) / fileLength * 100;
                Console.WriteLine($"Task finished \n Time > {hour}:{minute}:{sec} \n Total files : {fileLength} \n Blocked : {blocked} \n Missed : {missed} \n RemoveRate : {removalRate}% \n Score : {proactive}%");
                WriteLog($"Task finished \n Time > {hour}:{minute}:{sec} \n Total files : {fileLength} \n Blocked : {blocked} \n Missed : {missed} \n RemoveRate : {removalRate}% \n Score : {proactive}%", logFile);
                Console.ReadKey();
            }
        }
    }
}
