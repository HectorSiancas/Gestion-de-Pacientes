package com.utp.sistemas.repositories;

import com.utp.sistemas.entities.TipoEmpleado;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface TipoEmpleadoRepository extends JpaRepository<TipoEmpleado, Integer> {
}

