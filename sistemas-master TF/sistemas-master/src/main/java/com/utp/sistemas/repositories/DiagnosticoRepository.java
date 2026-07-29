package com.utp.sistemas.repositories;

import com.utp.sistemas.entities.Diagnostico;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface DiagnosticoRepository extends JpaRepository<Diagnostico, Integer> {
}
