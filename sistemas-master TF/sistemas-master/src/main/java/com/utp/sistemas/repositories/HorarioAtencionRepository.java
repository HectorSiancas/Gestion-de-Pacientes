package com.utp.sistemas.repositories;

import com.utp.sistemas.entities.HorarioAtencion;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface HorarioAtencionRepository extends JpaRepository<HorarioAtencion, Integer> {
}

