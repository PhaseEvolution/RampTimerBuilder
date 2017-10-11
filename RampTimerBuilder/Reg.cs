using Microsoft.Win32;
using System;

namespace RampTimerBuilder
{
    static class Reg
    {
        //registry reads and writes
        public static String[] Get_REG_MULTI_SZ(RegistryHive hive, string keyPath, string value)
        {
            var reg = RegistryKey.OpenBaseKey(hive, RegistryView.Default);
            var key = reg.OpenSubKey(keyPath);
            try
            {
                try
                {
                    return (String[])key.GetValue(value);
                }
                catch (InvalidCastException)
                {
                    return new String[1] { (string)key.GetValue(value) };
                }
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        public static void Set_REG_MULTI_SZ(RegistryHive hive, string keyPath, string keyName, String[] values, RegistryValueKind valueKind)
        {
            var reg = RegistryKey.OpenBaseKey(hive, RegistryView.Default);
            var key = reg.CreateSubKey(keyPath);
            key.SetValue(keyName, values, valueKind);
        }
    }
}
