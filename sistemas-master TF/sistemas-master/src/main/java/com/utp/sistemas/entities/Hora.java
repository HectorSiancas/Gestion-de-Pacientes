package com.utp.sistemas.entities;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Entity
@Data
@NoArgsConstructor
@AllArgsConstructor
public class Hora {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer idHora;

    @Column(length = 6)
    private String hora;
}

