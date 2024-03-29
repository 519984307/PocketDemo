﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PocketDemo1
{
    public class Log
    {
        /// <summary>
        /// 获取日志信息
        /// </summary>
        /// <param name="Message"></param>
        public static void GetLogMessage(string LogFileaName, string Message)
        {
            string ErrTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string ErrMsg = Message;
            string FilePath = AppDomain.CurrentDomain.BaseDirectory + @"\\" + LogFileaName + "\\";
            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }
            string FileName = FilePath + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
            if (GetFileSize(FileName) > 1024 * 3)
            {
                CopyToBak(FileName);
            }
            StreamWriter swlog = new StreamWriter(FileName, true);
            swlog.WriteLine("" + ErrTime);
            swlog.WriteLine("" + ErrMsg);
            swlog.WriteLine("\r\n");
            swlog.Flush();
            swlog.Close();
        }


        private static long GetFileSize(string FileName)
        {
            long strRe = 0;
            if (File.Exists(FileName))
            {
                FileStream MyFs = new FileStream(FileName, FileMode.Open);
                strRe = MyFs.Length / 1024;
                MyFs.Close();
                MyFs.Dispose();
            }
            return strRe;
        }


        private static void CopyToBak(string sFileName)
        {
            int FileCount = 0;
            string sBakName = "";
            do
            {
                FileCount++;
                sBakName = sFileName + "." + FileCount.ToString() + ".BAK";
            }
            while (File.Exists(sBakName));
            File.Copy(sFileName, sBakName);
            File.Delete(sFileName);
        }


    }

}
