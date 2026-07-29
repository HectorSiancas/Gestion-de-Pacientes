package com.utp.sistemas.entities;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.Date;

@Entity
@Data
@NoArgsConstructor
@AllArgsConstructor
public class Diagnostico {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer idDiagnostico;

    @ManyToOne
    @JoinColumn(name = "idHistoriaClinica", nullable = false)
    private HistoriaClinica historiaClinica;

    @Temporal(TemporalType.TIMESTAMP)
    private Date fechaEmision;

    @Column(length = 500)
    private String observacion;

    private Boolean estado;
}
