package com.utp.sistemas.entities;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Entity
@Data
@NoArgsConstructor
@AllArgsConstructor
public class TipoEmpleado {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer idTipoEmpleado;

    @Column(length = 25)
    private String descripcion;

    private Boolean estado;
}
