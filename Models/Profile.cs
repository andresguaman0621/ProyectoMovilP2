using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMovilP2.Models
{
    class Profile
    {
        public string NombreUsuario { get; set; }
        public string Title => AppInfo.Name;
        public string Version => AppInfo.VersionString;
    }
}
