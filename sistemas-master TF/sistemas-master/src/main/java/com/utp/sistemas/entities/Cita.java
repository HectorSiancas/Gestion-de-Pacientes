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
public class Cita {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer idCita;

//    @ManyToOne
//    @JoinColumn(name = "idMedico", nullable = false)
//    private Medico medico;

    @ManyToOne
    @JoinColumn(name = "idPaciente", nullable = false)
    private Paciente paciente;

    @Temporal(TemporalType.TIMESTAMP)
    private Date fechaReserva;

    @Column(length = 350)
    private String observacion;

    @Column(length = 1)
    private String estado;

    @Column(length = 6)
    private String hora;

    @ManyToOne
    @JoinColumn(name = "idHorarioAtencion")
    private HorarioAtencion horarioAtencion;
}
