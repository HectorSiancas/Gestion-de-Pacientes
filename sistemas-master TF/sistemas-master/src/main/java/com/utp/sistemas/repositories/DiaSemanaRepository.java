package com.utp.sistemas.repositories;

import com.utp.sistemas.entities.DiaSemana;
import com.utp.sistemas.entities.Diagnostico;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface DiaSemanaRepository extends JpaRepository<DiaSemana, Integer> {
}