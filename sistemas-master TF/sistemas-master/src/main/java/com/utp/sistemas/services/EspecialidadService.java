package com.utp.sistemas.services;

import com.utp.sistemas.entities.Especialidad;
import com.utp.sistemas.repositories.EspecialidadRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class EspecialidadService {

    @Autowired
    private EspecialidadRepository especialidadRepository;

    public Especialidad createEspecialidad(Especialidad especialidad) {
        return especialidadRepository.save(especialidad);
    }

    public List<Especialidad> getAllEspecialidades() {
        return especialidadRepository.findAll();
    }

    public Optional<Especialidad> getEspecialidadById(Integer id) {
        return especialidadRepository.findById(id);
    }

    public Especialidad updateEspecialidad(Integer id, Especialidad especialidadDetails) {
        Optional<Especialidad> especialidad = especialidadRepository.findById(id);
        if (especialidad.isPresent()) {
            Especialidad updatedEspecialidad = especialidad.get();
            updatedEspecialidad.setDescripcion(especialidadDetails.getDescripcion());
            updatedEspecialidad.setEstado(especialidadDetails.getEstado());
            return especialidadRepository.save(updatedEspecialidad);
        }
        return null;
    }

    public void deleteEspecialidad(Integer id) {
        Optional<Especialidad> especialidad = especialidadRepository.findById(id);
        especialidad.ifPresent(e -> especialidadRepository.delete(e));
    }
}

