package com.utp.sistemas.entities;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Entity
@Data
@NoArgsConstructor
@AllArgsConstructor
public class Medico {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer idMedico;

    @ManyToOne
    @JoinColumn(name = "idEmpleado", nullable = false)
    private Empleado empleado;

    @ManyToOne
    @JoinColumn(name = "idEspecialidad", nullable = false)
    private Especialidad especialidad;

    private Boolean estado;
}
