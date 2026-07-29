package com.utp.sistemas.services;

import com.utp.sistemas.entities.HorarioAtencion;
import com.utp.sistemas.repositories.HorarioAtencionRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class HorarioAtencionService {

    @Autowired
    private HorarioAtencionRepository horarioAtencionRepository;

    public HorarioAtencion createHorarioAtencion(HorarioAtencion horarioAtencion) {
        return horarioAtencionRepository.save(horarioAtencion);
    }

    public List<HorarioAtencion> getAllHorariosAtencion() {
        return horarioAtencionRepository.findAll();
    }

    public Optional<HorarioAtencion> getHorarioAtencionById(Integer id) {
        return horarioAtencionRepository.findById(id);
    }

    public HorarioAtencion updateHorarioAtencion(Integer id, HorarioAtencion horarioAtencionDetails) {
        Optional<HorarioAtencion> horarioAtencion = horarioAtencionRepository.findById(id);
        if (horarioAtencion.isPresent()) {
            HorarioAtencion updatedHorarioAtencion = horarioAtencion.get();
            updatedHorarioAtencion.setMedico(horarioAtencionDetails.getMedico());
            updatedHorarioAtencion.setHoraInicio(horarioAtencionDetails.getHoraInicio());
            updatedHorarioAtencion.setFecha(horarioAtencionDetails.getFecha());
            updatedHorarioAtencion.setFechaFin(horarioAtencionDetails.getFechaFin());
            updatedHorarioAtencion.setEstado(horarioAtencionDetails.getEstado());
            updatedHorarioAtencion.setDiaSemana(horarioAtencionDetails.getDiaSemana());
            return horarioAtencionRepository.save(updatedHorarioAtencion);
        }
        return null;
    }

    public void deleteHorarioAtencion(Integer id) {
        Optional<HorarioAtencion> horarioAtencion = horarioAtencionRepository.findById(id);
        horarioAtencion.ifPresent(h -> horarioAtencionRepository.delete(h));
    }
}

