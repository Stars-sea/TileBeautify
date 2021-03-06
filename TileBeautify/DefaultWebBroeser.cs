﻿using Microsoft.Win32;

namespace TileBeautify {
    //获取ie浏览器文件位置，不知道怎么获取默认浏览器位置
    // 注册表 HKEY_LOCAL_MACHINE\SOFTWARE\Clients\StartMenuInternet\: 默认浏览器名字
    // 注册表 HKEY_LOCAL_MACHINE\SOFTWARE\Clients\StartMenuInternet\默认浏览器名字\shell\open\command: 默认浏览器绝对路径
    class DefaultWebBroeser {
        public static string DefaultWebBrowserFilePath() {
            RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"http\shell\open\command", false);
            string path = key.GetValue("").ToString();
            if (path.Contains("\"")) {
                path = path.TrimStart('"');
                path = path.Substring(0, path.IndexOf('"'));
            }
            key.Close();
            return path;
        }
    }
}
