using IKProject_2512.Areas.Platform.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IKProject_2512.Models
{
    public class ProjectMethods
    {
        public ProjectMethods()
        {

        }
        public static string NewPasswordComposition()
        {
            Random rnd = new Random();
            StringBuilder strBuild = new StringBuilder();
            for (int i = 0; i < 8; i++)
            {
                int ACIINumber = rnd.Next(32, 126);
                char ASCIIChar = Convert.ToChar(ACIINumber);
                strBuild.Append(ASCIIChar);
            }
            string randomPassword = strBuild.ToString();
            return randomPassword;
        }

        public static string RemoveTurkishChars(string text)
        {
            char[] charStr = text.ToCharArray();
            string updatedStr = "";
            for (int i = 0; i < charStr.Length; i++)
            {
                switch (charStr[i].ToString())
                {
                    case "ç":
                        updatedStr = updatedStr + "c";
                        break;
                    case "ğ":
                        updatedStr = updatedStr + "g";
                        break;
                    case "ı":
                        updatedStr = updatedStr + "i";
                        break;
                    case "ö":
                        updatedStr = updatedStr + "o";
                        break;
                    case "ş":
                        updatedStr = updatedStr + "s";
                        break;
                    case "ü":
                        updatedStr = updatedStr + "u";
                        break;
                    default:
                        updatedStr = updatedStr + charStr[i].ToString();
                        break;
                }
            }
            return updatedStr;
        }
        public static string RemoveInfoPart(string text)
        {
            return text.Substring(4);

        }

            public static PlatformMgrAddModel PM_PhotoFileMethod(PlatformMgrAddModel platformManager)
        {
            //string wwwRootPath = _hostEnvironment.WebRootPath;
            //string fileName = Path.GetFileNameWithoutExtension(platformManager.PhotoFile.FileName);
            //string extension = Path.GetExtension(platformManager.PhotoFile.FileName);

            //platformManager.PhotoPath = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            ////string path = Path.Combine(wwwRootPath + "/ImageFile", fileName);
            //using (var fileStream = new FileStream(path, FileMode.Create))
            //{
            //    platformManager.PhotoFile.CopyTo(fileStream);
            //}
            return platformManager;
        }

        public static string GetDisplayName(Enum value)
        {
            return value.GetType()?
           .GetMember(value.ToString())?.First()?
           .GetCustomAttribute<DisplayAttribute>()?
           .Name;
        }


    }
}
