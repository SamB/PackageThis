using System;
using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;

namespace MiscFuncs
{
    static public class Misc
    {
        public static string QuotedPath(string path)  //Adds quotes if spaces are found
        {
            if (path.Contains(" "))
                return "\"" + path + "\"";
            else
                return path;
        }
    }

    static public class HV1   //Help Viewer 1.x (VS 2010 help)
    {
        public static String RuntimeDir 
        {
            get  // The HV 1.x app is a 64bit application on a 64bit OS
            {
                string programFilesPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
                return Path.Combine(programFilesPath, @"Microsoft Help Viewer\v1.0");
            }
        }

        public static String HelpManagerPath
        {
            get { return Path.Combine(RuntimeDir, @"HelpLibManager.exe"); }
        }

        public static string HlpViewerPath
        {
            get { return Path.Combine(RuntimeDir, @"HlpViewer.exe"); }
        }
    }


    static public class HV2   //Help Viewer 2.x (VS 2012 Help)
    {
        public static String RuntimeDir 
        {
            get  // The HV 2.0 app is always 32bit application 
            {
                string programFilesPath = "";
                if (Environment.Is64BitOperatingSystem)
                    programFilesPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
                if (String.IsNullOrEmpty(programFilesPath))
                    programFilesPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
                return Path.Combine(programFilesPath, @"Microsoft Help Viewer\v2.0");
            }
        }

        public static String HelpManagerPath
        {
            get { return Path.Combine(RuntimeDir, @"HlpCtntMgr.exe"); }
        }

        public static string HlpViewerPath 
        {
            get { return Path.Combine(RuntimeDir, @"HlpViewer.exe"); }
        }
    }

}


