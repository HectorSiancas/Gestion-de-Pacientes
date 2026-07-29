-- ============================================================
-- BASE DE DATOS: sistema_clinico  (MySQL / MariaDB - XAMPP)
-- Verificado 1 a 1 contra las entidades JPA reales de:
--   sistemas-master/src/main/java/com/utp/sistemas/entities/*.java
-- (longitudes de columna, nulabilidad y relaciones exactas)
-- ============================================================

CREATE DATABASE IF NOT EXISTS sistema_clinico
    CHARACTER SET utf8mb4
    COLLATE utf8mb4_unicode_ci;

USE sistema_clinico;

SET FOREIGN_KEY_CHECKS = 0;

DROP TABLE IF EXISTS Cita;
DROP TABLE IF EXISTS Diagnostico;
DROP TABLE IF EXISTS HistoriaClinica;
DROP TABLE IF EXISTS Paciente;
DROP TABLE IF EXISTS HorarioAtencion;
DROP TABLE IF EXISTS Permisos;
DROP TABLE IF EXISTS Medico;
DROP TABLE IF EXISTS Empleado;
DROP TABLE IF EXISTS Menu;
DROP TABLE IF EXISTS DiaSemana;
DROP TABLE IF EXISTS Hora;
DROP TABLE IF EXISTS Especialidad;
DROP TABLE IF EXISTS TipoEmpleado;

SET FOREIGN_KEY_CHECKS = 1;

-- ============================================================
-- 1. TABLAS CATÁLOGO (sin dependencias)
-- ============================================================

-- Entidad TipoEmpleado.java: descripcion @Column(length=25)
CREATE TABLE TipoEmpleado (
    idTipoEmpleado  INT             NOT NULL AUTO_INCREMENT,
    descripcion     VARCHAR(25)     NULL,
    estado          TINYINT(1)      NULL,
    PRIMARY KEY (idTipoEmpleado)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Entidad Especialidad.java: descripcion @Column(length=25)
CREATE TABLE Especialidad (
    idEspecialidad  INT             NOT NULL AUTO_INCREMENT,
    descripcion     VARCHAR(25)     NULL,
    estado          TINYINT(1)      NULL,
    PRIMARY KEY (idEspecialidad)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Entidad Hora.java: hora @Column(length=6)
CREATE TABLE Hora (
    idHora  INT         NOT NULL AUTO_INCREMENT,
    hora    VARCHAR(6)  NULL,
    PRIMARY KEY (idHora)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Entidad DiaSemana.java: nombreDiaSemana @Column(length=50)
CREATE TABLE DiaSemana (
    idDiaSemana     INT         NOT NULL AUTO_INCREMENT,
    nombreDiaSemana VARCHAR(50) NULL,
    PRIMARY KEY (idDiaSemana)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ============================================================
-- 2. MENU (auto-referenciada: idMenuParent -> idMenu)
-- Entidad Menu.java: nombre/url length=200
-- ============================================================
CREATE TABLE Menu (
    idMenu       INT             NOT NULL AUTO_INCREMENT,
    nombre       VARCHAR(200)    NULL,
    isSubmenu    TINYINT(1)      NULL,
    url          VARCHAR(200)    NULL,
    idMenuParent INT             NULL,
    estado       TINYINT(1)      NULL,
    `show`       TINYINT(1)      NULL,
    orden        INT             NULL,
    PRIMARY KEY (idMenu),
    CONSTRAINT FK_Menu_MenuParent FOREIGN KEY (idMenuParent)
        REFERENCES Menu (idMenu)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ============================================================
-- 3. EMPLEADO (depende de TipoEmpleado)
-- Entidad Empleado.java: nombres(50), apPaterno/apMaterno(20),
-- nroDocumento(8), imagen(500), usuario(50), clave(50)
-- ============================================================
CREATE TABLE Empleado (
    idEmpleado     INT             NOT NULL AUTO_INCREMENT,
    idTipoEmpleado INT             NOT NULL,
    nombres        VARCHAR(50)     NULL,
    apPaterno      VARCHAR(20)     NULL,
    apMaterno      VARCHAR(20)     NULL,
    nroDocumento   VARCHAR(8)      NULL,
    estado         TINYINT(1)      NULL,
    imagen         VARCHAR(500)    NULL,
    usuario        VARCHAR(50)     NULL,
    clave          VARCHAR(50)     NULL,
    PRIMARY KEY (idEmpleado),
    CONSTRAINT FK_Empleado_TipoEmpleado FOREIGN KEY (idTipoEmpleado)
        REFERENCES TipoEmpleado (idTipoEmpleado)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ============================================================
-- 4. MEDICO (depende de Empleado y Especialidad)
-- ============================================================
CREATE TABLE Medico (
    idMedico       INT         NOT NULL AUTO_INCREMENT,
    idEmpleado     INT         NOT NULL,
    idEspecialidad INT         NOT NULL,
    estado         TINYINT(1)  NULL,
    PRIMARY KEY (idMedico),
    CONSTRAINT FK_Medico_Empleado FOREIGN KEY (idEmpleado)
        REFERENCES Empleado (idEmpleado),
    CONSTRAINT FK_Medico_Especialidad FOREIGN KEY (idEspecialidad)
        REFERENCES Especialidad (idEspecialidad)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ============================================================
-- 5. PERMISOS (tabla puente Menu <-> Empleado, PK compuesta)
-- Entidad Permisos.java: @Id en idEmpleado e idMenu (ambos not null)
-- ============================================================
CREATE TABLE Permisos (
    idEmpleado INT        NOT NULL,
    idMenu     INT        NOT NULL,
    estado     TINYINT(1) NULL,
    PRIMARY KEY (idEmpleado, idMenu),
    CONSTRAINT FK_Permisos_Empleado FOREIGN KEY (idEmpleado)
        REFERENCES Empleado (idEmpleado),
    CONSTRAINT FK_Permisos_Menu FOREIGN KEY (idMenu)
        REFERENCES Menu (idMenu)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ============================================================
-- 6. HORARIOATENCION (depende de Medico, Hora, DiaSemana)
-- fecha = TIMESTAMP (Temporal.TIMESTAMP), fechaFin = DATE (Temporal.DATE)
-- ============================================================
CREATE TABLE HorarioAtencion (
    idHorarioAtencion INT         NOT NULL AUTO_INCREMENT,
    idMedico          INT         NOT NULL,
    idHoraInicio      INT         NOT NULL,
    fecha             DATETIME    NULL,
    fechaFin          DATE        NULL,
    estado            TINYINT(1)  NULL,
    idDiaSemana       INT         NULL,
    PRIMARY KEY (idHorarioAtencion),
    CONSTRAINT FK_HorarioAtencion_Medico FOREIGN KEY (idMedico)
        REFERENCES Medico (idMedico),
    CONSTRAINT FK_HorarioAtencion_Hora FOREIGN KEY (idHoraInicio)
        REFERENCES Hora (idHora),
    CONSTRAINT FK_HorarioAtencion_DiaSemana FOREIGN KEY (idDiaSemana)
        REFERENCES DiaSemana (idDiaSemana)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ============================================================
-- 7. PACIENTE (sin dependencias)
-- Entidad Paciente.java: nombres(50), apPaterno/apMaterno(20),
-- sexo(1), nroDocumento(8), direccion(150), telefono(20), imagen(500)
-- ============================================================
CREATE TABLE Paciente (
    idPaciente   INT          NOT NULL AUTO_INCREMENT,
    nombres      VARCHAR(50)  NULL,
    apPaterno    VARCHAR(20)  NULL,
    apMaterno    VARCHAR(20)  NULL,
    edad         INT          NULL,
    sexo         VARCHAR(1)   NULL,
    nroDocumento VARCHAR(8)   NULL,
    direccion    VARCHAR(150) NULL,
    telefono     VARCHAR(20)  NULL,
    estado       TINYINT(1)   NULL,
    imagen       VARCHAR(500) NULL,
    PRIMARY KEY (idPaciente)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ============================================================
-- 8. HISTORIACLINICA (depende de Paciente)
-- fechaApertura = TIMESTAMP (Temporal.TIMESTAMP)
-- ============================================================
CREATE TABLE HistoriaClinica (
    idHistoriaClinica INT        NOT NULL AUTO_INCREMENT,
    idPaciente         INT        NULL,
    fechaApertura      DATETIME   NULL,
    estado             TINYINT(1) NULL,
    PRIMARY KEY (idHistoriaClinica),
    CONSTRAINT FK_HistoriaClinica_Paciente FOREIGN KEY (idPaciente)
        REFERENCES Paciente (idPaciente)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ============================================================
-- 9. DIAGNOSTICO (depende de HistoriaClinica)
-- observacion @Column(length=500), fechaEmision = TIMESTAMP
-- ============================================================
CREATE TABLE Diagnostico (
    idDiagnostico     INT        NOT NULL AUTO_INCREMENT,
    idHistoriaClinica INT        NOT NULL,
    fechaEmision      DATETIME   NULL,
    observacion       VARCHAR(500) NULL,
    estado            TINYINT(1) NULL,
    PRIMARY KEY (idDiagnostico),
    CONSTRAINT FK_Diagnostico_HistoriaClinica FOREIGN KEY (idHistoriaClinica)
        REFERENCES HistoriaClinica (idHistoriaClinica)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ============================================================
-- 10. CITA (depende de Paciente y HorarioAtencion)
-- observacion(350), estado(1) <- código de 1 char, hora(6)
-- fechaReserva = TIMESTAMP
-- ============================================================
CREATE TABLE Cita (
    idCita             INT          NOT NULL AUTO_INCREMENT,
    idPaciente         INT          NOT NULL,
    fechaReserva       DATETIME     NULL,
    observacion        VARCHAR(350) NULL,
    estado             VARCHAR(1)   NULL,
    hora               VARCHAR(6)   NULL,
    idHorarioAtencion  INT          NULL,
    PRIMARY KEY (idCita),
    CONSTRAINT FK_Cita_Paciente FOREIGN KEY (idPaciente)
        REFERENCES Paciente (idPaciente),
    CONSTRAINT FK_Cita_HorarioAtencion FOREIGN KEY (idHorarioAtencion)
        REFERENCES HorarioAtencion (idHorarioAtencion)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ============================================================
-- ÍNDICES ADICIONALES SOBRE LLAVES FORÁNEAS
-- ============================================================
CREATE INDEX IX_Menu_MenuParent            ON Menu (idMenuParent);
CREATE INDEX IX_Empleado_TipoEmpleado      ON Empleado (idTipoEmpleado);
CREATE INDEX IX_Medico_Empleado            ON Medico (idEmpleado);
CREATE INDEX IX_Medico_Especialidad        ON Medico (idEspecialidad);
CREATE INDEX IX_HorarioAtencion_Medico     ON HorarioAtencion (idMedico);
CREATE INDEX IX_HorarioAtencion_Hora       ON HorarioAtencion (idHoraInicio);
CREATE INDEX IX_HorarioAtencion_DiaSemana  ON HorarioAtencion (idDiaSemana);
CREATE INDEX IX_HistoriaClinica_Paciente   ON HistoriaClinica (idPaciente);
CREATE INDEX IX_Diagnostico_HistClinica    ON Diagnostico (idHistoriaClinica);
CREATE INDEX IX_Cita_Paciente              ON Cita (idPaciente);
CREATE INDEX IX_Cita_HorarioAtencion       ON Cita (idHorarioAtencion);

-- ============================================================
-- DATOS SEMILLA (catálogos básicos para poder probar el sistema)
-- ============================================================

INSERT INTO TipoEmpleado (descripcion, estado) VALUES
    ('Administrador', 1),
    ('Medico', 1),
    ('Recepcionista', 1);

INSERT INTO Especialidad (descripcion, estado) VALUES
    ('Medicina General', 1),
    ('Pediatria', 1),
    ('Cardiologia', 1),
    ('Dermatologia', 1);

INSERT INTO DiaSemana (nombreDiaSemana) VALUES
    ('Lunes'), ('Martes'), ('Miercoles'),
    ('Jueves'), ('Viernes'), ('Sabado');

INSERT INTO Hora (hora) VALUES
    ('08:00'), ('08:30'), ('09:00'), ('09:30'),
    ('10:00'), ('10:30'), ('11:00'), ('11:30'),
    ('15:00'), ('15:30'), ('16:00'), ('16:30');

INSERT INTO Menu (nombre, isSubmenu, url, idMenuParent, estado, `show`, orden) VALUES
    ('Pacientes',     0, '/pacientes',     NULL, 1, 1, 1),
    ('Citas',         0, '/citas',         NULL, 1, 1, 2),
    ('Empleados',     0, '/empleados',     NULL, 1, 1, 3),
    ('Mantenimiento', 0, '/mantenimiento', NULL, 1, 1, 4);

-- Usuario administrador para poder loguearte de inmediato
-- (UsuarioController.login compara usuario/clave en texto plano, sin encriptar)
-- User: admin  /  Pass: admin  -- tal como indica la documentación del proyecto
INSERT INTO Empleado (idTipoEmpleado, nombres, apPaterno, apMaterno, nroDocumento, estado, usuario, clave) VALUES
    (1, 'Administrador', 'Sistema', '', '00000000', 1, 'admin', 'admin');

SELECT 'Base de datos sistema_clinico creada correctamente.' AS resultado;
