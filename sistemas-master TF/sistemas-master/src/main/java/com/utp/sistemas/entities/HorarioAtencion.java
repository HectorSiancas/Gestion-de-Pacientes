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
public class HorarioAtencion {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer idHorarioAtencion;

    @ManyToOne
    @JoinColumn(name = "idMedico", nullable = false)
    private Medico medico;

    @ManyToOne
    @JoinColumn(name = "idHoraInicio", nullable = false)
    private Hora horaInicio;

    @Temporal(TemporalType.TIMESTAMP)
    private Date fecha;

    @Temporal(TemporalType.DATE)
    private Date fechaFin;

    private Boolean estado;

    @ManyToOne
    @JoinColumn(name = "idDiaSemana")
    private DiaSemana diaSemana;
}
