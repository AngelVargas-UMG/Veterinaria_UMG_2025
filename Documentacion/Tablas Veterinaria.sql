-- Tabla de Catálogo: Estado
-- Finalidad: Almacena los diferentes estados que se pueden aplicar a registros en otras tablas (ej. usuarios, mascotas, citas).
-- Esto centraliza la gestión de estados y evita el uso de texto libre.
-- Ejemplo de registro: (1, 'Activo'), (2, 'Inactivo'), (3, 'Pendiente').
CREATE TABLE Estado (
    EstadoID INT PRIMARY KEY IDENTITY(1,1),
    NombreEstado NVARCHAR(50) NOT NULL
);

-- Tabla de Catálogo: Especialidad
-- Finalidad: Almacena las especialidades médicas de los veterinarios.
-- Ejemplo de registro: (1, 'Cardiología Veterinaria'), (2, 'Dermatología Animal').
CREATE TABLE Especialidad (
    EspecialidadID INT PRIMARY KEY IDENTITY(1,1),
    NombreEspecialidad NVARCHAR(100) NOT NULL
);

-- Tabla de Catálogo: EstadoSalud
-- Finalidad: Define los posibles estados de salud de una mascota.
-- Ejemplo de registro: (1, 'Saludable'), (2, 'En Tratamiento'), (3, 'Crítico').
CREATE TABLE EstadoSalud (
    EstadoSaludID INT PRIMARY KEY IDENTITY(1,1),
    NombreEstadoSalud NVARCHAR(100) NOT NULL
);

-- Tabla de Catálogo: Especie
-- Finalidad: Almacena las diferentes especies de animales que atiende la veterinaria.
-- Ejemplo de registro: (1, 'Canino'), (2, 'Felino'), (3, 'Ave').
CREATE TABLE Especie (
    EspecieID INT PRIMARY KEY IDENTITY(1,1),
    NombreEspecie NVARCHAR(100) NOT NULL
);

-- Tabla de Catálogo: MotivosVisita
-- Finalidad: Contiene los motivos comunes por los que un dueño lleva a su mascota a una cita o visita.
-- Ejemplo de registro: (1, 'Consulta de rutina'), (2, 'Vacunación anual'), (3, 'Emergencia por herida').
CREATE TABLE MotivosVisita (
    MotivoID INT PRIMARY KEY IDENTITY(1,1),
    DescripcionMotivo NVARCHAR(255) NOT NULL
);

-- Tabla: Roles
-- Finalidad: Define los roles de los usuarios dentro del sistema para gestionar permisos y accesos.
-- Ejemplo de registro: (1, 'Administrador', 'Acceso total al sistema').
CREATE TABLE Roles (
    RolID INT PRIMARY KEY IDENTITY(1,1),
    NombreRol NVARCHAR(50) NOT NULL,
    Descripcion NVARCHAR(255)
);

-- Tabla: Usuarios
-- Finalidad: Almacena la información de todas las personas que interactúan con el sistema, incluyendo dueños de mascotas y personal.
-- Ejemplo de registro: (1, 'Juan', 'Pérez', 'juan.perez@email.com', '555-1234', 'Calle Falsa 123', 'hash_contraseña', 1, 2).
CREATE TABLE Usuarios (
    UsuarioID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    Email NVARCHAR(255) UNIQUE NOT NULL,
    Telefono NVARCHAR(20),
    Direccion NVARCHAR(255),
    ContrasenaHash NVARCHAR(255) NOT NULL,
    EstadoID INT NOT NULL,
    RolID INT NOT NULL,
    FOREIGN KEY (EstadoID) REFERENCES Estado(EstadoID),
    FOREIGN KEY (RolID) REFERENCES Roles(RolID)
);

-- Tabla: Veterinarios
-- Finalidad: Contiene información específica del personal veterinario, extendiendo la tabla de Usuarios.
-- Ejemplo de registro: (1, 101, 'VET-98765', 1, 'L-V 9am-5pm', 'Notas sobre el Dr. Smith'). (UsuarioID 101 corresponde a un usuario existente).
CREATE TABLE Veterinarios (
    VeterinarioID INT PRIMARY KEY IDENTITY(1,1),
    UsuarioID INT UNIQUE NOT NULL,
    NumeroLicencia NVARCHAR(50) UNIQUE,
    EspecialidadID INT,
    HorarioAtencion NVARCHAR(100),
    Notas NVARCHAR(MAX),
    FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID),
    FOREIGN KEY (EspecialidadID) REFERENCES Especialidad(EspecialidadID)
);

