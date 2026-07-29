package com.utp.sistemas.entities;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Entity
@Data
@NoArgsConstructor
@AllArgsConstructor
public class Empleado {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer idEmpleado;

    @ManyToOne
    @JoinColumn(name = "idTipoEmpleado", nullable = false)
    private TipoEmpleado tipoEmpleado;

    @Column(length = 50)
    private String nombres;

    @Column(length = 20)
    private String apPaterno;

    @Column(length = 20)
    private String apMaterno;

    @Column(length = 8)
    private String nroDocumento;

    private Boolean estado;

    @Column(length = 500)
    private String imagen;

    @Column(length = 50)
    private String usuario;

    @Column(length = 50)
    private String clave;
}
