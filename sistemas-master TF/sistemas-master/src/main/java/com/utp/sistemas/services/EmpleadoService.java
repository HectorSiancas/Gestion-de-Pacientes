package com.utp.sistemas.services;

import com.utp.sistemas.entities.Empleado;
import com.utp.sistemas.repositories.EmpleadoRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class EmpleadoService {

    @Autowired
    private EmpleadoRepository empleadoRepository;

    public Empleado createEmpleado(Empleado empleado) {
        return empleadoRepository.save(empleado);
    }

    public List<Empleado> getAllEmpleados() {
        return empleadoRepository.findAll();
    }

    public Optional<Empleado> getEmpleadoById(Integer id) {
        return empleadoRepository.findById(id);
    }

    public Empleado updateEmpleado(Integer id, Empleado empleadoDetails) {
        Optional<Empleado> empleado = empleadoRepository.findById(id);
        if (empleado.isPresent()) {
            Empleado updatedEmpleado = empleado.get();
            updatedEmpleado.setNombres(empleadoDetails.getNombres());
            updatedEmpleado.setApPaterno(empleadoDetails.getApPaterno());
            updatedEmpleado.setApMaterno(empleadoDetails.getApMaterno());
            updatedEmpleado.setNroDocumento(empleadoDetails.getNroDocumento());
            updatedEmpleado.setEstado(empleadoDetails.getEstado());
            updatedEmpleado.setImagen(empleadoDetails.getImagen());
            updatedEmpleado.setUsuario(empleadoDetails.getUsuario());
            updatedEmpleado.setClave(empleadoDetails.getClave());
            return empleadoRepository.save(updatedEmpleado);
        }
        return null;
    }

    public void deleteEmpleado(Integer id) {
        Optional<Empleado> empleado = empleadoRepository.findById(id);
        empleado.ifPresent(e -> empleadoRepository.delete(e));
    }
}

