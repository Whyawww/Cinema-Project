using Cinema.Model.Entity;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Cinema.Help
{
    public class GrabUser
    {
        private Users user;
        private string SessionPath;
        private string directoryPath;

        public GrabUser()
        {
            directoryPath = Path.Combine(Path.GetTempPath(), "CinemaApp");
            SessionPath = Path.Combine(directoryPath, "Session.json");
        }

        public bool CheckSession()
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            return (File.Exists(SessionPath)) ? true : false;
        }

        public Users Data()
        {
            if (CheckSession())
            {
                string data = File.ReadAllText(SessionPath);
                if (!String.IsNullOrEmpty(data))
                {
                    Users user = JsonConvert.DeserializeObject<Users>(data);
                    return user;
                }
                else
                {
                    return user;
                }
            }
            else
            {
                return user;
            }
        }

        public bool WriteSession(Users user)
        {
            if (CheckSession())
            {
                DeleteSession();
            }

            string json = JsonConvert.SerializeObject(user);
            using (StreamWriter sw = File.CreateText(SessionPath))
            {
                sw.WriteLine(json);
            }

            return (CheckSession()) ? true : false;
        }

        public bool DeleteSession()
        {
            if (CheckSession())
            {
                File.Delete(SessionPath);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
