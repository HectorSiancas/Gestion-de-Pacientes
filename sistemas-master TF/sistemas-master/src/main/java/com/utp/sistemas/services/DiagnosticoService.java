package com.utp.sistemas.services;

import com.utp.sistemas.entities.Diagnostico;
import com.utp.sistemas.repositories.DiagnosticoRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class DiagnosticoService {

    @Autowired
    private DiagnosticoRepository diagnosticoRepository;

    public Diagnostico createDiagnostico(Diagnostico diagnostico) {
        return diagnosticoRepository.save(diagnostico);
    }

    public List<Diagnostico> getAllDiagnosticos() {
        return diagnosticoRepository.findAll();
    }

    public Optional<Diagnostico> getDiagnosticoById(Integer id) {
        return diagnosticoRepository.findById(id);
    }

    public Diagnostico updateDiagnostico(Integer id, Diagnostico diagnosticoDetails) {
        Optional<Diagnostico> diagnostico = diagnosticoRepository.findById(id);
        if (diagnostico.isPresent()) {
            Diagnostico updatedDiagnostico = diagnostico.get();
            updatedDiagnostico.setFechaEmision(diagnosticoDetails.getFechaEmision());
            updatedDiagnostico.setObservacion(diagnosticoDetails.getObservacion());
            updatedDiagnostico.setEstado(diagnosticoDetails.getEstado());
            return diagnosticoRepository.save(updatedDiagnostico);
        }
        return null;
    }

    public void deleteDiagnostico(Integer id) {
        Optional<Diagnostico> diagnostico = diagnosticoRepository.findById(id);
        diagnostico.ifPresent(d -> diagnosticoRepository.delete(d));
    }
}