-- Tabla: Mascotas
-- Finalidad: Almacena toda la información relevante de las mascotas de los clientes.
-- Ejemplo de registro: (1, 'Perry', 1, 'Salchicha', 'Macho', '2020-05-10', 'Marrón', 202, 1, 1). (EspecieID 1 es 'Canino', UsuarioID 202 es el dueño).
CREATE TABLE Mascotas (
    MascotaID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    EspecieID INT NOT NULL,
    Raza NVARCHAR(50),
    Sexo NVARCHAR(10),
    FechaNacimiento DATE,
    Color NVARCHAR(50),
    UsuarioID INT NOT NULL, -- Dueño
    EstadoSaludID INT,
    EstadoID INT NOT NULL,
    FOREIGN KEY (EspecieID) REFERENCES Especie(EspecieID),
    FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID),
    FOREIGN KEY (EstadoSaludID) REFERENCES EstadoSalud(EstadoSaludID),
    FOREIGN KEY (EstadoID) REFERENCES Estado(EstadoID)
);

-- Tabla unificada: ProcedimientosMedicos
-- Finalidad: Almacena tanto vacunas como tratamientos en una sola tabla para simplificar la gestión. Un campo 'EsVacuna' diferencia el tipo.
-- Ejemplo de registro (Vacuna): (1, 'Vacuna contra la Rabia', 'Dosis anual', 25.00, 1).
-- Ejemplo de registro (Tratamiento): (2, 'Desparasitación interna', 'Tableta oral', 15.00, 0).
CREATE TABLE ProcedimientosMedicos (
    ProcedimientoID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(MAX),
    Costo DECIMAL(10, 2),
    EsVacuna BIT NOT NULL DEFAULT 0 -- 1 para Vacuna, 0 para Tratamiento
);

-- Tabla: Visitas
-- Finalidad: Registra cada visita de una mascota a la clínica, incluyendo quién la atendió, el motivo y los costos generales.
-- Ejemplo de registro: (1, 1, 1, 202, '2023-10-26 10:00', 2, 30.00, 55.00, 1, 'La mascota parece saludable').
CREATE TABLE Visitas (
    VisitaID INT PRIMARY KEY IDENTITY(1,1),
    MascotaID INT NOT NULL,
    VeterinarioID INT NOT NULL,
    OwnerID INT NOT NULL,
    FechaVisita DATETIME NOT NULL,
    MotivoID INT NOT NULL,
    CostoConsulta DECIMAL(10, 2),
    CostoTotal DECIMAL(10, 2),
    EstadoID INT NOT NULL,
    Observaciones NVARCHAR(MAX),
    FOREIGN KEY (MascotaID) REFERENCES Mascotas(MascotaID),
    FOREIGN KEY (VeterinarioID) REFERENCES Veterinarios(VeterinarioID),
    FOREIGN KEY (OwnerID) REFERENCES Usuarios(UsuarioID),
    FOREIGN KEY (MotivoID) REFERENCES MotivosVisita(MotivoID),
    FOREIGN KEY (EstadoID) REFERENCES Estado(EstadoID)
);

-- Tabla de relación: VisitaProcedimientos
-- Finalidad: Detalla qué procedimientos (vacunas o tratamientos) se realizaron durante una visita específica.
-- Ejemplo de registro: (1, 1, 1, 1, 25.00, 25.00, 'Aplicado'). (En la VisitaID 1 se aplicó el ProcedimientoID 1).
CREATE TABLE VisitaProcedimientos (
    VisitaProcedimientoID INT PRIMARY KEY IDENTITY(1,1),
    VisitaID INT NOT NULL,
    ProcedimientoID INT NOT NULL,
    Cantidad INT,
    CostoUnitario DECIMAL(10, 2),
    Subtotal DECIMAL(10, 2),
    EstadoProcedimiento NVARCHAR(50),
    FOREIGN KEY (VisitaID) REFERENCES Visitas(VisitaID),
    FOREIGN KEY (ProcedimientoID) REFERENCES ProcedimientosMedicos(ProcedimientoID)
);

