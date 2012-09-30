using System;
using Microsoft.Win32;
using System.Collections.Generic;

namespace PackageThis
{
    static public class Gui
    {
        static readonly string key = @"HKEY_CURRENT_USER\Software\CodePlex\PackageThis";
        //static readonly string VID_Locales_Code = "Locale-Code-";
        //static readonly string VID_Locales_Display = "Locale-Display-";
        public static readonly string VID_MshcFile = "MshcFilename";

        static public string GetString(string valueName, string defaultValue)
        {
            return (string)Registry.GetValue(key, valueName, defaultValue);
        }

        static public void SetString(string valueName, string value)
        {
            Registry.SetValue(key, valueName, value, RegistryValueKind.String);
        }

        static public bool GetBool(string valueName, bool defaultValue)
        {
            return (string)Registry.GetValue(key, valueName, (defaultValue) ? "1" : "0") == "1";
        }

        static public void SetBool(string valueName, bool value)
        {
            Registry.SetValue(key, valueName, (value) ? "1" : "0", RegistryValueKind.String);
        }


        /*
         * This was good idea (caching the locale data) and saved 15 sec of load time (Accessing from Australia).
         * However the next attempt to connect to the server also took 15 secs. So this code only delayed the problem.

        static public void SaveLocales(SortedDictionary<string, string> locales)   // Cache a list of locales info to the registry
        {
            int i = 0;
            foreach (string displayName in locales.Keys)
            {
                SetString(VID_Locales_Display + i.ToString(), displayName);                     //eg. "English (US)"
                SetString(VID_Locales_Code + i.ToString(), locales[displayName].ToLower());     //eg. "en-us" 
                i++;
            }
            //Write end-of-list terminator
            SetString(VID_Locales_Display + i.ToString(), "");
            SetString(VID_Locales_Code + i.ToString(), "");
        }

        static public SortedDictionary<string, string> GetLocales()   // Cache a list of locales info to the registry
        {
            SortedDictionary<string, string> locales = new SortedDictionary<string, string>();

            int i = 0;
            do
            {
                String displayName = GetString(VID_Locales_Display + i.ToString(), "");
                String codeName = GetString(VID_Locales_Code + i.ToString(), "");
                if (codeName == "" || displayName == "")
                    break;
                if (locales.ContainsKey(displayName) == false)
                    locales.Add(displayName, codeName);
                i++;
            } while (true);

            return locales;
        }

        */

    }
}


