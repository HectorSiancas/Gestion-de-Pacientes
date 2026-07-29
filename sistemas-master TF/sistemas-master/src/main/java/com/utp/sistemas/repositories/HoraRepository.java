package com.utp.sistemas.repositories;

import com.utp.sistemas.entities.Hora;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface HoraRepository extends JpaRepository<Hora, Integer> {
}
