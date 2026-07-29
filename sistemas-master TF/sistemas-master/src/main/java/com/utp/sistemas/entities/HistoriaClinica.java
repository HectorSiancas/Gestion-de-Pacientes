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
@Table(name = "HistoriaClinica")
public class HistoriaClinica {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer idHistoriaClinica;

    @ManyToOne
    @JoinColumn(name = "idPaciente")
    private Paciente paciente;

    @Temporal(TemporalType.TIMESTAMP)
    private Date fechaApertura;

    private Boolean estado;
}

