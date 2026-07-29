package com.utp.sistemas.entities;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@NoArgsConstructor
@AllArgsConstructor
@Entity
//@Table(name = "Pacientes")
public class Paciente {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer idPaciente;

    @Column(length = 50)
    private String nombres;

    @Column(length = 20)
    private String apPaterno;

    @Column(length = 20)
    private String apMaterno;

    private Integer edad;

    @Column(length = 1)
    private String sexo;

    @Column(length = 8)
    private String nroDocumento;

    @Column(length = 150)
    private String direccion;

    @Column(length = 20)
    private String telefono;

    private Boolean estado;

    @Column(length = 500)
    private String imagen;
}