-- Tabla: HistorialMedico
-- Finalidad: Funciona como un expediente clínico de la mascota, registrando eventos y diagnósticos importantes a lo largo del tiempo.
-- Ejemplo de registro: (1, 1, '2022-03-15', 'Diagnóstico de alergia a pulgas.', 1).
CREATE TABLE HistorialMedico (
    HistorialID INT PRIMARY KEY IDENTITY(1,1),
    MascotaID INT NOT NULL,
    FechaRegistro DATETIME NOT NULL,
    Descripcion NVARCHAR(MAX),
    VeterinarioID INT NOT NULL,
    FOREIGN KEY (MascotaID) REFERENCES Mascotas(MascotaID),
    FOREIGN KEY (VeterinarioID) REFERENCES Veterinarios(VeterinarioID)
);

-- Tabla: Citas
-- Finalidad: Gestiona la programación de citas futuras para las mascotas.
-- Ejemplo de registro: (1, 1, 1, 202, '2023-11-15 11:30', 1, 3). (EstadoID 3 es 'Pendiente').
CREATE TABLE Citas (
    CitaID INT PRIMARY KEY IDENTITY(1,1),
    MascotaID INT NOT NULL,
    VeterinarioID INT NOT NULL,
    OwnerID INT NOT NULL,
    FechaHora DATETIME NOT NULL,
    MotivoID INT NOT NULL,
    EstadoID INT NOT NULL,
    FOREIGN KEY (MascotaID) REFERENCES Mascotas(MascotaID),
    FOREIGN KEY (VeterinarioID) REFERENCES Veterinarios(VeterinarioID),
    FOREIGN KEY (OwnerID) REFERENCES Usuarios(UsuarioID),
    FOREIGN KEY (MotivoID) REFERENCES MotivosVisita(MotivoID),
    FOREIGN KEY (EstadoID) REFERENCES Estado(EstadoID)
);

-- Tabla: Notificaciones
-- Finalidad: Almacena los mensajes o recordatorios que se envían a los usuarios, como recordatorios de citas.
-- Ejemplo de registro: (1, 202, 1, 'Recordatorio: Su cita para Perry es mañana a las 11:30.', '2023-11-14 12:00', 1).
CREATE TABLE Notificaciones (
    NotificacionID INT PRIMARY KEY IDENTITY(1,1),
    UsuarioID INT NOT NULL,
    CitaID INT,
    Mensaje NVARCHAR(MAX) NOT NULL,
    FechaEnvio DATETIME NOT NULL,
    EstadoID INT NOT NULL,
    FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID),
    FOREIGN KEY (CitaID) REFERENCES Citas(CitaID),
    FOREIGN KEY (EstadoID) REFERENCES Estado(EstadoID)
);

-- Tabla: Servicios
-- Finalidad: Define servicios adicionales que ofrece la veterinaria y que no son procedimientos médicos, como peluquería o venta de productos.
-- Ejemplo de registro: (1, 'Corte de Pelo Canino', 'Incluye baño y corte de uñas', 35.00).
CREATE TABLE Servicios (
    ServicioID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255),
    Precio DECIMAL(10, 2)
);

-- Tabla: Facturas
-- Finalidad: Encabezado de las facturas generadas a los clientes por los servicios y procedimientos recibidos.
-- Ejemplo de registro: (1, 202, '2023-10-26', 55.00, 1). (EstadoID 1 puede ser 'Pagada').
CREATE TABLE Facturas (
    FacturaID INT PRIMARY KEY IDENTITY(1,1),
    UsuarioID INT NOT NULL,
    Fecha DATETIME NOT NULL,
    Total DECIMAL(10, 2),
    EstadoID INT NOT NULL,
    FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID),
    FOREIGN KEY (EstadoID) REFERENCES Estado(EstadoID)
);

-- Tabla: DetalleFactura
-- Finalidad: Desglosa los conceptos (servicios o procedimientos de una visita) que se incluyen en una factura.
-- Ejemplo de registro: (1, 1, NULL, 1, 1, 25.00, 0.00, 25.00). (Detalla el VisitaProcedimientoID 1 en la FacturaID 1).
CREATE TABLE DetalleFactura (
    DetalleID INT PRIMARY KEY IDENTITY(1,1),
    FacturaID INT NOT NULL,
    ServicioID INT,
    VisitaProcedimientoID INT, -- Opcional, para facturar procedimientos de una visita
    Cantidad INT,
    PrecioUnitario DECIMAL(10, 2),
    Descuento DECIMAL(10, 2),
    Subtotal DECIMAL(10, 2),
    FOREIGN KEY (FacturaID) REFERENCES Facturas(FacturaID),
    FOREIGN KEY (ServicioID) REFERENCES Servicios(ServicioID),
    FOREIGN KEY (VisitaProcedimientoID) REFERENCES VisitaProcedimientos(VisitaProcedimientoID)
);
