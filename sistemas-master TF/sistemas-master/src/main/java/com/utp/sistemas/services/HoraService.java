package com.utp.sistemas.services;

import com.utp.sistemas.entities.Hora;
import com.utp.sistemas.repositories.HoraRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class HoraService {

    @Autowired
    private HoraRepository horaRepository;

    public Hora createHora(Hora hora) {
        return horaRepository.save(hora);
    }

    public List<Hora> getAllHoras() {
        return horaRepository.findAll();
    }

    public Optional<Hora> getHoraById(Integer id) {
        return horaRepository.findById(id);
    }

    public Hora updateHora(Integer id, Hora horaDetails) {
        Optional<Hora> hora = horaRepository.findById(id);
        if (hora.isPresent()) {
            Hora updatedHora = hora.get();
            updatedHora.setHora(horaDetails.getHora());
            return horaRepository.save(updatedHora);
        }
        return null;
    }

    public void deleteHora(Integer id) {
        Optional<Hora> hora = horaRepository.findById(id);
        hora.ifPresent(h -> horaRepository.delete(h));
    }
}