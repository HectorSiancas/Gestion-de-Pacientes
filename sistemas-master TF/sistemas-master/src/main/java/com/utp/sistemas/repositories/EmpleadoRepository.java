package com.utp.sistemas.repositories;

import com.utp.sistemas.entities.Empleado;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.Optional;

@Repository
public interface EmpleadoRepository extends JpaRepository<Empleado, Integer> {
    Optional<Empleado> findByUsuarioAndClave(String usuario, String clave);
}
