using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Bunk_Mate
{
    class UniversalValues
    {
        
      
        public static string PASSWORD=Properties.Settings.Default.PASSWORD;
        public static string USERNAME= Properties.Settings.Default.USERNAME;
      
        
        public static bool changed = false;
       
        public static bool DoExist()
        {
            if (USERNAME != null || PASSWORD != null) {  return true; }
            else { return false; }
        }
        public static DateTime SyncTime=Properties.Settings.Default.SyncTime;
  
       
        public static DataSet StudentData=new DataSet();
        public static void Load()
        {
            if (DoExist())
            {
                
                StudentData.ReadXml("StudentData.xml");
            }
        }
        public static void Save()
        {
            if (DoExist())
            {
                StudentData.WriteXml("StudentData.xml");
            }

        }

    }
}
