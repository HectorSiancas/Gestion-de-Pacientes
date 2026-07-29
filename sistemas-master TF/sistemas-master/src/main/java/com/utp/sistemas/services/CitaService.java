package com.utp.sistemas.services;

import com.utp.sistemas.entities.Cita;
import com.utp.sistemas.repositories.CitaRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class CitaService {

    @Autowired
    private CitaRepository citaRepository;

    public Cita createCita(Cita cita) {
        return citaRepository.save(cita);
    }

    public List<Cita> getAllCitas() {
        return citaRepository.findAll();
    }

    public Optional<Cita> getCitaById(Integer id) {
        return citaRepository.findById(id);
    }

    public Cita updateCita(Integer id, Cita citaDetails) {
        Optional<Cita> cita = citaRepository.findById(id);
        if (cita.isPresent()) {
            Cita updatedCita = cita.get();
            updatedCita.setFechaReserva(citaDetails.getFechaReserva());
            updatedCita.setObservacion(citaDetails.getObservacion());
            updatedCita.setEstado(citaDetails.getEstado());
            updatedCita.setHora(citaDetails.getHora());
            updatedCita.setHorarioAtencion(citaDetails.getHorarioAtencion());
            return citaRepository.save(updatedCita);
        }
        return null;
    }

    public void deleteCita(Integer id) {
        Optional<Cita> cita = citaRepository.findById(id);
        cita.ifPresent(c -> citaRepository.delete(c));
    }
}

