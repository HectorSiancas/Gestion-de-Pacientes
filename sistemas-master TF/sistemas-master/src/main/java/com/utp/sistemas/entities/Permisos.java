package com.utp.sistemas.entities;

import jakarta.persistence.Entity;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Entity
@Data
@NoArgsConstructor
@AllArgsConstructor
public class Permisos {
    @Id
    @ManyToOne
    @JoinColumn(name = "idEmpleado", nullable = false)
    private Empleado empleado;

    @Id
    @ManyToOne
    @JoinColumn(name = "idMenu", nullable = false)
    private Menu menu;

    private Boolean estado;
}