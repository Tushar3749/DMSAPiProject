using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DMS.Utility.Library
{
    public static class Scripting
    {
        public static string Error = "";
        public static Boolean readFile(ref string SourceString, string FileName)
        {
            try
            {
                StreamReader sr = new StreamReader(FileName);
                SourceString = sr.ReadToEnd();
                sr.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string readFile(string FileName)
        {

            StreamReader sr = new StreamReader(FileName);
            var SourceString = sr.ReadToEnd();
            sr.Close();
            return SourceString;
        }

        public static Boolean writeFile(ref string SourceString, string FileName, Boolean Append=false)
        {
            try
            {
                StreamWriter sw = new StreamWriter(FileName, Append);
                sw.Write(SourceString);
                sw.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Boolean deleteFile(string FileName)
        {
            try
            {
                if (File.Exists(FileName))
                {
                    File.Delete(FileName);
                    return true;
                }
                else return true;
            }
            catch
            {
                return false;
            }
        }

        public static Boolean CheckAndCreateDir(string Dir)
        {
            try
            {
                Directory.CreateDirectory(Dir);
                if (Directory.Exists(Dir)) return true;
            }
            catch { }

            try
            {
                string[] dr = Dir.Split('\\');
                string curDir = "";

                foreach (string st in dr)
                {

                    if (string.IsNullOrEmpty(st) || st == "\\" || st == @"\") continue;

                    if (curDir.Length == 0) curDir = st;
                    else curDir = curDir + "\\" + st;
                    DirectoryInfo di = new DirectoryInfo(curDir);
                    if (di.Exists == false)
                    {
                        di.Create();
                    }
                }

                return true;
            }
            catch(Exception ex) { Error = ex.Message; return false; }
        }

        public static string getFileExtension(string FileName)
        {
            try
            {
                string[] st = FileName.Split(".");
                return st[st.Length - 1];
            }
            catch { return FileName; }
        }

        public static int randomNumber(int min, int max)
        {
            try
            {
                Random random = new Random();
                return random.Next(min, max);
            }
            catch { return min; }
        }
    }
}
