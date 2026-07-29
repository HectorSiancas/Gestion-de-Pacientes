package com.utp.sistemas.repositories;

import com.utp.sistemas.entities.Especialidad;
import com.utp.sistemas.entities.HistoriaClinica;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface HistoriaClinicaRepository extends JpaRepository<HistoriaClinica, Integer> {
}