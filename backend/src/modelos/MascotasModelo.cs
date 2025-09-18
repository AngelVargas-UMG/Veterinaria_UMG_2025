namespace api_veterinaria.src.modelos
{
    public class MascotasModelo
    {
        public int MascotaID { get;  }
        public string Nombre { get;  } = string.Empty;
        public int? EspecieID { get;  }
        public string? Raza { get;  }
        public string? Sexo { get;  }
        public DateTime? FechaNacimiento { get;  }
        public string? Color { get;  }
        public string? NombreEspecie { get;  }
        public string Usuario { get;  } = string.Empty;
        public string NombreEstado { get;  } = string.Empty; 
        public MascotasModelo(int MascotaID, string Nombre, int EspecieID, string Raza, string Sexo, DateTime FechaNacimiento, string Color, string NombreEspecie, string Usuario, string NombreEstado)
        {
            this.MascotaID = MascotaID;
            this.Nombre = Nombre;
            this.EspecieID = EspecieID;
            this.Raza = Raza;
            this.Sexo = Sexo;
            this.FechaNacimiento = FechaNacimiento;
            this.Color = Color;
            this.NombreEspecie = NombreEspecie;
            this.Usuario = Usuario;
            this.NombreEstado = NombreEstado;
        }
    }
}
